using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace RESISTIVIDAD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SoundPlayer Sound;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //resistividad
            trackBar1.Maximum = 100;
            trackBar1.Minimum = 1;
            trackBar1.SmallChange = 1;
            trackBar1.LargeChange = 1;
            trackBar1.UseWaitCursor = false;
            //longitud
            trackBar2.Maximum = 200;
            trackBar2.Minimum = 1;
            trackBar2.SmallChange = 1;
            trackBar2.LargeChange = 1;
            trackBar2.UseWaitCursor = false;
            //area
            trackBar3.Maximum = 1500;
            trackBar3.Minimum = 1;
            trackBar3.SmallChange = 1;
            trackBar3.LargeChange = 1;
            trackBar3.UseWaitCursor = false;
            this.DoubleBuffered = true;
            //instancias 
            org1 = new PictureBox();
            org1.Image = pictureBox1.Image;//barra
            org2 = new PictureBox();
            org2.Image = pictureBox2.Image;//resistencia
            org3 = new PictureBox();
            org3.Image = pictureBox3.Image;//reisistividad
            org4 = new PictureBox();
            org4.Image = pictureBox4.Image;//longitud
            org5 = new PictureBox();
            org5.Image = pictureBox5.Image;//area
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int TB1 = trackBar1.Value;//asignamos el valor del trackbar a una variable de tipo entero(1-100),Resistividad
            double TBR = TB1 * (.01);//convertimos el valor del trackbar a punto decimal 1 =.01 y 100 = 1
            int TB3 = trackBar2.Value;//asignamos el valor del trackbar a una variable de tipo entero(1-200),Longitud
            double TBL = TB3 * (.1);//convertimos el valor del trackbar a punto decimal 1 =.1 y 200 = 20
            int TB4 = trackBar3.Value;//asignamos el valor del trackbar a una variable de tipo entero(1-150),Area
            double TBA = TB4 * (.01);//convertimos el valor del trackbar a punto decimal 1 =.01 y 1500 = 15
            double R1 = TBR * TBL;// la formula es P*L/A
            double R2 = R1 / TBA;


            label1.Text = "Resistencia =" + R2.ToString() + "Ω";// asignamos la resistencia del alambre al label(mostramos el resultado final)
            label2.Text = TBR.ToString() + "Ω cm";//asignamos la resistividad del trackbar al label
            label3.Text = TBL.ToString() + "cm";//asignamos la longitud del alambre al label
            label4.Text = TBA.ToString() + "cm²";//asignamos el area de alambre al label

            if (trackBar1.Value > 50)
            {
                pictureBox3.Image = Zoom3(org3.Image, new Size(trackBar1.Value, trackBar1.Value));//resisitividad aumenta
                pictureBox2.Image = Zoom3(org2.Image, new Size(trackBar1.Value, trackBar1.Value));//resistencia aumenta
            }
            if (trackBar1.Value < 50)
            {
                pictureBox3.Image = Zoom3(org3.Image, new Size(trackBar1.Value, trackBar1.Value));//resisitividad disminulle
                pictureBox2.Image = Zoom3(org2.Image, new Size(trackBar1.Value, trackBar1.Value));//resistencia disminulle
            }


        }
        Image Zoom1(Image img,Size size)
        {
            //anchura
            Bitmap bmp1 = new Bitmap(img, Convert.ToInt32(img.Width * size.Width/100), Convert.ToInt32(img.Height));
            Graphics g = Graphics.FromImage(bmp1);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp1;

        }
        Image Zoom2(Image img, Size size)
        {
            //altura
            Bitmap bmp2 = new Bitmap(img, Convert.ToInt32(img.Width), Convert.ToInt32(img.Height * size.Height/ 40));
            Graphics g = Graphics.FromImage(bmp2);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp2;

        }
        Image Zoom3(Image img, Size size)
        {
            //resistencia, longitud,resistividad
            Bitmap bmp3 = new Bitmap(img, Convert.ToInt32(img.Width + size.Width / 5), Convert.ToInt32(img.Height + size.Height / 4));
            Graphics g = Graphics.FromImage(bmp3);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp3;
        }

        Image Zoom4(Image img, Size size)
        {
            //area
            Bitmap bmp4 = new Bitmap(img, Convert.ToInt32(img.Width + size.Width / 40), Convert.ToInt32(img.Height + size.Height / 40));
            Graphics g = Graphics.FromImage(bmp4);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp4;
        }
        PictureBox org1;//barra
        PictureBox org2;//resistencia
        PictureBox org3;//resistividad
        PictureBox org4;//longitud
        PictureBox org5;//area
        
        private void trackBar2_Scroll(object sender, EventArgs e)//longitud
        {
            int TB1 = trackBar1.Value;
            double TBR = TB1 * (.01);
            int TB3 = trackBar2.Value;
            double TBL = TB3 * (.1);
            int TB4 = trackBar3.Value;
            double TBA = TB4 * (.01);
            double R1 = TBR * TBL;
            double R2 = R1 / TBA;


            label1.Text = "Resistencia =" + R2.ToString() + "Ω";
            label2.Text = TBR.ToString() + "Ω cm";
            label3.Text = TBL.ToString() + "cm";
            label4.Text = TBA.ToString() + "cm²";
            //ancho de la imagen

            if (trackBar2.Value > 75)
            {
                pictureBox4.Image = Zoom3(org4.Image, new Size(trackBar2.Value, trackBar2.Value));//longitud aumenta
                pictureBox1.Image = Zoom1(org1.Image, new Size(trackBar2.Value, trackBar2.Value));// barra aumenta
            }
            if (trackBar2.Value < 75)
            {
                pictureBox4.Image = Zoom3(org4.Image, new Size(trackBar2.Value, trackBar2.Value));//longitud disminulle
                pictureBox1.Image = Zoom1(org1.Image, new Size(trackBar2.Value, trackBar2.Value));//barra disminulle
            }
           
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            int TB1 = trackBar1.Value;
            double TBR = TB1 * (.01);
            int TB3 = trackBar2.Value;
            double TBL = TB3 * (.1);
            int TB4 = trackBar3.Value;
            double TBA = TB4 * (.01);
            double R1 = TBR * TBL;
            double R2 = R1 / TBA;


            label1.Text = "Resistencia =" + R2.ToString() + "Ω";
            label2.Text = TBR.ToString() + "Ω cm";
            label3.Text = TBL.ToString() + "cm";
            label4.Text = TBA.ToString() + "cm²";

            if (trackBar3.Value > 750)
            {
                pictureBox5.Image = Zoom4(org5.Image, new Size(trackBar3.Value, trackBar3.Value));//area aumenta
            }
            if (trackBar3.Value < 750)
            {
                pictureBox5.Image = Zoom4(org5.Image, new Size(trackBar3.Value, trackBar3.Value));//area disminulle
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Sound =  new SoundPlayer(Application.StartupPath + @"\songs\recharge.wav");
                Sound.Play();
                
                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            
            
        }

        
    }
}
