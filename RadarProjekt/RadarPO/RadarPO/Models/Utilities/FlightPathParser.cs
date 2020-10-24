using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RadarPO.Models.Windows.AddPlaneWindow;

namespace RadarPO.Models.Utilities
{
    public class FlightPathParser
    {

        //private static Dictionary<string, Point> airports = new Dictionary<string, Point>()
        //{
        //    {"Warsaw", new Point(1,1) },
        //    {"Paris", new Point(-100,-100) },
        //    {"Moscow", new Point(-200,300) }
        //};


        public List<FlightStage> ParseFlightStage(List<PreFlightStage> preList, List<Immobile> airportsList)
        {
            List<FlightStage> parsedFlightPath = new List<FlightStage>();

            Dictionary<string, Point> airports = new Dictionary<string, Point>();
            foreach(Immobile airport in airportsList)
            {
                airports.Add(airport.Name, airport.GetCoordinates());
            }

            foreach (PreFlightStage pre in preList)
            {
                FlightStage stage = new FlightStage(    new Point(airports[pre.A.Text]),
                                                        new Point(airports[pre.B.Text]),
                                                        Convert.ToInt32(pre.Height.Text),
                                                        Convert.ToInt32(pre.Speed.Text)
                                                        );
                parsedFlightPath.Add(stage);
            }
            parsedFlightPath.Add(new FlightStage(new Point(parsedFlightPath[0].B), new Point(parsedFlightPath[0].A), parsedFlightPath[0].FlightHeight, parsedFlightPath[0].FlightSpeed));
            return parsedFlightPath;
        }
    }
}
