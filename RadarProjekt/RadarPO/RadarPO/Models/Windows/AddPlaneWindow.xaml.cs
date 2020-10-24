using RadarPO.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace RadarPO.Models.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddPlaneWindow.xaml
    /// </summary>
    public partial class AddPlaneWindow : Window
    {
        public List<VehicleType> VehicleTypes { get; set; }
        public MainWindow ParentWindow { get; set; }

        List<PreFlightStage> rows = new List<PreFlightStage>();
        private List<PreFlightStage> PreFlightPath { get => this.rows; set => this.rows = value; }



        public AddPlaneWindow(MainWindow parentWindow)
        {
            InitializeComponent();

            ParentWindow = parentWindow;
            MakeFlightStage();
         
            VehicleTypes = new List<VehicleType>();
            VehicleTypes.Add(new VehicleType("Plane", 0));
            VehicleTypes.Add(new VehicleType("Balloon", 1));
            VehicleTypes.Add(new VehicleType("Helicopter", 2));
            VehicleTypes.Add(new VehicleType("Sailplane", 3));
            VehicleTypeComboBox.ItemsSource = VehicleTypes;
            VehicleTypeComboBox.DisplayMemberPath = "Name";
            VehicleTypeComboBox.SelectedValuePath = "Value";
            VehicleTypeComboBox.SelectedValue = 0;
        }


        private int numberOfRows = 0;
        void MakeFlightStage()
        {
            PreFlightStage preStage = new PreFlightStage();
            
            if (numberOfRows == 0)
            {
                preStage.A = MakeComboBox();
                preStage.A.SelectedIndex = 0;


                preStage.B = MakeComboBox();
                preStage.B.SelectedIndex = 1;
            }
            else
            {
                preStage.A = PreFlightPath[numberOfRows - 1].B;
                preStage.B = MakeComboBox();
                preStage.B.Margin = new Thickness(100, 0, 0, 0);
                preStage.B.SelectedIndex = PreFlightPath[numberOfRows - 1].A.SelectedIndex;
            }

            preStage.Height = MakeTextBox();
            preStage.Speed = MakeTextBox();

      
           
           StackPanel stackPanel = new StackPanel() { Orientation = Orientation.Horizontal };
            if(this.numberOfRows == 0)
                stackPanel.Children.Add(preStage.A);

            stackPanel.Children.Add(preStage.B);
            stackPanel.Children.Add(preStage.Height);
            stackPanel.Children.Add(preStage.Speed);

            this.PreFlightPath.Add(preStage);

            this.ListOfStages.Children.Add(stackPanel); // ListOfStage - w xamlu
            this.numberOfRows += 1;
        }

        private ComboBox MakeComboBox()
        {
            ComboBox cbox = new ComboBox() { Width = 100 };
            foreach (Immobile airport in ParentWindow.radar.ActualMap.GetAirports())
                cbox.Items.Add(new ComboBoxItem() { Content = airport.Name});


            return cbox;
        }

        private TextBox MakeTextBox()
        {
            TextBox textBox = new TextBox() { Text = "1", Width = 100 };
            textBox.PreviewTextInput += NumberValidationTextBox;
            return textBox;
        }

        private void Add_Flight_Stage(object sender, RoutedEventArgs e)
        {
            this.MakeFlightStage();
        }

        private void Add_Plane(object sender, RoutedEventArgs e)
        {
            foreach(PreFlightStage preStage in PreFlightPath)
            {
                System.Console.WriteLine(preStage.A.Text + " - " + preStage.B.Text);
            }
            FlightPathParser parser = new FlightPathParser();

            Vehicle samolocik = Vehicle.GetVehicleByOption((int)VehicleTypeComboBox.SelectedValue, "lol", parser.ParseFlightStage((this.PreFlightPath), ParentWindow.radar.ActualMap.GetAirports()));

            this.ParentWindow.radar.AddVehicle(samolocik);
            this.PreFlightPath.Clear();
            this.Close();
        }

        

       
         private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
         {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
         }

        private void VehicleTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string imagePath = Environment.CurrentDirectory;
 
            VehicleIcon.Width = 30;
            VehicleIcon.Height = 30;
            VehicleIcon.Source = new BitmapImage(new Uri(imagePath+@"/"+VehicleTypeComboBox.SelectedItem.ToString()+".png", UriKind.Absolute));
           
        }
    }
}
