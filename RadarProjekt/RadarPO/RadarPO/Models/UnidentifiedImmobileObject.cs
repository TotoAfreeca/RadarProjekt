using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarPO.Models
{
    class UnidentifiedImmobileObject : Immobile
    { 
            public UnidentifiedImmobileObject(string type, string name, Point newCoordinates, int newHeight, string imageFileName) : base(type, name, newCoordinates, newHeight, imageFileName)
            {
            }
    }
}
