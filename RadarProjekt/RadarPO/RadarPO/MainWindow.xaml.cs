using System;
using System.Collections.Generic;
using System.Windows;
using RadarPO.Models;
using RadarPO.Models.Utilities;
using RadarPO.Models.Windows;

namespace RadarPO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Refresher refresher = new Refresher();
        public Radar radar { get; set; }

        public MainWindow()
        {
            
            InitializeComponent();
            radar = new Radar();
            radar.RadarGrid = grid;
            radar.ActualMap = new Map("Immobiles.txt");

            foreach(Immobile immobile in radar.ActualMap.Immobiles)
            {
                radar.RadarGrid.Children.Add(XAMLHelper.CreateImageFromImmobile(immobile));
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            refresher.Stop();
        }
        private void Resume_Click(object sender, RoutedEventArgs e)
        {
            refresher.Start(radar);
        }

        private void Add_Plane_Click(object sender, RoutedEventArgs e)
        {
            refresher.Stop();
            AddPlaneWindow window = new AddPlaneWindow(this);
            window.ShowDialog();
        }
        private void Generate_Random_Playground(object sender, RoutedEventArgs e)
        {
            radar.GenerateVehicle();
        }
    }
}
