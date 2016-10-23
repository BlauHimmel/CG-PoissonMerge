using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PoissonMerge
{
    public partial class Form1 : Form
    {
        private Bitmap background;
        private Bitmap background2;
        private Bitmap roi;

        private bool bgLoad = false;
        private bool bg2Load = false;
        private bool roiSel = false;
        private bool isDrawing = false;
        private bool isSelecting = false;

        private Point startPoint;
        private Point endPoint;
        private Point lefttop;

        private SynchronizationContext context;
        public Form1()
        {
            InitializeComponent();
            SelectRoiButton.Enabled = false;
            SelectPositionButton.Enabled = false;
            tabControl.Selected += new TabControlEventHandler(tabControl_Selected);
            BackGroundPictureBox.MouseClick += new MouseEventHandler(pictureBox_MouseClick);
            RoiPictureBox.MouseUp += new MouseEventHandler(pictureBox_MouseUp);
            RoiPictureBox.MouseDown += new MouseEventHandler(pictureBox_MouseDown);
            RoiPictureBox.MouseMove += new MouseEventHandler(pictureBox_MouseMove);
            panel1.VerticalScroll.Value = VerticalScroll.Maximum;
            panel1.HorizontalScroll.Value = HorizontalScroll.Maximum;
            panel2.VerticalScroll.Value = VerticalScroll.Maximum;
            panel2.HorizontalScroll.Value = HorizontalScroll.Maximum;
            context = SynchronizationContext.Current;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if(e.TabPage == tabPageBg)
            {
                SelectRoiButton.Enabled = false;
                if (roiSel && bgLoad)
                {
                    SelectPositionButton.Enabled = true;
                    
                }
                else
                {
                    SelectPositionButton.Enabled = false;
                }
            }

            if (e.TabPage == tabPageRoi)
            {
                SelectRoiButton.Enabled = false;
                SelectPositionButton.Enabled = false;
                RoiPictureBox.Image = background2;
                ROILookPictureBox.Image = null;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (bg2Load && isDrawing)
            {
                isDrawing = false;
                SelectRoiButton.Enabled = true;
            }
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (bg2Load)
            {
                startPoint = new Point(e.X, e.Y);
                isDrawing = true;
                SelectRoiButton.Enabled = false;
                roiSel = false;
                roi = null;
            }
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (bg2Load && isDrawing)
            {
                endPoint = new Point(e.X, e.Y);
                DrawSelectedRect();
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (bgLoad && roiSel && isSelecting)
            {
                if (background.Width - e.X <= roi.Width || background.Height - e.Y <= roi.Height)
                {
                    MessageBox.Show("不能插入到这个位置,请重试！", "提示");
                    return;
                }
                lefttop = new Point(e.X, e.Y);
                isSelecting = false;
                MessageBox.Show("位置已选择,正在处理！", "提示");              
                Thread thread = new Thread(Process);
                thread.Start();
            }          
        }

        private void Process()
        {
            context.Post(StateChange, "true");        
            PoissonMerge pm = new PoissonMerge();
            Bitmap bitmap = pm.CreateBitmap(background, roi, lefttop);
            BackGroundPictureBox.Image = bitmap;
            context.Post(StateChange, "false");         
            MessageBox.Show("处理完成！", "提示");
        }

        private void StateChange(Object process)
        {
            if (process.Equals("true"))
            {
                progressBar.Style = ProgressBarStyle.Marquee;
            }
            else if (process.Equals("false"))
            {
                progressBar.Style = ProgressBarStyle.Blocks;
            }
        }

        private void DrawSelectedRect()
        {
            Bitmap memoryBuffer = new Bitmap(background2.Width, background2.Height);
            Graphics.FromImage(memoryBuffer).DrawImage(background2, new Point(0, 0));
            PictureBox pictureBox = RoiPictureBox;
            Bitmap bitmap = background2;

            Graphics g = Graphics.FromImage(memoryBuffer);
            pictureBox.Image = bitmap;
            Rectangle rect = new Rectangle
              (
                  Math.Min(startPoint.X, endPoint.X),
                  Math.Min(startPoint.Y, endPoint.Y),
                  Math.Abs(startPoint.X - endPoint.X),
                  Math.Abs(startPoint.Y - endPoint.Y)
              );
            g.DrawRectangle(Pens.Red, rect);
            g.Dispose();
            pictureBox.Image = memoryBuffer;
        }

        private void SelectBackgroundButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Title = "请选择背景图片";
            open.Filter = "bmp files (*.bmp)|*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                background = new Bitmap(open.FileName);              
                BackGroundPictureBox.Image = background;
                tabControl.SelectTab("tabPageBg");
                bgLoad = true;
            }
        }

        private void SelectRoiPictureButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Title = "请选择待插入图片";
            open.Filter = "bmp files (*.bmp)|*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                background2 = new Bitmap(open.FileName);
                RoiPictureBox.Image = background2;
                tabControl.SelectTab("tabPageRoi");
                bg2Load = true;
            }
        }

        private void SelectRoiButton_Click(object sender, EventArgs e)
        {
            SelectRoiButton.Enabled = false;
            roiSel = true;
            Rectangle rect = new Rectangle
              (
                  Math.Min(startPoint.X, endPoint.X),
                  Math.Min(startPoint.Y, endPoint.Y),
                  Math.Abs(startPoint.X - endPoint.X),
                  Math.Abs(startPoint.Y - endPoint.Y)
              );
            Point lefttop = new Point(rect.Left, rect.Top);
            roi = new Bitmap(rect.Width, rect.Height);
            Graphics.FromImage(roi).DrawImage(background2, new Rectangle(0, 0, roi.Width, rect.Height), rect, GraphicsUnit.Pixel) ; 
            ROILookPictureBox.Image = roi;
        }

        private void SelectPositionButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请选择插入位置！", "提示") == DialogResult.OK)
            {
                isSelecting = true;
            }
        }
    }
}
