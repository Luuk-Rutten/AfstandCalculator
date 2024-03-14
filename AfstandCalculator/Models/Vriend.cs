

namespace AfstandCalculator.Models
{
    public class Vriend
    {
       
        public int VriendId { get; set; }

        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Telefoon { get; set; }
        public string FullName => $"{Voornaam} {Achternaam}";
        public string Afbeelding { get; set;  } = "person.png";
        public string? Afstand { get; set; }

        public Adres Adres { get; set; }
        public int? AdresId { get; set; }

/*        public Vriend(string vn, string an, Adres adres)
        {
            Voornaam = vn;
            Achternaam = an;
            Adres = adres;


        }*/
    }
}