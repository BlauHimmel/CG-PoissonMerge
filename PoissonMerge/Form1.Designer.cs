namespace PoissonMerge
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectRoiPictureButton = new System.Windows.Forms.Button();
            this.tabPageRoi = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RoiPictureBox = new System.Windows.Forms.PictureBox();
            this.tabPageBg = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BackGroundPictureBox = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.SelectBackgroundButton = new System.Windows.Forms.Button();
            this.SelectRoiButton = new System.Windows.Forms.Button();
            this.SelectPositionButton = new System.Windows.Forms.Button();
            this.ROILookPictureBox = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tabPageRoi.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoiPictureBox)).BeginInit();
            this.tabPageBg.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackGroundPictureBox)).BeginInit();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ROILookPictureBox)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectRoiPictureButton
            // 
            this.SelectRoiPictureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectRoiPictureButton.Location = new System.Drawing.Point(580, 41);
            this.SelectRoiPictureButton.Name = "SelectRoiPictureButton";
            this.SelectRoiPictureButton.Size = new System.Drawing.Size(111, 23);
            this.SelectRoiPictureButton.TabIndex = 1;
            this.SelectRoiPictureButton.Text = "选择待插入图片";
            this.SelectRoiPictureButton.UseVisualStyleBackColor = true;
            this.SelectRoiPictureButton.Click += new System.EventHandler(this.SelectRoiPictureButton_Click);
            // 
            // tabPageRoi
            // 
            this.tabPageRoi.AutoScroll = true;
            this.tabPageRoi.Controls.Add(this.panel2);
            this.tabPageRoi.Location = new System.Drawing.Point(4, 22);
            this.tabPageRoi.Name = "tabPageRoi";
            this.tabPageRoi.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRoi.Size = new System.Drawing.Size(554, 411);
            this.tabPageRoi.TabIndex = 1;
            this.tabPageRoi.Text = "待插入图";
            this.tabPageRoi.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.RoiPictureBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(548, 405);
            this.panel2.TabIndex = 1;
            // 
            // RoiPictureBox
            // 
            this.RoiPictureBox.Location = new System.Drawing.Point(3, 3);
            this.RoiPictureBox.Name = "RoiPictureBox";
            this.RoiPictureBox.Size = new System.Drawing.Size(100, 50);
            this.RoiPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.RoiPictureBox.TabIndex = 0;
            this.RoiPictureBox.TabStop = false;
            // 
            // tabPageBg
            // 
            this.tabPageBg.AutoScroll = true;
            this.tabPageBg.Controls.Add(this.panel1);
            this.tabPageBg.Location = new System.Drawing.Point(4, 22);
            this.tabPageBg.Name = "tabPageBg";
            this.tabPageBg.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBg.Size = new System.Drawing.Size(554, 411);
            this.tabPageBg.TabIndex = 0;
            this.tabPageBg.Text = "背景图";
            this.tabPageBg.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.BackGroundPictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 405);
            this.panel1.TabIndex = 1;
            // 
            // BackGroundPictureBox
            // 
            this.BackGroundPictureBox.Location = new System.Drawing.Point(3, 3);
            this.BackGroundPictureBox.Name = "BackGroundPictureBox";
            this.BackGroundPictureBox.Size = new System.Drawing.Size(100, 50);
            this.BackGroundPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BackGroundPictureBox.TabIndex = 0;
            this.BackGroundPictureBox.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageBg);
            this.tabControl.Controls.Add(this.tabPageRoi);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(562, 437);
            this.tabControl.TabIndex = 3;
            // 
            // SelectBackgroundButton
            // 
            this.SelectBackgroundButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectBackgroundButton.Location = new System.Drawing.Point(580, 12);
            this.SelectBackgroundButton.Name = "SelectBackgroundButton";
            this.SelectBackgroundButton.Size = new System.Drawing.Size(111, 23);
            this.SelectBackgroundButton.TabIndex = 0;
            this.SelectBackgroundButton.Text = "选择背景图片";
            this.SelectBackgroundButton.UseVisualStyleBackColor = true;
            this.SelectBackgroundButton.Click += new System.EventHandler(this.SelectBackgroundButton_Click);
            // 
            // SelectRoiButton
            // 
            this.SelectRoiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectRoiButton.Location = new System.Drawing.Point(581, 71);
            this.SelectRoiButton.Name = "SelectRoiButton";
            this.SelectRoiButton.Size = new System.Drawing.Size(110, 23);
            this.SelectRoiButton.TabIndex = 4;
            this.SelectRoiButton.Text = "选择区域";
            this.SelectRoiButton.UseVisualStyleBackColor = true;
            this.SelectRoiButton.Click += new System.EventHandler(this.SelectRoiButton_Click);
            // 
            // SelectPositionButton
            // 
            this.SelectPositionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectPositionButton.Location = new System.Drawing.Point(581, 101);
            this.SelectPositionButton.Name = "SelectPositionButton";
            this.SelectPositionButton.Size = new System.Drawing.Size(110, 23);
            this.SelectPositionButton.TabIndex = 5;
            this.SelectPositionButton.Text = "选择插入位置";
            this.SelectPositionButton.UseVisualStyleBackColor = true;
            this.SelectPositionButton.Click += new System.EventHandler(this.SelectPositionButton_Click);
            // 
            // ROILookPictureBox
            // 
            this.ROILookPictureBox.Location = new System.Drawing.Point(3, 0);
            this.ROILookPictureBox.Name = "ROILookPictureBox";
            this.ROILookPictureBox.Size = new System.Drawing.Size(100, 107);
            this.ROILookPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ROILookPictureBox.TabIndex = 6;
            this.ROILookPictureBox.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.ROILookPictureBox);
            this.panel3.Location = new System.Drawing.Point(581, 301);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(113, 119);
            this.panel3.TabIndex = 7;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(580, 426);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(113, 23);
            this.progressBar.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 461);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.SelectPositionButton);
            this.Controls.Add(this.SelectRoiButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.SelectRoiPictureButton);
            this.Controls.Add(this.SelectBackgroundButton);
            this.MinimumSize = new System.Drawing.Size(300, 170);
            this.Name = "Form1";
            this.Text = "泊松融合";
            this.tabPageRoi.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoiPictureBox)).EndInit();
            this.tabPageBg.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackGroundPictureBox)).EndInit();
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ROILookPictureBox)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SelectRoiPictureButton;
        private System.Windows.Forms.TabPage tabPageRoi;
        private System.Windows.Forms.TabPage tabPageBg;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button SelectBackgroundButton;
        private System.Windows.Forms.PictureBox RoiPictureBox;
        private System.Windows.Forms.PictureBox BackGroundPictureBox;
        private System.Windows.Forms.Button SelectRoiButton;
        private System.Windows.Forms.Button SelectPositionButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox ROILookPictureBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar progressBar;

    }
}

