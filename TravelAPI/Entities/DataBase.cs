using Microsoft.EntityFrameworkCore;

namespace TravelAPI.Entities
{
    public class DataBase : DbContext
    {
        public DbSet<Hotel> Hotele { get; set; }
        public DbSet<Klient> Klienci {get;set;}
        public DbSet<Lokalizacja> Lokalizacje { get; set; }
        public DbSet<Pokoj> Pokoje { get; set; }
        public DbSet<Rezerwacja> Rezerwacje { get; set; }
        public DbSet<Wycieczka> Wycieczki { get; set; }


        public DataBase(DbContextOptions<DataBase> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pokoj>()
                .Property(p => p.HotelId)
                .IsRequired();
            modelBuilder.Entity<Hotel>()
                .Property(h => h.LokalizacjaId)
                .IsRequired();
            modelBuilder.Entity<Wycieczka>()
                .Property(w => w.RezerwacjaId)
                .IsRequired();
            modelBuilder.Entity<Wycieczka>()
                .Property(w => w.PokojId)
                .IsRequired();
            modelBuilder.Entity<Rezerwacja>()
                .Property(w => w.KlientId)
                .IsRequired();
        }
    }

}
