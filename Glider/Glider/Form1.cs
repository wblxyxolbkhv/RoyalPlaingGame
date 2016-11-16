using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Glider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button2.Click += OnButtonChooseClick;
            button1.Click += OnButtonDoClick;
            buttonSave.Click += OnButtonSaveClick;
        }

        private void OnButtonSaveClick(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();

            image.Save(sfd.FileName);

            MessageBox.Show("Well done!");

        }

        private string filePath = null;
        private int deg=0;
        Bitmap image;
        private void OnButtonChooseClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            filePath = ofd.FileName;
            textBox1.Text = filePath;
            textBox1.ReadOnly = true;
            image = (Bitmap)Image.FromFile(filePath);
            pictureBox1.Image = image;
            pictureBox1.Refresh();

        }
        private void OnButtonDoClick(object sender, EventArgs e)
        {
            progressBar1.Maximum = image.Width;
            progressBar1.Value = 0;
            deg += Convert.ToInt32(textBox2.Text);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color c = image.GetPixel(i, j);
                    int B = c.B % deg > deg / 2 ? c.B - c.B % deg + deg: c.B - c.B % deg;
                    int R = c.R % deg > deg / 2 ? c.R - c.R % deg + deg : c.R - c.R % deg;
                    int G = c.G % deg > deg / 2 ? c.G - c.G % deg + deg : c.G - c.G % deg;
                    B = B > 255 ? 255 : B;
                    R = R > 255 ? 255 : R;
                    G = G > 255 ? 255 : G;
                    image.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
                progressBar1.Value ++;
            }
            pictureBox1.Image = image;
            pictureBox1.Refresh();
        }
    }
}
