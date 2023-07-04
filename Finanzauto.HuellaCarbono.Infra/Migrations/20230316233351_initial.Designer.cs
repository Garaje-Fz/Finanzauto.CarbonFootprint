﻿// <auto-generated />
using System;
using Finanzauto.HuellaCarbono.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Finanzauto.HuellaCarbono.Infra.Migrations
{
    [DbContext(typeof(HuellaCarbonoDbContext))]
    [Migration("20230316233351_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("hhcc")
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Finanzauto.HuellaCarbono.Domain.brand", b =>
                {
                    b.Property<int>("brnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("brnId"));

                    b.Property<string>("brnName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("brnId");

                    b.ToTable("Brands", "hhcc");
                });

            modelBuilder.Entity("Finanzauto.HuellaCarbono.Domain.brandType", b =>
                {
                    b.Property<int>("brtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("brtId"));

                    b.Property<int>("brnId")
                        .HasColumnType("int");

                    b.Property<int>("typId")
                        .HasColumnType("int");

                    b.HasKey("brtId");

                    b.HasIndex("brnId");

                    b.HasIndex("typId");

                    b.ToTable("BrandTypes", "hhcc");
                });

            modelBuilder.Entity("Finanzauto.HuellaCarbono.Domain.fuel", b =>
                {
                    b.Property<int>("fueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("fueId"));

                    b.Property<string>("fueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("fueId");

                    b.ToTable("Fuels", "hhcc");
                });

            modelBuilder.Entity("Finanzauto.HuellaCarbono.Domain.identity", b =>
                {
                    b.Property<int>("idnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idnId"));

                    b.Property<string>("idnDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("idnEquivalence")
                        .HasColumnType("float");

                    b.Property<string>("idnImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idnOrden")
                        .HasColumnType("int");

                    b.HasKey("idnId");

                    b.ToTable("Identities", "hhcc");

                    b.HasData(
                        new
                        {
                            idnId = 1,
                            idnDescription = "La huella de carbono por el uso de tu vehiculo lograría ser compensado con la siembra de @equivalence plántulas (árboles jóvenes) con una esperanza de vida de 10 años.",
                            idnEquivalence = 15.0,
                            idnImage = "Arboles.png",
                            idnOrden = 1
                        },
                        new
                        {
                            idnId = 2,
                            idnDescription = "La huella de carbono por el uso de tu vehiculo corresponde a cargar @equivalence teléfonos celulares inteligentes.",
                            idnEquivalence = 110352.0,
                            idnImage = "Celulares.png",
                            idnOrden = 2
                        },
                        new
                        {
                            idnId = 3,
                            idnDescription = "La huella de carbono por el uso de tu vehiculo corresponde a realizar aproximadamente @equivalence viajes de Bogotá a San Andrés en avión.",
                            idnEquivalence = 9.0,
                            idnImage = "Viajes.png",
                            idnOrden = 3
                        },
                        new
                        {
                            idnId = 4,
                            idnDescription = "La huella de carbono por el uso de tu vehiculo corresponde a mantener encendido aproximadamente @equivalence computadores durante 5 días a la semana, 9 horas al día, durante un año.",
                            idnEquivalence = 4.5,
                            idnImage = "Computadores.png",
                            idnOrden = 4
                        },
                        new
                        {
                            idnId = 5,
                            idnDescription = "La huella de carbono por el uso de tu vehiculo corresponde a producir @equivalence kg de carne de vaca.",
                            idnEquivalence = 3.3900000000000001,
                            idnImage = "Carne.png",
                            idnOrden = 5
                        });
                });

            modelBuilder.Entity("Finanzauto.HuellaCarbono.Domain.line", b =>
                {
                    b.Property<int>("linId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("linId"));

                    b.Property<string>("EmisionesCO2_GrKm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("brnId")
                        .HasColumnType("int");

                    b.Property<string>("codigoFasecolda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("fueId")
                        .HasColumnType("int");

                    b.Property<string>("huellaCarbono_TonKm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("linDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("linYear")
                        .HasColumnType("int");

                    b.Property<int>("typId")
                        .HasColumnType("int");

                    b.HasKey("linId");

                    b.HasIndex("brnId");

                    b.HasIndex("fueId");

                    b.HasIndex("typId");

                    b.ToTable("Lines", "hhcc");
                });

            modelBuilder.Entity("Finanzauto.HuellaCarbono.Domain.record", b =>
                {
                    b.Property<int>("recId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("recId"));

                    b.Property<int>("linId")
                        .HasColumnType("int");

                    b.Property<double>("recCalculateTnKm")
                        .HasColumnType("float");

                    b.Property<DateTime>("recCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("recEmisionGrKm")
                        .HasColumnType("float");

                    b.Property<double>("recEmisionTnKm")
                        .HasColumnType("float");

                    b.Property<int>("recKm")
                        .HasColumnType("int");

                    b.HasKey("recId");

                    b.HasIndex("linId");

                    b.ToTable("Records", "hhcc");
                });

            modelBuilder.Entity("Finanzauto.HuellaCarbono.Domain.type", b =>
                {
                    b.Property<int>("typId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("typId"));

                    b.Property<int>("averague")
                        .HasColumnType("int");

                    b.Property<string>("typName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("typId");

                    b.ToTable("Types", "hhcc");
                });

            modelBuilder.Entity("Finanzauto.HuellaCarbono.Domain.user", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<string>("usrEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usrLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usrName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usrPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usrUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", "hhcc");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreate = new DateTime(2023, 3, 16, 18, 33, 51, 416, DateTimeKind.Local).AddTicks(6329),
                            DateUpdate = new DateTime(2023, 3, 16, 18, 33, 51, 416, DateTimeKind.Local).AddTicks(6340),
                            State = true,
                            usrEmail = "elgaraje@finanzauto.com.co",
                            usrLastName = "S.A.",
                            usrName = "Finanzauto",
                            usrPassword = "NewEfRiB.#23",
                            usrUserName = "DevNovedades"
                        });
                });

            modelBuilder.Entity("Finanzauto.HuellaCarbono.Domain.brandType", b =>
                {
                    b.HasOne("Finanzauto.HuellaCarbono.Domain.brand", "fkbrand")
                        .WithMany("GetBrandTypes")
                        .HasForeignKey("brnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finanzauto.HuellaCarbono.Domain.type", "fktype")
                        .WithMany("GetTypeBrands")
                        .HasForeignKey("typId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("fkbrand");

                    b.Navigation("fktype");
                });

            modelBuilder.Entity("Finanzauto.HuellaCarbono.Domain.line", b =>
                {
                    b.HasOne("Finanzauto.HuellaCarbono.Domain.brand", "fkbrands")
                        .WithMany("GetBrands")
                        .HasForeignKey("brnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finanzauto.HuellaCarbono.Domain.fuel", "fkfuel")
                        .WithMany("GetFuel")
                        .HasForeignKey("fueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finanzauto.HuellaCarbono.Domain.type", "fktypes")
                        .WithMany("GetTypes")
                        .HasForeignKey("typId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("fkbrands");

                    b.Navigation("fkfuel");

                    b.Navigation("fktypes");
                });

            modelBuilder.Entity("Finanzauto.HuellaCarbono.Domain.record", b =>
                {
                    b.HasOne("Finanzauto.HuellaCarbono.Domain.line", "Line")
                        .WithMany("GetRecords")
                        .HasForeignKey("linId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Line");
                });

            modelBuilder.Entity("Finanzauto.HuellaCarbono.Domain.brand", b =>
                {
                    b.Navigation("GetBrandTypes");

                    b.Navigation("GetBrands");
                });

            modelBuilder.Entity("Finanzauto.HuellaCarbono.Domain.fuel", b =>
                {
                    b.Navigation("GetFuel");
                });

            modelBuilder.Entity("Finanzauto.HuellaCarbono.Domain.line", b =>
                {
                    b.Navigation("GetRecords");
                });

            modelBuilder.Entity("Finanzauto.HuellaCarbono.Domain.type", b =>
                {
                    b.Navigation("GetTypeBrands");

                    b.Navigation("GetTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
