using System.Windows.Controls;

namespace RadarPO.Models.Windows
{
    public partial class AddPlaneWindow
    {
        public class PreFlightStage
        {
            ComboBox a;
            ComboBox b;
            TextBox height;
            TextBox speed;

            public ComboBox A { get => this.a; set => this.a = value; }
            public ComboBox B { get => this.b; set => this.b = value; }
            public TextBox Height { get => this.height; set => this.height = value; }
            public TextBox Speed { get => this.speed; set => this.speed = value; }
        }
    }
}
