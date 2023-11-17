using Meninas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meninas.Context
{
    public class MeninasContext : DbContext
    {
        public DbSet<User> Users { get; set; }  //Tabla users en la base de datos!
        public DbSet<Shift> Shifts { get; set; }

        // public DbSet<Cat> Cats { get; set; } Veremos si lo usamos

        public MeninasContext(DbContextOptions<MeninasContext> dbContextOptions) : base(dbContextOptions) //Pasando las opciones para configurar el context, llamando al constructor base *Herencia de linea 6*
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType); //Estamos discriminando usuarios por rol
            modelBuilder.Entity<Client>().HasData(
                new Client {
                Email= "cliente@gmail.com",
                Name= "Camilo",
                Id= 1, 
                UserType= "Client",
                Password= "123"
                }
                );
            modelBuilder.Entity<Sitter>().HasData(
                new Sitter {
                Email = "niñera@gmail.com",
                Name = "Camila",
                Id = 2,
                UserType = "Sitter",
                Password = "abc"
                }
                 );
            modelBuilder.Entity<Admin>().HasData(
               new Admin {
                Email = "admin@gmail.com",
                Name = "CamiloAdmin",
                Id = 3,
                UserType = "Admin",
                Password = "admin"
               }
               );
            modelBuilder.Entity<Shift>().HasData(
                new Shift
                {
                    Date= new DateTime(2023,11,17),
                    Description= "Gato verde",
                    Place= "italia 300",
                    Id= 1,
                });
            modelBuilder.Entity<Client>()
                .HasMany(cl=> cl.Shifts)
                .WithOne(sh=> sh.Client)    //Un cliente has many  tiene muchos shift donde un shift tiene un cliente con su foreignKey
                .HasForeignKey(sh=>sh.ClientId);

            modelBuilder.Entity<Sitter>()
                .HasMany(stt => stt.Shifts)   //Una niñear tiene muchos turnos donde un turno tiene una niñera con su foreignKey
                .WithOne()
                .HasForeignKey(sh => sh.SitterId);
        }
        
    }
}
