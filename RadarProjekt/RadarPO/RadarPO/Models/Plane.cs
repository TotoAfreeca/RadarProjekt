using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarPO.Models
{
    class Plane : Vehicle
    {
        public Plane(string name, List<FlightStage> newFlightPath) : base(name, newFlightPath)
        {

        }
        public override string ToString()
        {
            return "Plane";
        }
    }
}
