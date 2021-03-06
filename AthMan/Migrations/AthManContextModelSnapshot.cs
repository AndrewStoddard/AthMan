// ***********************************************************************
// Author           : Andrew Stoddard
// Created          : 03-10-2021
//
// Last Modified By : Andrew Stoddard
// Last Modified On : 03-10-2021
// ***********************************************************************
using System;
using AthMan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AthMan.Migrations
{
    /// <summary>
    /// Class AthManContextModelSnapshot.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Infrastructure.ModelSnapshot" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Infrastructure.ModelSnapshot" />
    [DbContext(typeof(AthManContext))]
    partial class AthManContextModelSnapshot : ModelSnapshot
    {
        /// <summary>
        /// Builds the model.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AthMan.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientID");

                    b.HasIndex("CountryID");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ClientID = 1002,
                            Address = "PO Box 96621",
                            City = "Washington",
                            CountryID = "US",
                            Email = "anita@mma.nidc.com",
                            FirstName = "Anita",
                            LastName = "Ervin",
                            Phone = "(301) 555-8950",
                            PostalCode = "20090",
                            State = "DC"
                        },
                        new
                        {
                            ClientID = 1004,
                            Address = "1990 Westwood Blvd Ste 260",
                            City = "Los Angeles",
                            CountryID = "US",
                            Email = "kenzie@mma.jobtrak.com",
                            FirstName = "Kenzie",
                            LastName = "Quinne",
                            Phone = "(800) 555-8725",
                            PostalCode = "90025",
                            State = "CA"
                        },
                        new
                        {
                            ClientID = 1006,
                            Address = "3255 Ramos Cir",
                            City = "Sacramento",
                            CountryID = "US",
                            Email = "amauro@yahoo.org",
                            FirstName = "Anton",
                            LastName = "Mauro",
                            Phone = "(916) 555-6670",
                            PostalCode = "95827",
                            State = "CA"
                        },
                        new
                        {
                            ClientID = 1008,
                            Address = "Box 52001",
                            City = "San Francisco",
                            CountryID = "US",
                            Email = "kanthoni@pge.com",
                            FirstName = "Kaitlin",
                            LastName = "Anthoni",
                            Phone = "(800) 555-6081",
                            PostalCode = "94152",
                            State = "CA"
                        },
                        new
                        {
                            ClientID = 1010,
                            Address = "PO Box 2069",
                            City = "Fresno",
                            CountryID = "US",
                            Email = "kmay@fresno.ca.gov",
                            FirstName = "Kendall",
                            LastName = "May",
                            Phone = "(559) 555-9999",
                            PostalCode = "93718",
                            State = "CA"
                        },
                        new
                        {
                            ClientID = 1012,
                            Address = "4420 N. First Street, Suite 108",
                            City = "Fresno",
                            CountryID = "US",
                            Email = "marvin@expedata.com",
                            FirstName = "Marvin",
                            LastName = "Keeton",
                            Phone = "(559) 555-9586",
                            PostalCode = "93726",
                            State = "CA"
                        },
                        new
                        {
                            ClientID = 1015,
                            Address = "27371 Valderas",
                            City = "Mission Viejo",
                            CountryID = "US",
                            Email = "",
                            FirstName = "Gonzalo",
                            LastName = "Quintin",
                            Phone = "(214) 555-3647",
                            PostalCode = "92691",
                            State = "CA"
                        });
                });

            modelBuilder.Entity("AthMan.Models.Country", b =>
                {
                    b.Property<string>("CountryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryID");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryID = "AU",
                            Name = "Australia"
                        },
                        new
                        {
                            CountryID = "AT",
                            Name = "Austria"
                        },
                        new
                        {
                            CountryID = "BE",
                            Name = "Belgium"
                        },
                        new
                        {
                            CountryID = "BR",
                            Name = "Brazil"
                        },
                        new
                        {
                            CountryID = "CA",
                            Name = "Canada"
                        },
                        new
                        {
                            CountryID = "CN",
                            Name = "China"
                        },
                        new
                        {
                            CountryID = "DK",
                            Name = "Denmark"
                        },
                        new
                        {
                            CountryID = "FI",
                            Name = "Finland"
                        },
                        new
                        {
                            CountryID = "FR",
                            Name = "France"
                        },
                        new
                        {
                            CountryID = "GR",
                            Name = "Greece"
                        },
                        new
                        {
                            CountryID = "GL",
                            Name = "Greenland"
                        },
                        new
                        {
                            CountryID = "HK",
                            Name = "Hong Kong"
                        },
                        new
                        {
                            CountryID = "IS",
                            Name = "Iceland"
                        },
                        new
                        {
                            CountryID = "IN",
                            Name = "India"
                        },
                        new
                        {
                            CountryID = "IE",
                            Name = "Ireland"
                        },
                        new
                        {
                            CountryID = "IL",
                            Name = "Israel"
                        },
                        new
                        {
                            CountryID = "IT",
                            Name = "Italy"
                        },
                        new
                        {
                            CountryID = "JP",
                            Name = "Japan"
                        },
                        new
                        {
                            CountryID = "LR",
                            Name = "Liberia"
                        },
                        new
                        {
                            CountryID = "MY",
                            Name = "Malaysia"
                        },
                        new
                        {
                            CountryID = "MX",
                            Name = "Mexico"
                        },
                        new
                        {
                            CountryID = "NL",
                            Name = "Netherlands"
                        },
                        new
                        {
                            CountryID = "NZ",
                            Name = "New Zealand"
                        },
                        new
                        {
                            CountryID = "NG",
                            Name = "Nigeria"
                        },
                        new
                        {
                            CountryID = "PH",
                            Name = "Philippines"
                        },
                        new
                        {
                            CountryID = "PT",
                            Name = "Portugal"
                        },
                        new
                        {
                            CountryID = "PR",
                            Name = "Puerto Rico"
                        },
                        new
                        {
                            CountryID = "QA",
                            Name = "Qatar"
                        },
                        new
                        {
                            CountryID = "SG",
                            Name = "Singapore"
                        },
                        new
                        {
                            CountryID = "ES",
                            Name = "Spain"
                        },
                        new
                        {
                            CountryID = "SE",
                            Name = "Sweden"
                        },
                        new
                        {
                            CountryID = "CH",
                            Name = "Switzerland"
                        },
                        new
                        {
                            CountryID = "TH",
                            Name = "Thailand"
                        },
                        new
                        {
                            CountryID = "TR",
                            Name = "Turkey"
                        },
                        new
                        {
                            CountryID = "UA",
                            Name = "Ukraine"
                        },
                        new
                        {
                            CountryID = "AE",
                            Name = "United Arab Emirates"
                        },
                        new
                        {
                            CountryID = "GB",
                            Name = "United Kingdom"
                        },
                        new
                        {
                            CountryID = "US",
                            Name = "United States"
                        },
                        new
                        {
                            CountryID = "VN",
                            Name = "Vietnam"
                        },
                        new
                        {
                            CountryID = "ZW",
                            Name = "Zimbabwe"
                        });
                });

            modelBuilder.Entity("AthMan.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 11,
                            Email = "alie@athman.com",
                            Name = "Alie Diaz",
                            Phone = "800-555-1443"
                        },
                        new
                        {
                            EmployeeID = 12,
                            Email = "jason@athman.com",
                            Name = "Jason Lea",
                            Phone = "800-555-1444"
                        },
                        new
                        {
                            EmployeeID = 13,
                            Email = "andy@athman.com",
                            Name = "Andy Wilson",
                            Phone = "800-555-1449"
                        },
                        new
                        {
                            EmployeeID = 14,
                            Email = "gwendt@athman.com",
                            Name = "George Wendt",
                            Phone = "800-555-1400"
                        },
                        new
                        {
                            EmployeeID = 15,
                            Email = "tfiori@athman.com",
                            Name = "Tina Fiori",
                            Phone = "800-555-1459"
                        });
                });

            modelBuilder.Entity("AthMan.Models.Incident", b =>
                {
                    b.Property<int>("IncidentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOpened")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("ItemID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncidentID");

                    b.HasIndex("ClientID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ItemID");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentID = 1,
                            ClientID = 1010,
                            DateClosed = new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOpened = new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Media appears to be bad.",
                            EmployeeID = 11,
                            ItemID = 1,
                            Title = "Could not install"
                        },
                        new
                        {
                            IncidentID = 2,
                            ClientID = 1002,
                            DateOpened = new DateTime(2021, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Received error message 415 while trying to import data from previous version.",
                            EmployeeID = 14,
                            ItemID = 4,
                            Title = "Error importing data"
                        },
                        new
                        {
                            IncidentID = 3,
                            ClientID = 1015,
                            DateClosed = new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOpened = new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Setup failed with code 104.",
                            EmployeeID = 15,
                            ItemID = 6,
                            Title = "Could not install"
                        },
                        new
                        {
                            IncidentID = 4,
                            ClientID = 1010,
                            DateOpened = new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Program fails with error code 510, unable to open database.",
                            ItemID = 3,
                            Title = "Error launching program"
                        });
                });

            modelBuilder.Entity("AthMan.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("YearlyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ItemID");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemID = 1,
                            ItemCode = "DRFT15",
                            Name = "Draft Manager 1.5",
                            ReleaseDate = new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 4.99m
                        },
                        new
                        {
                            ItemID = 2,
                            ItemCode = "DRFT24",
                            Name = "Draft Manager 2.4",
                            ReleaseDate = new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 5.99m
                        },
                        new
                        {
                            ItemID = 3,
                            ItemCode = "LEAG11",
                            Name = "League Scheduler 1.1",
                            ReleaseDate = new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 4.99m
                        },
                        new
                        {
                            ItemID = 4,
                            ItemCode = "LEAGD20",
                            Name = "League Scheduler Deluxe 2.0",
                            ReleaseDate = new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 7.99m
                        },
                        new
                        {
                            ItemID = 5,
                            ItemCode = "TEAM10",
                            Name = "Team Manager 1.0",
                            ReleaseDate = new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 4.99m
                        },
                        new
                        {
                            ItemID = 6,
                            ItemCode = "TRNY10",
                            Name = "Tournament Master 1.0",
                            ReleaseDate = new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 4.99m
                        },
                        new
                        {
                            ItemID = 7,
                            ItemCode = "TRNY20",
                            Name = "Tournament Master 2.0",
                            ReleaseDate = new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 5.99m
                        });
                });

            modelBuilder.Entity("AthMan.Models.Client", b =>
                {
                    b.HasOne("AthMan.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("AthMan.Models.Incident", b =>
                {
                    b.HasOne("AthMan.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AthMan.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");

                    b.HasOne("AthMan.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Employee");

                    b.Navigation("Item");
                });
#pragma warning restore 612, 618
        }
    }
}
