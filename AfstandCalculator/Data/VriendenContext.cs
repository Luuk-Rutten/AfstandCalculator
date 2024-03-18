using Microsoft.EntityFrameworkCore;
using AfstandCalculator.Models;

namespace AfstandCalculator.Data
{
    public class VriendenContext : DbContext
    {

        public DbSet<Vriend> Vrienden { get; set; }
        public DbSet<Adres> Adressen { get; set; }

        public VriendenContext(DbContextOptions<VriendenContext> options) : base(options)
        {
           //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public void EnsureDatabaseCreated()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vriend>()
            .HasOne(p => p.Adres)
            .WithMany()
            .HasForeignKey(p => p.AdresId)
            .OnDelete(DeleteBehavior.SetNull);//Een Vriend hoeft geen adres te hebben. Om een adres te kunnen verwijderen wordt de gemeenschappelijke sleutel op null gezet


            var v1 = new Vriend { VriendId=1, Voornaam="Frits", Achternaam = "Spits", Telefoon = "06-111222333", AdresId = 1 };
            var v2 = new Vriend { VriendId=2, Voornaam="Dafne", Achternaam = "Van der Poel", Telefoon = "06-22222222", AdresId = 2 };
            var v3 = new Vriend { VriendId=3, Voornaam="Karel", Achternaam = "Schepers", Telefoon = "06-33333333", AdresId = 3 };
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vriend>().HasData(
                v1, v2, v3
           );

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Adres>().HasData(
                new Adres { AdresId=1, Straat="Nieuw Eyckholt", Postcode = "6419DJ", Plaats="Heerlen", Land = "the Netherlands" },
                new Adres { AdresId=2, Straat="Herdenkingsplein 12", Postcode = "6211PW", Plaats="Maastricht", Land = "the Netherlands" },
                new Adres { AdresId=3, Straat="Ligne 1", Postcode = "6131MT", Plaats="Sittard", Land = "the Netherlands" }
                );

        }
    }
}