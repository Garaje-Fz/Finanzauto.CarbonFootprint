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
                idnName = "Compensacion en arboles.",
                idnDescription = "Compensado con la siembra de 15 plántulas (árboles jóvenes) asumiendo una esperanza de vida de 10 años.",
                idnImage = "Arboles",
                idnEquivalence = 15,
                idnOrden = 1
            });
            InitIdentities.Add(new identity
            {
                idnId = 2,
                idnName = "Consumo cargar celulares.",
                idnDescription = "Cargar 110352 teléfonos celulares inteligentes.",
                idnImage = "Celulares.",
                idnEquivalence = 110352,
                idnOrden = 2
            });
            InitIdentities.Add(new identity
            {
                idnId = 3,
                idnName = "Consumo viajes a San Andres.",
                idnDescription = "Realizar 9 viajes de Bogotá a San Andrés en avión..",
                idnImage = "Viajes.",
                idnEquivalence = 9,
                idnOrden = 3
            });
            InitIdentities.Add(new identity
            {
                idnId = 4,
                idnName = "Consumo en computadores.",
                idnDescription = "Mantener encendido 4,5 computadores durante 5 días a la semana, 9 horas al día, durante un año.",
                idnImage = "Computadores",
                idnEquivalence = 4.5,
                idnOrden = 4
            });
            InitIdentities.Add(new identity
            {
                idnId = 5,
                idnName = "Consumo en carne.",
                idnDescription = "Producir 3,39 kg de carne de vaca.",
                idnImage = "Carne",
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
