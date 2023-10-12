using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szgya_nasa_20231012
{
    class Keres
    {
        public string Cim { get; set; }
        public DateTime KeresIdeje { get; set; }
        public string Lekerdezes { get; set; }
        public int AllapotKod { get; set; }
        public int ValaszMeret { get; set; }

        public bool Domain { get {
                string[] cimKomp = this.Cim.Split('.');
                int temp;
                bool isNum = int.TryParse(cimKomp.Last(), out temp);
                return !isNum;
            }
        }

        public Keres(string sor)
        {
            string[] adatok = sor.Split('*');
            this.Cim = adatok[0];
            //this.KeresIdeje = DateTime.Parse(adatok[1]);
            string[] datum1 = adatok[1].Split('/');
            string[] datum2 = datum1.Last().Split(':');
            this.Lekerdezes = adatok[2];
            this.KeresIdeje = DateTime.Parse($"{datum2[0]}/{datum1[1]}/{datum1[0]} {datum2[1]}:{datum2[2]}:{datum2[3]}");
            string[] meta = adatok[3].Split(' ');
            this.AllapotKod = int.Parse(meta[0]);
            this.ValaszMeret = meta[1][0] == '-' ? 0 : int.Parse(meta[1]);
        }
    }
}
