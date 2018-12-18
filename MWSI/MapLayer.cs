using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MWSI
{
    class MapLayer
    {
        MouseEvents me;
        PictureBox layer;
        Size panelSize;
        public MapLayer(Size panelSize)
        {
            this.panelSize = panelSize;
            layer = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            layer.Size = panelSize;
            OpenFileDialog ofp = new OpenFileDialog();
            if (ofp.ShowDialog() == DialogResult.OK)
            {
                layer.Image = new Bitmap(ofp.FileName);           
                ofp.Dispose();
            }


        }

        public PictureBox getLayer()
        {
            return layer;
        }
    }
}
