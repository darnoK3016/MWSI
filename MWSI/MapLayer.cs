using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace MWSI
{
    class MapLayer // klasa w ktorej sa przechowywane informacje danej warstwy
    {
        readonly string tempLayerPath;  //sciezka dostepu do obrazu
        Size panelSize; //wielkosc panelu potrzebna do wielkosci obrazu
        bool active; //flaga aktywnosci warstwy tzn czy jest zaznaczona na liscie
        double opacity; // wartosc przezroczystosci

        public MapLayer(string tempLayerPath, Size panelSize)
        {
            this.tempLayerPath = tempLayerPath;
            this.panelSize = panelSize;
            var layer = new PictureBox();
            active = false;
            opacity = 1;
        }

        public PictureBox GetLayer() //zwracanie PictureBoxa z obrazem
        {
            var layer = new PictureBox();
            layer.SizeMode = PictureBoxSizeMode.StretchImage;
            layer.Size = panelSize;
            layer.Image = new Bitmap(tempLayerPath);
            return layer;
        }

        public bool GetActive()
        {
            return active;
        }

        public void ChangeActive()
        {
            active = !active;
        }

        public void SetOpacity(double opacity)
        {
            this.opacity = opacity;
        }

        public double GetOpacity()
        {
            return opacity;
        }

    }
}
