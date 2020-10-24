using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarPO.Models
{
    public class Map
    {
        public List<Immobile> Immobiles { get; set; }

        public Map(string MapPath)
        {
            Immobiles = new List<Immobile>();
            try
            {
                using (StreamReader sr = new StreamReader("Immobiles.txt"))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] separatedLine = line.Split(' ');
                        Immobiles.Add(new Immobile(separatedLine[0], separatedLine[1], new Point(int.Parse(separatedLine[2]),
                            int.Parse(separatedLine[3])), int.Parse(separatedLine[4]), separatedLine[5]));
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public List<Immobile> GetAirports()
        {
            return Immobiles.Where(a => a.Type.Equals("Airport")).ToList();
        }

        public List<Immobile> GetObjectsList()
        {
            return Immobiles.Where(a => !a.Type.Equals("Airport")).ToList();
        }
    }
}
