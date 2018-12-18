using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MWSI
{
    public class MouseEvents
    {

        bool clicked = false;
        bool entered = false;
        Point clickedPoint;
        PictureBox map;
        readonly float zoom = 1.1f;
        Size panelSize;

        public MouseEvents(PictureBox map, Size panelSize)
        {
            this.map = map;
            this.panelSize = panelSize;
        }

        public void Maps_Down(object sender, MouseEventArgs e)
        {
            clicked = true;
            clickedPoint = e.Location;
        }

        public void Maps_Up(object sender, MouseEventArgs e)
        {
            clicked = false;
        }

        public void Maps_Enter(object sender, EventArgs e)
        {
            entered = true;
        }

        public void Maps_Left(object sender, EventArgs e)
        {
            entered = false;
        }

        public void Maps_Move(object sender, MouseEventArgs e)
        {
            if (clicked && entered)
            {
                int x = clickedPoint.X - e.X;
                int y = clickedPoint.Y - e.Y;
                Point moveLocation = new Point(map.Location.X - x, map.Location.Y - y);
                if ((map.Location.X - x) <0 && (map.Location.Y - y) < 0 &&
                    (map.Location.X + map.Size.Width - x) > panelSize.Width && (map.Location.Y + map.Size.Height - y) > panelSize.Height)
                {
                    map.Location = new Point(map.Location.X - x, map.Location.Y - y);
                }
            }

        }

        public void Maps_Zoom(object sender, MouseEventArgs e)
        {
            if (entered)
            {
                if (e.Delta > 0)
                {
                    map.Size = new Size((int)(map.Width * zoom), (int)(map.Height * zoom));
                    map.Left = map.Left - (int)((e.X - map.Left) * (zoom - 1));
                    map.Top = map.Top - (int)((e.Y - map.Top) * (zoom - 1));
                }
                else if (e.Delta < 0 && map.Size.Width > panelSize.Width && map.Size.Height > panelSize.Height)
                {
                    map.Size = new Size((int)(map.Width / zoom), (int)(map.Height / zoom));
                    map.Left = map.Left - (int)((e.X - map.Left) * (1 / zoom - 1));
                    map.Top = map.Top - (int)((e.Y - map.Top) * (1 / zoom - 1));
                }
            }

        }
    }
}
