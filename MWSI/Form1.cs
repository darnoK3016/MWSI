using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace MWSI
{
    public partial class Form1 : Form
    {
        List<PictureBox> Maps = new List<PictureBox>();
        MouseEvents me;
        PictureBox layer;
        public Form1()
        {
            InitializeComponent();
            this.Scroll += new ScrollEventHandler(hScrollBar1_Scroll);
            hScrollBar1.Value = 100;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Layers()
        {

            MapLayer layer = new MapLayer(panel1.Size);
            Maps.Add(layer.getLayer());
            panel1.Controls.Add(layer.getLayer());
            checkedListBox1.Items.Add(layer);

            Maps.ForEach((c) =>
            {
                me = new MouseEvents(c, panel1.Size);
                c.MouseEnter += new EventHandler(me.Maps_Enter);
                c.MouseLeave += new EventHandler(me.Maps_Left);
                c.MouseDown += new MouseEventHandler(me.Maps_Down);
                c.MouseUp += new MouseEventHandler(me.Maps_Up);
                c.MouseMove += new MouseEventHandler(me.Maps_Move);
            });


            this.MouseWheel += new MouseEventHandler(me.Maps_Zoom);

            this.Scroll += hScrollBar1_Scroll;

            /*
            layer = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            OpenFileDialog ofp = new OpenFileDialog();
            if (ofp.ShowDialog() == DialogResult.OK)
            {
                layer.Image = new Bitmap(ofp.FileName);
                Maps.Add(layer);
                panel1.Controls.Add(layer);
                ofp.Dispose();
            }

            me = new MouseEvents(layer, panel1.Size);
            this.MouseWheel += new MouseEventHandler(me.Maps_Zoom);
            layer.MouseEnter += new EventHandler(me.Maps_Enter);
            layer.MouseLeave += new EventHandler(me.Maps_Left);
            layer.MouseDown += new MouseEventHandler(me.Maps_Down);
            layer.MouseUp += new MouseEventHandler(me.Maps_Up);
            layer.MouseMove += new MouseEventHandler(me.Maps_Move);
            this.Scroll += hScrollBar1_Scroll;*/
        }

        private void CADRGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Layers();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            panel1.Size = new Size(Width - 180, Height - 63);
            Maps.ForEach((c) =>
            {
                c.Size = panel1.Size;
            });
            
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            PictureBox pb = Maps.ElementAt(0);
            if (hScrollBar1.Value <= 0) hScrollBar1.Value = 1;

            pb.Image = Transparency(pb.Image, (byte)hScrollBar1.Value);
        }
        public static Bitmap Transparency(Image img, byte alpha)
        {
            Bitmap imgOrg = new Bitmap(img);
            Bitmap imgT = new Bitmap(img.Width, img.Height);
            Color c;
            Color v;

            for (int x = 0; x < img.Width; x++)
                for (int y = 0; y < img.Height; y++)
                {
                    c = imgOrg.GetPixel(x, y);
                    if (c.A > 0)
                    {
                        v = Color.FromArgb((int)(alpha * 2.55), c.R, c.G, c.B);
                        imgT.SetPixel(x, y, v);
                    }
                }
            return imgT;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i< checkedListBox1.CheckedIndices.Count; i++)
            {
                panel1.Controls.RemoveAt(checkedListBox1.CheckedIndices[i]);
                checkedListBox1.Items.RemoveAt(checkedListBox1.CheckedIndices[i]);
            }
            panel1.Refresh();
        }
    }
}
