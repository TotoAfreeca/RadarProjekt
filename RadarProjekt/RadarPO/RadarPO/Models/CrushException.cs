using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RadarPO.Models
{
    class CrushException : Exception
    {
        public string CrushMessage { get; private set; }
        public CrushException(Vehicle a, Vehicle b)
        {
            string message = string.Format("{0} właśnie zderzył się z {1}! Pojazdy nie przetrwały! (Program się wyłączy bo zostałeś wyrzucony z pracy)",
                a.ToString() + " " + a.Name,
                a.ToString() + " " + a.Name);
            this.CrushMessage = message;
        }
    }
}
