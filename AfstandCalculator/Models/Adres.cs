using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfstandCalculator.Models
{
    public class Adres
    {
        public int AdresId { get; set; }
        public string Straat { get; set; }
        public string Postcode { get; set; }
        public string Plaats { get; set; }
        public string Land { get; set; }
        public string Adresregel => $"{Straat}, {Postcode}, {Plaats}, {Land}";
    }
}
