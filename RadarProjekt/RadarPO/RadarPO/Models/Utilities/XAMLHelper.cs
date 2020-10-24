using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RadarPO.Models.Utilities
{
    class XAMLHelper
    {
        public static Button CreateButtonFromVehicle(int x, int y, string vehicleType)
        {
            Button button = new Button();
            Image finalImage = new Image();
            string imagePath = Environment.CurrentDirectory + @"\"+vehicleType+".png";
            finalImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
            button.Content = finalImage;
            button.Width = 30;
            button.Height = 30;
            button.Background = Brushes.Transparent;
            button.BorderBrush = Brushes.Transparent;
            button.Margin = new Thickness(x,0,0,y);


            return button;
            
        }


        public static Image CreateImageFromImmobile(Immobile immobile)
        {
            
            Image image = new Image();
            string imagePath = Environment.CurrentDirectory + @"\"+immobile.ImageFileName;
            image.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
            image.Width = 30;
            image.Height = 30;

            image.Margin = new Thickness(immobile.GetCoordinates().X, 0, 0, immobile.GetCoordinates().Y);

            return image;

        }
    }
}
