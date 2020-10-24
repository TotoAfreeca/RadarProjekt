using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarPO.Models
{
    class Sailplane : Vehicle
    {
        public Sailplane(string name, List<FlightStage> newFlightPath) : base(name, newFlightPath)
        {

        }
        public override string ToString()
        {
            return "Sailplane";
        }
    }
}
