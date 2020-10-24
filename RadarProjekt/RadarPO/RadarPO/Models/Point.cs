using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarPO.Models
{
    public class Point
    {
        private int x;
        private int y;

        public Point(int newX, int newY)
        {
            this.x = newX;
            this.y = newY;
        }

        public Point(Point p)
        {
            this.x = p.X;
            this.y = p.Y;
        }

        public int X { get => this.x; set => this.x = value; }
        public int Y { get => this.y; set => this.y = value; }
    }
}
