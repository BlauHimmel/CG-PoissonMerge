using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Single;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace PoissonMerge
{
    class RGB
    {
        public RGB()
        {
            R = 0;
            G = 0;
            B = 0;
        }
        public RGB(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }
        public int R { set; get; }
        public int G { set; get; }
        public int B { set; get; }

        public static RGB operator +(RGB rgb1,RGB rgb2)
        {
            int r = rgb1.R + rgb2.R;
            int g = rgb1.G + rgb2.G;
            int b = rgb1.B + rgb2.B;
            return new RGB(r, g, b); 
        }

        public static RGB operator -(RGB rgb1, RGB rgb2)
        {
            int r = rgb1.R - rgb2.R;
            int g = rgb1.G - rgb2.G;
            int b = rgb1.B - rgb2.B;
            return new RGB(r, g, b); 
        }

        public static RGB operator *(RGB rgb1, RGB rgb2)
        {
            int r = rgb1.R * rgb2.R;
            int g = rgb1.G * rgb2.G;
            int b = rgb1.B * rgb2.B;
            return new RGB(r, g, b); 
        }

        public static RGB operator *(int num, RGB rgb)
        {
            int r = num * rgb.R;
            int g = num * rgb.G;
            int b = num * rgb.B;
            return new RGB(r, g, b); 
        }

        public static RGB operator *(RGB rgb, int num)
        {
            int r = num * rgb.R;
            int g = num * rgb.G;
            int b = num * rgb.B;
            return new RGB(r, g, b);
        }
    }

    class PoissonMerge
    {
        public Bitmap CreateBitmap(Bitmap background, Bitmap roi, Point lefttop)
        {           
            float[,] X = GetMatrixX(background, roi, lefttop);
            BitmapData bmpData = background.LockBits(new Rectangle(0, 0, background.Width, background.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* ptr = (byte*)(bmpData.Scan0);
                int index = 0;
                for (int i = 0; i < bmpData.Height; i++)
                {
                    for (int j = 0; j < bmpData.Width; j++)
                    {
                        if (i >= lefttop.Y && j >= lefttop.X && i - lefttop.Y < roi.Height && j - lefttop.X < roi.Width)
                        {
                            *ptr = Convert.ToByte(X[index, 0] < 0 ? 0 : (X[index, 0] > 255 ? 255 : X[index, 0]));
                            ptr++;
                            *ptr = Convert.ToByte(X[index, 1] < 0 ? 0 : (X[index, 1] > 255 ? 255 : X[index, 1]));
                            ptr++;
                            *ptr = Convert.ToByte(X[index, 2] < 0 ? 0 : (X[index, 2] > 255 ? 255 : X[index, 2]));
                            ptr++;
                            index++;
                        }
                        else
                        {
                            ptr += 3;
                        }                                     
                    }
                    ptr += bmpData.Stride - bmpData.Width * 3;
                }
            }
            background.UnlockBits(bmpData);
            return background;
        }

        private float[,] GetMatrixX(Bitmap background, Bitmap roi, Point lefttop)
        {
            int width = roi.Width;
            int height = roi.Height;
            SparseMatrix A = GetMatrixA(width, height);
            DenseMatrix B = DenseMatrix.OfArray(GetMatrixB(background, roi, lefttop));       
            MathNet.Numerics.LinearAlgebra.Matrix<float> X = A.Solve(B);
            return X.ToArray();
        }

        private float[,] GetMatrixB(Bitmap background, Bitmap roi, Point lefttop)
        {
            int width = roi.Width;
            int height = roi.Height;
            float[,] B = new float[width * height, 3];
            RGB[,] src = GetPixel(background);
            RGB[,] gradient = GetGradientMerged(background, roi, lefttop);


            for (int i = 0; i < width * height; i++)
            {
                if (IsInner(i + 1, width, height))
                {
                    B[i, 0] = gradient[lefttop.Y + i / width, lefttop.X + i % width].B;
                    B[i, 1] = gradient[lefttop.Y + i / width, lefttop.X + i % width].G;
                    B[i, 2] = gradient[lefttop.Y + i / width, lefttop.X + i % width].R;
                }
                else
                {
                    B[i, 0] = src[lefttop.Y + i / width, lefttop.X + i % width].B;
                    B[i, 1] = src[lefttop.Y + i / width, lefttop.X + i % width].G;
                    B[i, 2] = src[lefttop.Y + i / width, lefttop.X + i % width].R;
                }
            }
            return B;
        }

        /// <summary>
        /// 获得方程Ax = b中的矩阵A
        /// </summary>
        /// <param name="width">图像宽度</param>
        /// <param name="height">图像高度</param>
        /// <returns></returns>
        private SparseMatrix GetMatrixA(int width, int height)
        {
            SparseMatrix A = new SparseMatrix(width * height, width * height);
        
            for (int i = 0; i < width * height; i++)
            {
                A[i, i] = 1;
                if (IsInner(i + 1, width, height))
                {
                    A[i, i] = -4;
                    A[i, i - 1] = 1;
                    A[i, i + 1] = 1;
                    A[i, i - width] = 1;
                    A[i, i + width] = 1;                  
                }         
            }
            return A;
        }

        /// <summary>
        /// 是否处于矩阵内部
        /// </summary>
        /// <param name="index">矩阵编号，从左到右，从上到下，从1开始</param>
        /// <param name="width">矩阵的宽度</param>
        /// <param name="height">矩阵的高度</param>
        /// <returns></returns>
        private bool IsInner(int index, int width, int height)
        {
            if (index <= width)
            {
                return false;
            }
            if (width * height - index < width)
            {
                return false;
            }
            if ((index - 1) % width == 0 || index % width == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获得背景图像和ROI的合成图像的目标梯度场
        /// </summary>
        /// <param name="background">背景图像</param>
        /// <param name="roi">ROI图像</param>
        /// <param name="lefttop">ROI的左上角在背景图上的坐标</param>
        /// <returns></returns>
        private RGB[,] GetGradientMerged(Bitmap background, Bitmap roi, Point lefttop)
        {
            RGB[,] backgroundGradient = GetGradient(background);
            RGB[,] roiGradient = GetGradient(roi);
            for (int i = lefttop.Y + 1; i < lefttop.Y + roi.Height - 1; i++)
            {
                for (int j = lefttop.X + 1; j < lefttop.X + roi.Width - 1; j++)
                {
                    backgroundGradient[i, j] = roiGradient[i - lefttop.Y, j - lefttop.X];
                }
            }
            return backgroundGradient;
        }

        /// <summary>
        /// 获得图像的梯度场，边缘元素为NULL，其它元素为RGB对象
        /// </summary>
        /// <param name="bitmap">图像</param>
        /// <returns></returns>
        private RGB[,] GetGradient(Bitmap bitmap)
        {
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            RGB[,] src = new RGB[bitmap.Height, bitmap.Width];
            RGB[,] gradient = new RGB[bitmap.Height, bitmap.Width];
            unsafe
            {
                byte* ptr = (byte*)(bmpData.Scan0);
                for (int i = 0; i < bmpData.Height; i++)
                {
                    for (int j = 0; j < bmpData.Width; j++)
                    {
                        RGB rgb = new RGB();
                        rgb.B = *ptr;
                        ptr++;
                        rgb.G = *ptr;
                        ptr++;
                        rgb.R = *ptr;
                        ptr++;
                        src[i, j] = rgb;
                        gradient[i,j] = null;
                    }
                    ptr += bmpData.Stride - bmpData.Width * 3;
                }
            }
            for (int i = 1; i < bmpData.Height - 1; i++)
            {
                for (int j = 1; j < bmpData.Width - 1; j++)
                {
                    gradient[i, j] = src[i - 1, j] + src[i + 1, j] + src[i, j - 1] + src[i, j + 1] - 4 * src[i, j];
                }
            }
            bitmap.UnlockBits(bmpData);
            return gradient;
        }

        private RGB[,] GetPixel(Bitmap bitmap)
        {
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            RGB[,] src = new RGB[bitmap.Height, bitmap.Width];         
            unsafe
            {
                byte* ptr = (byte*)(bmpData.Scan0);
                for (int i = 0; i < bmpData.Height; i++)
                {
                    for (int j = 0; j < bmpData.Width; j++)
                    {
                        RGB rgb = new RGB();
                        rgb.B = *ptr;
                        ptr++;
                        rgb.G = *ptr;
                        ptr++;
                        rgb.R = *ptr;
                        ptr++;
                        src[i, j] = rgb;
                       
                    }
                    ptr += bmpData.Stride - bmpData.Width * 3;
                }
            }
            bitmap.UnlockBits(bmpData);
            return src;
        } 
    }
}
