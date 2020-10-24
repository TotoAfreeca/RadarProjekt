using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarPO.Models
{
    public class FlightStage
    {
        private Point a;
        private Point b;
        private int flightHeight;
        private int flightSpeed;

        public Point A { get => this.a; set => this.a = value; }
        public Point B { get => this.b; set => this.b = value; }
        public int FlightHeight { get => this.flightHeight; set => this.flightHeight = value; }
        public int FlightSpeed { get => this.flightSpeed; set => this.flightSpeed = value; }

        public FlightStage(Point newA, Point newB, int height, int speed)
        {
            this.A = newA;
            this.B = newB;
            this.FlightHeight = height; 
            this.FlightSpeed = speed;
        }
        public FlightStage(FlightStage stage)
        {
            this.A = new Point(stage.A);
            this.B = new Point(stage.B);
            this.FlightHeight = stage.FlightHeight;
            this.FlightSpeed = stage.FlightSpeed;
        }
        public FlightStage()
        {

        }
    }
}
