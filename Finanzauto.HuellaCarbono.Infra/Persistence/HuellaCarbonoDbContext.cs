using Finanzauto.HuellaCarbono.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Finanzauto.HuellaCarbono.Infra.Persistence
{
    public class HuellaCarbonoDbContext : DbContext
    {
        public HuellaCarbonoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Datos Iniciales
            List<identity> InitIdentities = new List<identity>();
            InitIdentities.Add(new identity
            {
                idnId = 1,
                idnDescription = "La huella de carbono por el uso de tu vehiculo lograría ser compensado con la siembra de @equivalence plántulas (árboles jóvenes) con una esperanza de vida de 10 años.",
                idnImage = "Arboles.png",
                idnEquivalence = 15,
                idnOrden = 1
            });
            InitIdentities.Add(new identity
            {
                idnId = 2,
                idnDescription = "La huella de carbono por el uso de tu vehiculo corresponde a cargar @equivalence teléfonos celulares inteligentes.",
                idnImage = "Celulares.png",
                idnEquivalence = 110352,
                idnOrden = 2
            });
            InitIdentities.Add(new identity
            {
                idnId = 3,
                idnDescription = "La huella de carbono por el uso de tu vehiculo corresponde a realizar aproximadamente @equivalence viajes de Bogotá a San Andrés en avión.",
                idnImage = "Viajes.png",
                idnEquivalence = 9,
                idnOrden = 3
            });
            InitIdentities.Add(new identity
            {
                idnId = 4,
                idnDescription = "La huella de carbono por el uso de tu vehiculo corresponde a mantener encendido aproximadamente @equivalence computadores durante 5 días a la semana, 9 horas al día, durante un año.",
                idnImage = "Computadores.png",
                idnEquivalence = 4.5,
                idnOrden = 4
            });
            InitIdentities.Add(new identity
            {
                idnId = 5,
                idnDescription = "La huella de carbono por el uso de tu vehiculo corresponde a producir @equivalence kg de carne de vaca.",
                idnImage = "Carne.png",
                idnEquivalence = 3.39,
                idnOrden = 5
            });
            #endregion

            modelBuilder.HasDefaultSchema("hhcc");
            modelBuilder.Entity<brand>(brands =>
            {
                brands.ToTable("Brands");
                brands.HasKey(p => p.brnId);
            });
            modelBuilder.Entity<type>(types =>
            {
                types.ToTable("Types");
                types.HasKey(p => p.typId);
            });
            modelBuilder.Entity<line>(lines =>
            {
                lines.ToTable("Lines");
                lines.HasKey(p => p.linId);
            });
            modelBuilder.Entity<brandType>(brandTypes =>
            {
                brandTypes.ToTable("BrandTypes");
                brandTypes.HasKey(p => p.brtId);
            });
            modelBuilder.Entity<fuel>(fuels =>
            {
                fuels.ToTable("Fuels");
                fuels.HasKey(p => p.fueId);
            });
            modelBuilder.Entity<identity>(identities =>
            {
                identities.ToTable("Identities");
                identities.HasKey(p => p.idnId);
                identities.HasData(InitIdentities);
            });
        }

        public DbSet<brand> Brands { get; set; }
        public DbSet<line> Lines { get; set; }
        public DbSet<type> Types { get; set; }
        public DbSet<brandType> BrandTypes { get; set; }
        public DbSet<fuel> Fuels { get; set; }
        public DbSet<identity> Identities { get; set; }
    }
}
