using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarPO.Models
{
    public class VehicleType
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public VehicleType(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
