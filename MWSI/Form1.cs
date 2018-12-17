using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWSI
{
    public partial class Form1 : Form
    {
        Size ImageSize;
        List<PictureBox> Maps = new List<PictureBox>();
        public static float value = 1.0f;
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Layer()
        {
            PictureBox pb = new PictureBox();
            ImageSize = new Size(pb.Size.Height, pb.Size.Height);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Size = flowLayoutPanel1.Size;
            ImageSize = new Size(pb.Size.Height, pb.Size.Height);

            OpenFileDialog ofp = new OpenFileDialog();
            if (ofp.ShowDialog() == DialogResult.OK)
            {
                pb.Image = new Bitmap(ofp.FileName);
                Maps.Add(pb);

                flowLayoutPanel1.Controls.Add(pb);
            }

            

            

            this.MouseWheel += flowLayoutPanel1_MouseWheel;

           


        }


        private void cADRGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Layer();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Size = new Size(Width-180, Height-63);
            Maps.ElementAt(0).Size = flowLayoutPanel1.Size;
        }

        private void flowLayoutPanel1_MouseWheel(object sender, MouseEventArgs e)
        {
            PictureBox pb = Maps.ElementAt(0);
            if(e.Delta > 0)
            {
                value+=0.1f;
                pb.Size = new Size((int)(ImageSize.Height * value), (int)(ImageSize.Width * value));
            }
            else if (e.Delta < 0)
            {
                
                if (value > 0)
                {
                    value-=0.1f;
                    pb.Size = new Size((int)(ImageSize.Height * value), (int)(ImageSize.Width * value));

                }
                else value = 0;
            }
            
        }

    }
}
