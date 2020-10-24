using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RadarPO.Models
{
    public class Radar
    {

        private List<Vehicle> vehicles = new List<Vehicle>();
        private Map actualMap;
        private static Grid radarGrid;

        public List<Vehicle> Vehicles { get => vehicles; set => vehicles = value; }
        internal Map ActualMap { get => this.actualMap; set => this.actualMap = value; }
        public Grid RadarGrid { get => radarGrid; set => radarGrid = value; }

        //public Map GetMap()
        //{
        //    return ActualMap;
        //}

        public Map GetMap()
        {
            return ActualMap;
        }
        public void Sync()
        {
            MoveAll();
            CheckCollisions();
        }

        public void MoveAll()
        {
            foreach (Vehicle vehicle in Vehicles)
            {
                vehicle.Move();
            }
        }

        // Checking for dangarous collisions
        public void CheckCollisions()
        {
            int dangerousDistance = 5;
            Vehicle vehicleA;
            Vehicle vehicleB;
            try
            {
                for (int i = vehicles.Count - 1; i >= 0; i--)
                {
                    vehicleA = vehicles[i];
                    for (int n = i - 1; n >= 0; n--)
                    {
                        vehicleB = vehicles[n];
                        //Distance is multiplied by 2, because its being compared to sum of the positions X and Y
                        if (2 * dangerousDistance > Math.Abs(vehicleA.ActualPosition.X - vehicleB.ActualPosition.Y) +
                            Math.Abs(vehicleA.ActualPosition.Y - vehicleB.ActualPosition.Y) && vehicleA.FlightPath[vehicleA.StageCounter].FlightHeight == vehicleB.FlightPath[vehicleB.StageCounter].FlightHeight)
                        {
                            throw new CrushException(vehicleA, vehicleB);
                        }
                    }
                }
            }
            catch(CrushException e)
            {
                MessageBox.Show(e.CrushMessage);
                System.Windows.Application.Current.Shutdown();
            }
        }

        public void AddVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
            RadarGrid.Children.Add(vehicle.LinkedButton);
        }

        public void GenerateVehicle()
        {

            List<FlightStage> randomFlightPath = new List<FlightStage>();
            Random random = new Random();
            List<Immobile> airports = ActualMap.GetAirports();
            int numberOfAirports = airports.Count() - 1;
            for (int i = random.Next(0, 5); i >= 0; i--)
            {
                //Tutaj dodać odwołanie do airportów    tu                tu
                randomFlightPath.Add(new FlightStage(ActualMap.Immobiles[random.Next(0, numberOfAirports)].GetCoordinates(), ActualMap.Immobiles[random.Next(0, numberOfAirports)].GetCoordinates(), random.Next(1, 10), random.Next(1, 5)));
            }

            int randomVehicle = random.Next(0, 3);
            Vehicle vehicle = Vehicle.GetVehicleByOption(randomVehicle, "random", randomFlightPath);
            AddVehicle(vehicle);
        }

        public void WriteWarning(string warningName)
        {

        }
    }
}
