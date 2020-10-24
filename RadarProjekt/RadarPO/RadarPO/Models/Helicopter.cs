using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarPO.Models
{
    class Helicopter : Vehicle
    {
        public Helicopter(string name, List<FlightStage> newFlightPath) : base(name, newFlightPath)
        {
        }
        public override string ToString()
        {
            return "Helicopter";
        }
    }
}
