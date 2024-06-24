using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Alunos.Data.Contexts
{
    public class DatabaseContext : DbContext
    {

        public virtual DbSet<UserModel> User { get; set; }
    
        public virtual DbSet<CentralSegurancaModel> Central { get; set; }
        public virtual DbSet<ChamadasModel> Chamadas { get; set; }

        public virtual DbSet<CameraSegurancaModel> Camera { get; set; }

        public virtual DbSet<SensorIncendioModel> Sensor { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Password).IsRequired(); 
                entity.Property(e => e.Role).IsRequired(); 
            });

            modelBuilder.Entity<CentralSegurancaModel>(entity =>
            {
                entity.ToTable("CentralSeguranca");
                entity.HasKey(e => e.CentralId);
                entity.Property(e => e.LigarBombeiro).IsRequired();
                entity.Property(e => e.LigarBombeiro).IsRequired(); 
                entity.Property(e => e.CameraId).IsRequired(); 
                entity.Property(e => e.SensorId).IsRequired(); 
                entity.HasOne(e => e.User)
                    .WithMany()
                    // Define a chave estrangeira
                    .HasForeignKey(e => e.UserId);

            });

            modelBuilder.Entity<ChamadasModel>(entity =>
            {
                entity.ToTable("Chamadas");
                entity.HasKey(e => e.LigacaoId);
                entity.Property(e => e.DataOcorrido).IsRequired();
                entity.Property(e => e.NumeroLigacao).IsRequired(); 
                entity.Property(e => e.CentralId).IsRequired(); 

            });


            modelBuilder.Entity<CameraSegurancaModel>(entity =>
            {
                entity.ToTable("CameraSeguranca");
                entity.HasKey(e => e.CameraId);
                entity.Property(e => e.DataFilmagem).IsRequired();
                entity.Property(e => e.VideoCamera).IsRequired(); 
            });

            modelBuilder.Entity<SensorIncendioModel>(entity =>
            {
                entity.ToTable("SensorIncendio");
                entity.HasKey(e => e.SensorId);
                entity.Property(e => e.ComodoSensor).IsRequired();
                entity.Property(e => e.AlertaSensor).IsRequired(); 
            });

          
        }

        



        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }
    }
}
