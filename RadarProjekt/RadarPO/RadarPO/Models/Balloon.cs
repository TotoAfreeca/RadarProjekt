using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarPO.Models
{
    class Balloon : Vehicle
    {
        public Balloon(string name, List<FlightStage> newFlightPath) : base(name, newFlightPath)
        {
        }
        public override string ToString()
        {
            return "Balloon";
        }
    }
}
