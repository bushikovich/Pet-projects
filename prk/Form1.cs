using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
namespace prk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool gr1;
        int xcentr = 600 / 2;
        int ycentr = 400 / 2;
        double funct(double x)
        {	
            int scale = (int)(numericUpDown1.Value);
            double size = 0.4 * scale;
            if ((x < 2 * size) && (x > size)) return (Math.Pow(x / size, 1.0 / 2) * Math.Sin(Math.Pow(x / size, 2)) - 1.3) / (Math.Pow(x / size, 1.0 / 3) + Math.Exp(2 * x / size) + Math.Abs(Math.Cos(x / size))) * size;
            else if (((x <= size) && (x > 0)) || ((x > -5 * size) && (x < 0))) return 1 / Math.Pow(x / size, 3) * size;
            else return Math.Pow(x, 2) / size;
        }
        void Graph1(int scale)
        {
            Pen pen1 = new Pen(Brushes.Black, 1);
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.NoClip;
            double size = 0.4 * scale;
            g.DrawLine(pen1, new Point(0, ycentr), new Point(pictureBox1.Width, ycentr));
            g.DrawLine(pen1, new Point(xcentr, 0), new Point(xcentr, pictureBox1.Height));
            for (int i = -(int)(xcentr / size); i < 0; i++)// разбивка ох
            {
                for (int j = 0; j <= pictureBox1.Height; j += 5)
                    g.DrawEllipse(pen1, (int)(xcentr + (size * i)), j, 1, 1);
                g.DrawLine(pen1, new Point((int)(xcentr + (size * i)), (int)(ycentr - 0.04 * scale)), new Point((int)(xcentr + (size * i)), (int)(ycentr + 0.04 * scale)));
                g.DrawString(i.ToString(), new Font("Calibri", 10), new SolidBrush(Color.Black), (float)(xcentr + (int)(size * i) - 5), (float)(ycentr + 6 / 100 * scale), drawFormat);
            }
            for (int i = 1; i <= (int)((pictureBox1.Width - xcentr) / size); i++)
            {
                for (int j = 0; j <= pictureBox1.Height; j += 5)
                    g.DrawEllipse(pen1, (int)(xcentr + (size * i)), j, 1, 1);
                g.DrawLine(pen1, new Point((int)(xcentr + (size * i)), (int)(ycentr - 0.04 * scale)), new Point((int)(xcentr + (size * i)), (int)(ycentr + 0.04 * scale)));
                g.DrawString(i.ToString(), new Font("Calibri", 10), new SolidBrush(Color.Black), (float)(xcentr + (int)(size * i) - 5), (float)(ycentr + 6 / 100 * scale), drawFormat);
            }
            for (int j = -(int)(ycentr / size); j < 0; j++)// разбивка оy
            {
                for (int i = 0; i <= pictureBox1.Width; i += 5)
                    g.DrawEllipse(pen1, i, (int)(ycentr + (size * j)), 1, 1);
                g.DrawLine(pen1, new Point((int)(xcentr - 0.04 * scale), (int)(ycentr + (size * j))), new Point((int)(xcentr + 0.04 * scale), (int)(ycentr + (size * j))));
                g.DrawString(j.ToString(), new Font("Calibri", 10), new SolidBrush(Color.Black), (float)(xcentr - 20 / 100 * scale), (float)(ycentr - (size * j) - 10), drawFormat);
            }
            for (int j = 1; j <= (int)(pictureBox1.Height - ycentr / size); j++)
            {
                for (int i = 0; i <= pictureBox1.Width; i += 5)
                    g.DrawEllipse(pen1, i, (int)(ycentr + (size * j)), 1, 1);
                g.DrawLine(pen1, new Point((int)(xcentr - 0.04 * scale), (int)(ycentr + (size * j))), new Point((int)(xcentr + 0.04 * scale), (int)(ycentr + (size * j))));
                g.DrawString(j.ToString(), new Font("Calibri", 10), new SolidBrush(Color.Black), (float)(xcentr - 20 / 100 * scale), (float)(ycentr - (size * j) - 10), drawFormat);
            }
            g.DrawLine(pen1, new Point(pictureBox1.Width - 15, ycentr + 25), new Point(pictureBox1.Width - 5, ycentr + 5));//x 
            g.DrawLine(pen1, new Point(pictureBox1.Width - 5, ycentr + 25), new Point(pictureBox1.Width - 15, ycentr + 5));
            g.DrawLine(pen1, new Point(xcentr + 5, 5), new Point(xcentr + 10, 15));//y
            g.DrawLine(pen1, new Point(xcentr + 10, 15), new Point(xcentr + 15, 5));
            g.DrawLine(pen1, new Point(xcentr + 10, 25), new Point(xcentr + 10, 15));
            g.DrawLine(pen1, new Point(xcentr, 0), new Point(xcentr - 5, 5));//стрелки
            g.DrawLine(pen1, new Point(xcentr, 0), new Point(xcentr + 5, 5));
            g.DrawLine(pen1, new Point(pictureBox1.Width, ycentr), new Point(pictureBox1.Width - 5, ycentr - 5));
            g.DrawLine(pen1, new Point(pictureBox1.Width, ycentr), new Point(pictureBox1.Width - 5, ycentr + 5));
            pen1.Color = Color.Red;
            for(int i = -xcentr; i < pictureBox1.Width-xcentr; i++)
                g.DrawEllipse(pen1, xcentr + i, (ycentr - (int)funct(i)), 1, 1);
        }
        void Graph2(int scale)
        {
            Pen pen1 = new Pen(Brushes.Black, 1);
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.NoClip;
            double size = 0.4 * scale;
            g.DrawLine(pen1, new Point(0, ycentr), new Point(pictureBox1.Width, ycentr));
            g.DrawLine(pen1, new Point(xcentr, 0), new Point(xcentr, pictureBox1.Height));
            for (int i = -(int)(xcentr / size); i < 0; i++)// разбивка ох
            {
                for (int j = 0; j <= pictureBox1.Height; j += 5)
                    g.DrawEllipse(pen1, (int)(xcentr + (size * i)), j, 1, 1);
                g.DrawLine(pen1, new Point((int)(xcentr + (size * i)), (int)(ycentr - 0.04 * scale)), new Point((int)(xcentr + (size * i)), (int)(ycentr + 0.04 * scale)));
                g.DrawString(i.ToString(), new Font("Calibri", 10), new SolidBrush(Color.Black), (float)(xcentr + (int)(size * i) - 5), (float)(ycentr + 6 / 100 * scale), drawFormat);
            }
            for (int i = 1; i <= (int)((pictureBox1.Width - xcentr) / size); i++)
            {
                for (int j = 0; j <= pictureBox1.Height; j += 5)
                    g.DrawEllipse(pen1, (int)(xcentr + (size * i)), j, 1, 1);
                g.DrawLine(pen1, new Point((int)(xcentr + (size * i)), (int)(ycentr - 0.04 * scale)), new Point((int)(xcentr + (size * i)), (int)(ycentr + 0.04 * scale)));
                g.DrawString(i.ToString(), new Font("Calibri", 10), new SolidBrush(Color.Black), (float)(xcentr + (int)(size * i) - 5), (float)(ycentr + 6 / 100 * scale), drawFormat);
            }
            for (int j = -(int)((pictureBox1.Height - ycentr) / size); j < 0; j++)// разбивка оy
            {
                for (int i = 0; i <= pictureBox1.Width; i += 5)
                    g.DrawEllipse(pen1, i, (int)(ycentr - (size * j)), 1, 1);
                g.DrawLine(pen1, new Point((int)(xcentr - 0.04 * scale), (int)(ycentr + (size * j))), new Point((int)(xcentr + 0.04 * scale), (int)(ycentr + (size * j))));
                g.DrawString(j.ToString(), new Font("Calibri", 10), new SolidBrush(Color.Black), (float)(xcentr - 20 / 100 * scale), (float)(ycentr - (size * j) - 10), drawFormat);
            }
            for (int j = 1; j <= (int)(ycentr / size); j++)
            {
                for (int i = 0; i <= pictureBox1.Width; i += 5)
                    g.DrawEllipse(pen1, i, (int)(ycentr - (size * j)), 1, 1);
                g.DrawLine(pen1, new Point((int)(xcentr - 0.04 * scale), (int)(ycentr + (size * j))), new Point((int)(xcentr + 0.04 * scale), (int)(ycentr + (size * j))));
                g.DrawString(j.ToString(), new Font("Calibri", 10), new SolidBrush(Color.Black), (float)(xcentr - 20 / 100 * scale), (float)(ycentr - (size * j) - 10), drawFormat);
            }
            g.DrawLine(pen1, new Point(pictureBox1.Width - 15, ycentr + 25), new Point(pictureBox1.Width - 5, ycentr + 5));//x 
            g.DrawLine(pen1, new Point(pictureBox1.Width - 5, ycentr + 25), new Point(pictureBox1.Width - 15, ycentr + 5));
            g.DrawLine(pen1, new Point(xcentr + 5, 5), new Point(xcentr + 10, 15));//y
            g.DrawLine(pen1, new Point(xcentr + 10, 15), new Point(xcentr + 15, 5));
            g.DrawLine(pen1, new Point(xcentr + 10, 25), new Point(xcentr + 10, 15));
            g.DrawLine(pen1, new Point(xcentr, 0), new Point(xcentr - 5, 5));//стрелки
            g.DrawLine(pen1, new Point(xcentr, 0), new Point(xcentr + 5, 5));
            g.DrawLine(pen1, new Point(pictureBox1.Width, ycentr), new Point(pictureBox1.Width - 5, ycentr - 5));
            g.DrawLine(pen1, new Point(pictureBox1.Width, ycentr), new Point(pictureBox1.Width - 5, ycentr + 5));
            pen1.Color = Color.Green;
            StreamReader sr = new StreamReader("input.txt");
            {
                string[] text; double x, y, x2, y2;
                while (!sr.EndOfStream)
                {
                    text = sr.ReadLine().Split(' ');
                    x = double.Parse(text[0], CultureInfo.InvariantCulture);
                    y = double.Parse(text[1], CultureInfo.InvariantCulture);
                    text = sr.ReadLine().Split(' ');
                    x2 = double.Parse(text[0], CultureInfo.InvariantCulture);
                    y2 = double.Parse(text[1], CultureInfo.InvariantCulture);
                    g.DrawLine(pen1, new Point(xcentr + (int)(x*size), ycentr - (int)(y*size)), new Point(xcentr + (int)(x2*size), ycentr - (int)(y2*size)));
                    //g.DrawEllipse(pen1, xcentr + (int)(x*size), ycentr - (int)(y*size), 1, 1);
                }
                sr.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int scale = (int)(numericUpDown1.Value);
            Graph1(scale);
            gr1 = true;
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            int scale = (int)(numericUpDown1.Value);
            if (gr1)
            {
                ycentr += (int)(0.4 * scale);
                Graph1(scale);
            }
            else
            {
                ycentr += (int)(0.4 * scale);
                Graph2(scale);
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            int scale = (int)(numericUpDown1.Value);
            if (gr1)
            {
                ycentr -= (int)(0.4 * scale);
                Graph1(scale);
            }
            else
            {
                ycentr -= (int)(0.4 * scale);
                Graph2(scale);
            }
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            int scale = (int)(numericUpDown1.Value);
            if (gr1)
            {
                xcentr -= (int)(0.4 * scale);
                Graph1(scale);
            }
            else
            {
                xcentr -= (int)(0.4 * scale);
                Graph2(scale);
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            int scale = (int)(numericUpDown1.Value);
            if (gr1)
            {
                xcentr += (int)(0.4 * scale);
                Graph1(scale);
            }
            else
            {
                xcentr += (int)(0.4 * scale);
                Graph2(scale);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int scale = (int)(numericUpDown1.Value);
            Graph2(scale);
            gr1 = false;
        }
    }
}
