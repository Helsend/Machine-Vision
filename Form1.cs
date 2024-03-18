using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Threading;

namespace 简单图像处理软件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void intrudBtn_Load(object sender, EventArgs e)
        {
            
        }
       
        public Mat pictureMain;//当前主窗体图像
        public Mat form2image;//窗体二图像
        public float form2Num1=50f;
        public float form2Num2 = 150f;//接受窗体二传入的参数一参数二
        string imageName;
        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd1 = new OpenFileDialog();//创建打开文件夹窗体
            ofd1.Title = "请选择输入的图像";
            ofd1.InitialDirectory = @"";//初始化目录
            ofd1.Multiselect = false;//不可多选
            ofd1.Filter = "图像文件|*.jpg;*.png;*.bmp|全部文件|*.*";
            ofd1.ShowDialog();

            if (ofd1.FileName!=string.Empty)
            {
                try
                {
                    pictureShow.Load(ofd1.FileName);
                    imageName = ofd1.FileName;
                    textBox1.AppendText("\n\r打开文件：" + imageName);
                    textBox1.SelectionStart = this.textBox1.TextLength;
                    textBox1.ScrollToCaret();
                    pictureMain = new Mat(ofd1.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("打开失败，请检查文件格式是否符合");
                }
                
            }

        }
        
        private void saveBtn_Click(object sender, EventArgs e)
        {
            
            if (pictureShow!=null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "保存文件";
                sfd.Filter = "JPGE图像|*.jpg|PNG图像|*.png|BMP图像|*.bmp|所有文件|*.*";
                sfd.InitialDirectory = Environment.CurrentDirectory;
                sfd.ShowDialog();
                if (sfd.FileName != null)
                {
                    try
                    {
                        pictureShow.Image.Save(sfd.FileName);
                        textBox1.AppendText("\r\n图片已保存至：" + sfd.FileName);
                        textBox1.SelectionStart = textBox1.TextLength;
                        textBox1.ScrollToCaret();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                MessageBox.Show("无可保存图片");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void reflashBtn_Click(object sender, EventArgs e)
        {
            num = 1;
            listBox2.Items.Clear();
            textBox1.Text = "以下为通知信息：";
            if (imageName != string.Empty)
            {
                try
                {
                    pictureShow.Load(imageName);
                    pictureMain = new Mat(imageName);
                    pictureShow.Image = pictureMain.ToBitmap();
                }
                catch { }
                }

        }
        int num = 1;//记录处理次数
        public  enum lb1_list//记录操作方法
        {
            gray,
            reverse,
            binary,
            gaussianBlur,
            blur,
            medianBlur,
            bilateralFilter,
            canny,
            carve,
            rever_lr,
            rever_tb,
            sharp,
            dilate,
            erode,
            gamma,
            log,
            hist,
            findContours,
            drawRect,

        }
        public int selectIndex;
        /// <summary>
        /// 实现双击启动处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            selectIndex = listBox1.SelectedIndex;
            handle(selectIndex);
        }
        
        

        /// <summary>
        /// 二值化Tbar处理函数
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="userdata"></param>
        public void binary(int pos, object userdata)
        {

            Mat a = (Mat)userdata;
            Mat b = new Mat();
            a.CopyTo(b);
            Cv2.Threshold(b, b, pos * 25, 255, ThresholdTypes.Binary);
            Cv2.ImShow("二值化处理", b);
            b.CopyTo(pictureMain);
            pictureShow.Image = pictureMain.ToBitmap();
            b.Release();
        }
        
        /// <summary>
        /// 高斯滤波
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="userdata"></param>
        public void gaussianBlur(int pos,object userdata)
        {
            Mat src = (Mat)userdata;
            Mat a = new Mat();
            src.CopyTo(a);

            Cv2.GaussianBlur(a, a, new OpenCvSharp.Size(pos*2+1, pos*2+1), 5);

            Cv2.ImShow("高斯滤波", a);
            a.CopyTo(pictureMain);
            pictureShow.Image = a.ToBitmap();
            a.Release();
        }
        /// <summary>
        /// 均值滤波
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="userdata"></param>
        public  void blur(int pos,object userdata)
        {
            Mat src = (Mat)userdata;
            Mat a = new Mat();
            src.CopyTo(a);

            Cv2.Blur(a, a, new OpenCvSharp.Size(pos+1, pos+1));

            Cv2.ImShow("均值滤波", a);
            a.CopyTo(pictureMain);
            pictureShow.Image = a.ToBitmap();
            a.Release();
        }

        public void medianBlur(int pos, object userdata)
        {
            Mat src = (Mat)userdata;
            Mat a = new Mat();
            src.CopyTo(a);
            Cv2.MedianBlur(a, a, pos*2+1);
            Cv2.ImShow("中值滤波", a);
            a.CopyTo(pictureMain);
            pictureShow.Image = a.ToBitmap();
            a.Release();
        }
        public void bilateralFilter(int pos, object userdata)
        {
            
            Mat src = (Mat)userdata;
            Mat a = new Mat();
            Mat b = new Mat();
            src.CopyTo(b);
            Cv2.BilateralFilter(b, a, pos*5 + 1, 100, 100);
            Cv2.ImShow("双边滤波", a);
            a.CopyTo(pictureMain);
            pictureShow.Image = a.ToBitmap();
            a.Release();
            b.Release();
        }
        public void canny(int pos,object userdata)
        {
            Mat src = (Mat)userdata;
            Mat a = new Mat();
            src.CopyTo(a);
            Cv2.Canny(a, a, pos * 25, pos * 25);
            Cv2.ImShow("canny边缘检测", a);
            a.CopyTo(pictureMain);
            pictureShow.Image = a.ToBitmap();
            a.Release();
            Thread.Sleep(50);
        }
        public void laplacian(int pos,object userdata)
        {
            Mat src=(Mat)userdata;
            Mat a = new Mat();
            src.CopyTo(a);
            Cv2.Laplacian(a, a, -1, pos*2 + 1);
            Cv2.ImShow("Laplacian边缘检测", a);
            a.CopyTo(pictureMain);
            pictureShow.Image = a.ToBitmap();
            a.Release();
        }
        public void dilate(int pos,object userdata)
        {
            Mat src = (Mat)userdata;
            Mat a = new Mat();
            src.CopyTo(a);
            Mat structureElement = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(pos * 2 + 1, pos * 2 + 1));
            Cv2.Dilate(a, a, structureElement);
            Cv2.ImShow("膨胀处理", a);
            a.CopyTo(pictureMain);
            pictureShow.Image = a.ToBitmap();
            a.Release();
        }
        public void erode(int pos,object userdata)
        {
            Mat src = (Mat)userdata;
            Mat a = new Mat();
            src.CopyTo(a);
            Mat structureElement = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(pos * 2 + 1, pos * 2 + 1));
            Cv2.Erode(a, a, structureElement);
            Cv2.ImShow("腐蚀处理", a);
            a.CopyTo(pictureMain);
            pictureShow.Image = a.ToBitmap();
            a.Release();
        }
        public void drawRect(int pos,object userdata)
        {
            Mat src = (Mat)userdata;
            Mat a = new Mat();
            Mat gray = new Mat();
            src.CopyTo(gray);
            if (gray.Channels()==3)
            {
                Cv2.CvtColor(gray, gray, ColorConversionCodes.BGR2GRAY);
            }
            gray.CopyTo(a);
            Cv2.Threshold(~a, a ,pos *25, 255, ThresholdTypes.Binary);
            //Cv2.Canny(a, a, pos*10, 255);
            HierarchyIndex[] hierarchy;
            OpenCvSharp.Point[][] coutours;
            Cv2.FindContours(a, out coutours,out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxNone);
            OpenCvSharp.Point[][] contours_ploy = new OpenCvSharp.Point[coutours.Length][];
            RotatedRect[] RotatedRect_ploy = new RotatedRect[coutours.Length];
            Rect[] rect_poly = new Rect[coutours.Length];
            for (int i = 0; i < coutours.Length; i++)
            {
                contours_ploy[i] = Cv2.ApproxPolyDP(coutours[i], 10, true);//计算凸包
                rect_poly[i] = Cv2.BoundingRect(coutours[i]);//最小外接矩形，我们不用，
                if (contours_ploy[i].Length>5)//拟合的线条数不少于5
                {
                    RotatedRect temp1 = Cv2.MinAreaRect(contours_ploy[i]);//最小外接矩形，能旋转
                    RotatedRect_ploy[i] = temp1;//将该矩形放入集合中
                }
            }
            Point2f[] pot = new Point2f[4];
            for (int i = 0; i < RotatedRect_ploy.Length; i++)
            {
                pot = RotatedRect_ploy[i].Points();
                double line1 = Math.Sqrt((pot[1].Y - pot[0].Y) * (pot[1].Y - pot[0].Y)+ (pot[1].X - pot[0].X) * (pot[1].X - pot[0].X));
                double line2=Math.Sqrt((pot[3].Y - pot[0].Y) * (pot[3].Y - pot[0].Y) + (pot[3].X - pot[0].X) * (pot[3].X - pot[0].X));
                if (line1*line2<9000)//太小直接pass
                {
                    continue;
                }

                for (int j = 0; j < 4; j++)
                {
                    Cv2.Line(pictureMain, (OpenCvSharp.Point)pot[j], (OpenCvSharp.Point)pot[(j + 1) % 4], Scalar.Green,3);
                }
            }
            Cv2.ImShow("最小外包矩形", a);
            pictureShow.Image = pictureMain.ToBitmap();
            a.Release();
        }
        public void handle(int selectIndex)
        {

            switch (selectIndex)
            {
                case (int)lb1_list.gray:
                    if (pictureMain.Channels() == 3)
                    {
                        Cv2.CvtColor(pictureMain, pictureMain, ColorConversionCodes.BGR2GRAY);
                        pictureShow.Image = pictureMain.ToBitmap();
                        display("灰度化");
                    }
                    else
                    {
                        MessageBox.Show("已是灰度图像，不要重复操作");
                    }
                    break;
                case (int)lb1_list.reverse:
                    pictureMain = ~pictureMain;
                    pictureShow.Image = pictureMain.ToBitmap();
                    display("反色");
                    break;
                case (int)lb1_list.binary:
                    Cv2.ImShow("二值化处理", pictureMain);
                    Mat temp0 = new Mat();
                    pictureMain.CopyTo(temp0);
                    CvTrackbarCallback2 ctbc0 = new CvTrackbarCallback2(binary);
                    CvTrackbar cvtb0 = new CvTrackbar("程度", "二值化处理", 0, 10, ctbc0, temp0);
                    display("二值化");
                    break;

                case (int)lb1_list.gaussianBlur:
                    Cv2.ImShow("高斯滤波", pictureMain);
                    Mat temp1 = new Mat();
                    pictureMain.CopyTo(temp1);

                    CvTrackbarCallback2 ctbc1 = new CvTrackbarCallback2(gaussianBlur);
                    CvTrackbar cvtb1 = new CvTrackbar("程度", "高斯滤波", 0, 10, ctbc1, temp1);

                    display("高斯滤波");
                    break;
                case (int)lb1_list.blur:
                    Cv2.ImShow("均值滤波", pictureMain);
                    Mat temp2 = new Mat();
                    pictureMain.CopyTo(temp2);

                    CvTrackbarCallback2 ctbc2 = new CvTrackbarCallback2(blur);
                    CvTrackbar cvtb2 = new CvTrackbar("程度", "均值滤波", 0, 10, ctbc2, temp2);

                    display("均值滤波");
                    break;
                case (int)lb1_list.medianBlur:
                    Cv2.ImShow("中值滤波", pictureMain);
                    Mat temp3 = new Mat();
                    pictureMain.CopyTo(temp3);

                    CvTrackbarCallback2 ctbc3 = new CvTrackbarCallback2(medianBlur);
                    CvTrackbar cvtb3 = new CvTrackbar("程度", "中值滤波", 0, 10, ctbc3, temp3);

                    display("中值滤波");
                    break;
                case (int)lb1_list.bilateralFilter:
                    Cv2.ImShow("双边滤波", pictureMain);
                    Mat temp4 = new Mat();
                    pictureMain.CopyTo(temp4);

                    CvTrackbarCallback2 crbc4 = new CvTrackbarCallback2(bilateralFilter);
                    CvTrackbar cvtb4 = new CvTrackbar("程度", "双边滤波", 0, 10, crbc4, temp4);

                    display("双边滤波");
                    break;
                case (int)lb1_list.canny:
                    Cv2.ImShow("canny边缘检测", pictureMain);
                    Mat temp_canny = new Mat();
                    pictureMain.CopyTo(temp_canny);
                    if (temp_canny.Channels() == 3)
                    {
                        Cv2.CvtColor(temp_canny, temp_canny, ColorConversionCodes.BGR2GRAY);
                    }
                    CvTrackbarCallback2 ctbc_canny = new CvTrackbarCallback2(canny);
                    CvTrackbar cvtb_canny = new CvTrackbar("程度", "canny边缘检测", 0, 10, ctbc_canny, temp_canny);
                    display("canny边缘检测");
                    break;
                case (int)lb1_list.carve:
                    if (pictureMain.Channels() != 1)
                    {
                        Cv2.CvtColor(pictureMain, pictureMain, ColorConversionCodes.BGR2GRAY);
                    }

                    for (int i = 0; i < pictureMain.Rows; i++)
                    {
                        for (int j = 0; j < pictureMain.Cols; j++)
                        {
                            int newP = 2 * pictureMain.Get<byte>(i, j) - pictureMain.Get<byte>(i, j + 1) - pictureMain.Get<byte>(i + 1, j)+100 ;

                            if (newP > 255)
                            {
                                newP = 255;
                            }
                            else if (newP < 0)
                            {
                                newP = 0;
                            }
                            pictureMain.Set(i, j, (byte)newP);
                        }
                    }
                    pictureShow.Image = pictureMain.ToBitmap();
                    display("浮雕");
                    break;
                case (int)lb1_list.rever_lr:
                    Mat imx_lr = new Mat(pictureMain.Size(), MatType.CV_32FC1);
                    Mat imy_lr = new Mat(pictureMain.Size(), MatType.CV_32FC1);
                    for (int i = 0; i < pictureMain.Rows; i++)
                    {
                        for (int j = 0; j < pictureMain.Cols; j++)
                        {
                            imx_lr.Set(i, j, (float)(pictureMain.Cols - j - 1));
                            imy_lr.Set(i, j, (float)i);
                        }
                    }
                    Cv2.Remap(pictureMain, pictureMain, imx_lr, imy_lr);
                    pictureShow.Image = pictureMain.ToBitmap();
                    display("左右反转");
                    break;
                case (int)lb1_list.rever_tb:
                    Mat imx_tb = new Mat(pictureMain.Size(), MatType.CV_32FC1);
                    Mat imy_tb = new Mat(pictureMain.Size(), MatType.CV_32FC1);
                    for (int i = 0; i < pictureMain.Rows; i++)
                    {
                        for (int j = 0; j < pictureMain.Cols; j++)
                        {
                            imx_tb.Set(i, j, (float)j);
                            imy_tb.Set(i, j, (float)(pictureMain.Rows - i - 1));
                        }
                    }
                    Cv2.Remap(pictureMain, pictureMain, imx_tb, imy_tb);
                    pictureShow.Image = pictureMain.ToBitmap();
                    display("上下反转");
                    break;
                case (int)lb1_list.sharp:
                    Mat mask = new Mat(new OpenCvSharp.Size(3, 3), MatType.CV_32FC1);
                    mask.Set<float>(0, 1, -1); mask.Set<float>(1, 0, -1); mask.Set<float>(1, 1, 5); mask.Set<float>(1, 2, -1); mask.Set<float>(2, 1, -1);
                    Mat temp_sharp = new Mat();
                    pictureMain.CopyTo(temp_sharp);
                    Cv2.Filter2D(pictureMain, temp_sharp, -1, mask);
                    Cv2.WaitKey(500);
                    temp_sharp.CopyTo(pictureMain);
                    pictureShow.Image = temp_sharp.ToBitmap();
                    display("锐化");
                    mask.Release();
                    temp_sharp.Release();
                    break;
                case (int)lb1_list.dilate:
                    Cv2.ImShow("膨胀处理", pictureMain);
                    Mat temp_dilate = new Mat();
                    pictureMain.CopyTo(temp_dilate);
                    CvTrackbarCallback2 ctbc_dilate = new CvTrackbarCallback2(dilate);
                    CvTrackbar cvtb_dilate = new CvTrackbar("程度", "膨胀处理", 0, 10, ctbc_dilate, temp_dilate);
                    display("膨胀");
                    break;
                case (int)lb1_list.erode:
                    Cv2.ImShow("腐蚀处理", pictureMain);
                    Mat temp_erode = new Mat();
                    pictureMain.CopyTo(temp_erode);
                    CvTrackbarCallback2 ctbc_erode = new CvTrackbarCallback2(erode);
                    CvTrackbar cvtb_erode = new CvTrackbar("程度", "腐蚀处理", 0, 10, ctbc_erode, temp_erode);
                    display("腐蚀");
                    break;
                case (int)lb1_list.gamma:
                    if (pictureMain.Channels() == 1)
                    {
                        Mat temp_gray = new Mat(pictureMain.Size(), MatType.CV_16UC1);
                        for (int i = 0; i < pictureMain.Rows; i++)
                        {
                            for (int j = 0; j < pictureMain.Cols; j++)
                            {
                                temp_gray.Set(i, j, Math.Abs(pictureMain.Get<byte>(i, j) * pictureMain.Get<byte>(i, j)));//因为pictureMain为8UC1，所以这里一定要使用<byte>,不能使用其他类型
                            }
                        }
                        Cv2.Normalize(temp_gray, temp_gray, 0, 255, NormTypes.MinMax);
                        Cv2.ConvertScaleAbs(temp_gray, temp_gray);
                        temp_gray.CopyTo(pictureMain);
                        pictureShow.Image = pictureMain.ToBitmap();
                        temp_gray.Release();
                    }
                    else
                    {
                        Mat temp_gamma = new Mat(pictureMain.Size(), MatType.CV_32FC3);
                        Vec3f channels = new Vec3f();
                        for (int i = 0; i < pictureMain.Rows; i++)
                        {
                            for (int j = 0; j < pictureMain.Cols; j++)
                            {
                                channels.Item0 = Math.Abs(pictureMain.Get<Vec3b>(i, j).Item0 * pictureMain.Get<Vec3b>(i, j).Item0);
                                channels.Item1 = Math.Abs(pictureMain.Get<Vec3b>(i, j).Item1 * pictureMain.Get<Vec3b>(i, j).Item1);
                                channels.Item2 = Math.Abs(pictureMain.Get<Vec3b>(i, j).Item2 * pictureMain.Get<Vec3b>(i, j).Item2);
                                temp_gamma.Set(i, j, channels);
                            }
                        }
                        Cv2.Normalize(temp_gamma, temp_gamma, 0, 255, NormTypes.MinMax);
                        Cv2.ConvertScaleAbs(temp_gamma, temp_gamma);
                        temp_gamma.CopyTo(pictureMain);
                        pictureShow.Image = pictureMain.ToBitmap();
                        temp_gamma.Release();
                    }
                    display("暗部增强");
                    break;
                case (int)lb1_list.log:
                    Mat[] temp_log = pictureMain.Split();
                    for (int i = 0; i < pictureMain.Rows; i++)
                    {
                        for (int j = 0; j < pictureMain.Cols; j++)
                        {
                            temp_log[0].Set(i, j, Math.Log(temp_log[0].Get<float>(i, j), 1.2));
                            temp_log[1].Set(i, j, Math.Log(temp_log[1].Get<float>(i, j), 1.2));
                            temp_log[2].Set(i, j, Math.Log(temp_log[2].Get<float>(i, j), 1.2));
                        }
                    }
                    Cv2.Merge(temp_log, pictureMain);
                    Cv2.Normalize(pictureMain, pictureMain, 0, 255, NormTypes.MinMax);
                    pictureShow.Image = pictureMain.ToBitmap();


                    display("亮部增强");
                    break;
                case (int)lb1_list.hist:
                    if (pictureMain.Channels() == 1)
                    {
                        Mat[] image = { pictureMain };
                        Mat temp_hist = pictureMain;
                        int[] channels = new int[] { 0 };
                        int[] histsize = new int[] { 256 };
                        Mat mask_hist = new Mat();
                        Mat hist = new Mat();
                        Rangef[] range = new Rangef[1];
                        range[0].Start = 0f;
                        range[0].End = 256f;
                        Cv2.CalcHist(image, channels, mask_hist, hist, 1, histsize, range);
                        Mat histImage = new Mat(256, 256, MatType.CV_8UC3);
                        double minValue, maxValue;
                        Cv2.MinMaxLoc(hist, out minValue, out maxValue);
                        for (int i = 0; i < 256; i++)
                        {
                            int len = (int)(hist.Get<float>(i) / maxValue * 256);
                            Cv2.Line(histImage, i, histImage.Rows, i, histImage.Rows - len, Scalar.White, 2);
                        }
                        Cv2.ImShow("灰度图像直方图", histImage);
                    }
                    else
                    {
                        Mat[] images = pictureMain.Split();
                        Mat[] bImage = { images[0] };
                        Mat[] gImage = { images[1] };
                        Mat[] rImage = { images[2] };

                        Mat mask_hist = new Mat();
                        Mat[] hists = { new Mat(), new Mat(), new Mat() };
                        int[] channels = { 0 };
                        int[] histSize = { 256 };
                        Rangef[] range = new Rangef[1];
                        range[0].Start = 0f;
                        range[0].End = 256f;
                        Cv2.CalcHist(bImage, channels, mask_hist, hists[0], 1, histSize, range);//dim为需要统计直方图通道的个数
                        Cv2.CalcHist(gImage, channels, mask_hist, hists[1], 1, histSize, range);
                        Cv2.CalcHist(rImage, channels, mask_hist, hists[2], 1, histSize, range);

                        Mat[] histImage = { new Mat(256, 256, MatType.CV_8UC3), new Mat(256, 256, MatType.CV_8UC3), new Mat(256, 256, MatType.CV_8UC3) };
                        Scalar[] color = { Scalar.Blue, Scalar.Green, Scalar.Red };
                        for (int i = 0; i < 3; i++)
                        {
                            double minVal = 0f;
                            double maxVal = 0f;
                            Cv2.MinMaxLoc(hists[i], out minVal, out maxVal);
                            for (int j = 0; j < 256; j++)
                            {
                                int len = (int)(hists[i].Get<float>(j) / maxVal * 256);
                                Cv2.Line(histImage[i], j, histImage[0].Rows, j, histImage[0].Rows - len, color[i], 2);
                            }
                        }
                        Cv2.ImShow("b", histImage[0]);
                        Cv2.ImShow("g", histImage[1]);
                        Cv2.ImShow("r", histImage[2]);
                    }
                    display("直方图显示");
                    break;
                case (int)lb1_list.findContours:
                    MessageBox.Show("假如卡死了，是计算量太大的缘故，请重新调整canny参数一参数二，默认参数一50，参数二150");
                    Mat temp_find = new Mat();
                    if (pictureMain.Channels() == 3)
                    {
                        Cv2.CvtColor(pictureMain, temp_find, ColorConversionCodes.BGR2GRAY);
                    }


                    Cv2.Canny(temp_find, temp_find, form2Num1, form2Num2);

                    HierarchyIndex[] hierarchy;
                    OpenCvSharp.Point[][] coutours;
                    Cv2.FindContours(temp_find, out coutours, out hierarchy, RetrievalModes.List, ContourApproximationModes.ApproxNone);
                    for (int i = 0; i < coutours.Length; i++)
                    {
                        Cv2.DrawContours(pictureMain, coutours, i, Scalar.RandomColor(), 1);
                    }
                    pictureShow.Image = pictureMain.ToBitmap();
                    display("绘制轮廓");
                    break;
                case (int)lb1_list.drawRect:
                    Cv2.ImShow("最小外包矩形", pictureMain);
                    Mat tempRect = new Mat();
                    pictureMain.CopyTo(tempRect);
                    CvTrackbarCallback2 crbc_rect = new CvTrackbarCallback2(drawRect);
                    CvTrackbar cvtb_rect = new CvTrackbar("程度", "最小外包矩形", 0, 20, crbc_rect, tempRect);
                    MessageBox.Show("这个处理内存占用巨大，不要拖动太多次");
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 图像处理后更新信息
        /// </summary>
        /// <param name="name"></param>
        public void display(string name)
        {
            textBox1.AppendText("\r\n图像运行"+ name+ "处理成功");
            textBox1.SelectionStart = this.textBox1.TextLength;
            textBox1.ScrollToCaret();
            listBox2.Items.Add(num + ". "+ name);
            num++;
        }


        private void initalBtn_Click(object sender, EventArgs e)
        {
            pictureMain = null;
            pictureShow.Image = null;
            num = 1;
            listBox2.Items.Clear();
            textBox1.Text = "以下为通知信息：";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureShow_Click(object sender, EventArgs e)
        {

        }
    }
}

