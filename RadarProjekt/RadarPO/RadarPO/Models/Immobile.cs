using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarPO.Models
{
    public class Immobile
    {
        public string Type { get; set; }
        public string Name { get; set; }
        private Point Coordinates;
        private int Height;
        public string ImageFileName { get; private set; }
        public Immobile(string type, string name, Point newCoordinates, int newHeight, string imageFileName)
        {
            Type = type;
            Name = name;
            Coordinates = newCoordinates;
            Height = newHeight;
            ImageFileName = imageFileName;
        }

        public Point GetCoordinates()
        {
            return Coordinates;
        }
        public int GetHeight()
        {
            return Height;
        }
    }
}
