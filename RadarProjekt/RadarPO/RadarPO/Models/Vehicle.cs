using RadarPO.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RadarPO.Models
{
    public abstract class Vehicle
    {

        private string name;
        private Point actualPosition;
        private Point destinationPosition;
        private Button linkedButton;
        private string imagePath;
        private List<FlightStage> flightPath;
        private int stageCounter;
        

        public string Name { get => this.name; set => this.name = value; }
        public Point ActualPosition { get => this.actualPosition; set => this.actualPosition = value; }
        public Point DestinationPosition { get => this.destinationPosition; set => this.destinationPosition = value; }
        public Button LinkedButton { get => this.linkedButton; set => this.linkedButton = value; }
        public string ImagePath { get => this.imagePath; set => this.imagePath = value; }
        public List<FlightStage> FlightPath { get => this.flightPath; set => this.flightPath = value; }
        public int StageCounter { get => this.stageCounter; set => this.stageCounter = value; }

        public Vehicle(string name, List<FlightStage> newFlightPath)
        {
            this.Name = name;
            this.FlightPath = newFlightPath;
            this.ActualPosition = new Point(newFlightPath.ElementAt(0).A);
            this.DestinationPosition = new Point(newFlightPath.ElementAt(0).B);
            this.LinkedButton = XAMLHelper.CreateButtonFromVehicle(this.ActualPosition.X, this.ActualPosition.Y, this.ToString());
            System.Console.WriteLine("Hi, Im " + this.Name + "(" + ActualPosition.X + " , " + ActualPosition.Y + ")");
            foreach (FlightStage stage in this.FlightPath)
            {
                System.Console.WriteLine(stage.A.X + " " + stage.A.Y + " - " + stage.B.X + " " + stage.B.Y);
            }
            this.StageCounter = 0;
        }


        
        public void Move()
        {

            if ((this.ActualPosition.X == this.DestinationPosition.X) && (this.ActualPosition.Y == this.DestinationPosition.Y))
            {
                if (this.FlightPath.Count == 1)
                {
                    return;
                }
                else
                {
                    if (this.StageCounter < (this.FlightPath.Count -1))
                    {
                        this.StageCounter += 1;
                        this.DestinationPosition = new Point(this.FlightPath.ElementAt(this.StageCounter).B);
                    }
                    else
                    {
                        this.FlightPath.Reverse();
                        foreach (FlightStage stage in this.FlightPath)
                        {
                            Point tmp = stage.A;
                            stage.A = stage.B;
                            stage.B = tmp;
                        }
                        
                        StageCounter = 0;
                        this.DestinationPosition = new Point(this.FlightPath.ElementAt(this.StageCounter).B);
                        
                    }
                }
            }

            if (this.ActualPosition.X < this.DestinationPosition.X)
                this.ActualPosition.X += 1;
            if (this.ActualPosition.X > this.DestinationPosition.X)
                this.ActualPosition.X -= 1;
            if (this.ActualPosition.Y < this.DestinationPosition.Y)
                this.ActualPosition.Y += 1;
            if (this.ActualPosition.Y > this.DestinationPosition.Y)
                this.ActualPosition.Y -= 1;

            LinkedButton.Margin = new Thickness(this.ActualPosition.X, 0, 0, this.ActualPosition.Y);

        }
        public static Vehicle GetVehicleByOption(int option, string name, List<FlightStage> newFlightPath)
        {
            switch (option)
            {
                case 0: return new Plane(name, newFlightPath);
                case 1: return new Balloon(name, newFlightPath);
                case 2: return new Helicopter(name, newFlightPath);
                case 3: return new Sailplane(name, newFlightPath);
                default: return new Plane(name, newFlightPath);
            }
        }

        public void SetImage(string ImagePath)
        {

        }

        public string GetImagePath()
        {
            return ImagePath;
        }


    }
}
