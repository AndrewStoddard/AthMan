using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AthMan.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Countries",
                table => new
                {
                    CountryID = table.Column<string>("nvarchar(450)", nullable: false),
                    Name = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Countries", x => x.CountryID); });

            migrationBuilder.CreateTable(
                "Employees",
                table => new
                {
                    EmployeeID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Email = table.Column<string>("nvarchar(max)", nullable: true),
                    Phone = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Employees", x => x.EmployeeID); });

            migrationBuilder.CreateTable(
                "Items",
                table => new
                {
                    ItemID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>("nvarchar(max)", nullable: true),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    YearlyPrice = table.Column<decimal>("decimal(18,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>("datetime2", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Items", x => x.ItemID); });

            migrationBuilder.CreateTable(
                "Clients",
                table => new
                {
                    ClientID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>("nvarchar(max)", nullable: true),
                    LastName = table.Column<string>("nvarchar(max)", nullable: true),
                    Address = table.Column<string>("nvarchar(max)", nullable: true),
                    City = table.Column<string>("nvarchar(max)", nullable: true),
                    State = table.Column<string>("nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>("nvarchar(max)", nullable: true),
                    CountryID = table.Column<string>("nvarchar(450)", nullable: true),
                    Phone = table.Column<string>("nvarchar(max)", nullable: true),
                    Email = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        "FK_Clients_Countries_CountryID",
                        x => x.CountryID,
                        "Countries",
                        "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Incidents",
                table => new
                {
                    IncidentID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>("int", nullable: false),
                    ItemID = table.Column<int>("int", nullable: false),
                    EmployeeID = table.Column<int>("int", nullable: true),
                    Title = table.Column<string>("nvarchar(max)", nullable: true),
                    Description = table.Column<string>("nvarchar(max)", nullable: true),
                    DateOpened = table.Column<DateTime>("datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>("datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentID);
                    table.ForeignKey(
                        "FK_Incidents_Clients_ClientID",
                        x => x.ClientID,
                        "Clients",
                        "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Incidents_Employees_EmployeeID",
                        x => x.EmployeeID,
                        "Employees",
                        "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Incidents_Items_ItemID",
                        x => x.ItemID,
                        "Items",
                        "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                "Countries",
                new[] {"CountryID", "Name"},
                new object[,]
                {
                    {"AU", "Australia"},
                    {"NZ", "New Zealand"},
                    {"NG", "Nigeria"},
                    {"PH", "Philippines"},
                    {"PR", "Puerto Rico"},
                    {"QA", "Qatar"},
                    {"SG", "Singapore"},
                    {"ES", "Spain"},
                    {"SE", "Sweden"},
                    {"CH", "Switzerland"},
                    {"TH", "Thailand"},
                    {"TR", "Turkey"},
                    {"UA", "Ukraine"},
                    {"AE", "United Arab Emirates"},
                    {"GB", "United Kingdom"},
                    {"US", "United States"},
                    {"VN", "Vietnam"},
                    {"ZW", "Zimbabwe"},
                    {"NL", "Netherlands"},
                    {"MX", "Mexico"},
                    {"PT", "Portugal"},
                    {"LR", "Liberia"},
                    {"AT", "Austria"},
                    {"BE", "Belgium"},
                    {"BR", "Brazil"},
                    {"MY", "Malaysia"},
                    {"CN", "China"},
                    {"DK", "Denmark"},
                    {"FI", "Finland"},
                    {"FR", "France"},
                    {"GR", "Greece"},
                    {"CA", "Canada"},
                    {"HK", "Hong Kong"},
                    {"IS", "Iceland"},
                    {"IN", "India"},
                    {"IE", "Ireland"},
                    {"IL", "Israel"},
                    {"IT", "Italy"},
                    {"JP", "Japan"},
                    {"GL", "Greenland"}
                });

            migrationBuilder.InsertData(
                "Employees",
                new[] {"EmployeeID", "Email", "Name", "Phone"},
                new object[,]
                {
                    {15, "tfiori@athman.com", "Tina Fiori", "800-555-1459"},
                    {14, "gwendt@athman.com", "George Wendt", "800-555-1400"}
                });

            migrationBuilder.InsertData(
                "Employees",
                new[] {"EmployeeID", "Email", "Name", "Phone"},
                new object[,]
                {
                    {12, "jason@athman.com", "Jason Lea", "800-555-1444"},
                    {11, "alie@athman.com", "Alie Diaz", "800-555-1443"},
                    {13, "andy@athman.com", "Andy Wilson", "800-555-1449"}
                });

            migrationBuilder.InsertData(
                "Items",
                new[] {"ItemID", "ItemCode", "Name", "ReleaseDate", "YearlyPrice"},
                new object[,]
                {
                    {
                        6, "TRNY10", "Tournament Master 1.0",
                        new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m
                    },
                    {
                        1, "DRFT15", "Draft Manager 1.5",
                        new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m
                    },
                    {
                        2, "DRFT24", "Draft Manager 2.4",
                        new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.99m
                    },
                    {
                        3, "LEAG11", "League Scheduler 1.1",
                        new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m
                    },
                    {
                        4, "LEAGD20", "League Scheduler Deluxe 2.0",
                        new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.99m
                    },
                    {
                        5, "TEAM10", "Team Manager 1.0", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        4.99m
                    },
                    {
                        7, "TRNY20", "Tournament Master 2.0",
                        new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.99m
                    }
                });

            migrationBuilder.InsertData(
                "Clients",
                new[]
                {
                    "ClientID", "Address", "City", "CountryID", "Email", "FirstName", "LastName", "Phone", "PostalCode",
                    "State"
                },
                new object[,]
                {
                    {
                        1002, "PO Box 96621", "Washington", "US", "anita@mma.nidc.com", "Anita", "Ervin",
                        "(301) 555-8950", "20090", "DC"
                    },
                    {
                        1004, "1990 Westwood Blvd Ste 260", "Los Angeles", "US", "kenzie@mma.jobtrak.com", "Kenzie",
                        "Quinne", "(800) 555-8725", "90025", "CA"
                    },
                    {
                        1006, "3255 Ramos Cir", "Sacramento", "US", "amauro@yahoo.org", "Anton", "Mauro",
                        "(916) 555-6670", "95827", "CA"
                    },
                    {
                        1008, "Box 52001", "San Francisco", "US", "kanthoni@pge.com", "Kaitlin", "Anthoni",
                        "(800) 555-6081", "94152", "CA"
                    },
                    {
                        1010, "PO Box 2069", "Fresno", "US", "kmay@fresno.ca.gov", "Kendall", "May", "(559) 555-9999",
                        "93718", "CA"
                    },
                    {
                        1012, "4420 N. First Street, Suite 108", "Fresno", "US", "marvin@expedata.com", "Marvin",
                        "Keeton", "(559) 555-9586", "93726", "CA"
                    },
                    {
                        1015, "27371 Valderas", "Mission Viejo", "US", "", "Gonzalo", "Quintin", "(214) 555-3647",
                        "92691", "CA"
                    }
                });

            migrationBuilder.InsertData(
                "Incidents",
                new[]
                {
                    "IncidentID", "ClientID", "DateClosed", "DateOpened", "Description", "EmployeeID", "ItemID", "Title"
                },
                new object[,]
                {
                    {
                        2, 1002, null, new DateTime(2021, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        "Received error message 415 while trying to import data from previous version.", 14, 4,
                        "Error importing data"
                    },
                    {
                        1, 1010, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Media appears to be bad.", 11,
                        1, "Could not install"
                    },
                    {
                        4, 1010, null, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        "Program fails with error code 510, unable to open database.", null, 3,
                        "Error launching program"
                    },
                    {
                        3, 1015, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Setup failed with code 104.",
                        15, 6, "Could not install"
                    }
                });

            migrationBuilder.CreateIndex(
                "IX_Clients_CountryID",
                "Clients",
                "CountryID");

            migrationBuilder.CreateIndex(
                "IX_Incidents_ClientID",
                "Incidents",
                "ClientID");

            migrationBuilder.CreateIndex(
                "IX_Incidents_EmployeeID",
                "Incidents",
                "EmployeeID");

            migrationBuilder.CreateIndex(
                "IX_Incidents_ItemID",
                "Incidents",
                "ItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Incidents");

            migrationBuilder.DropTable(
                "Clients");

            migrationBuilder.DropTable(
                "Employees");

            migrationBuilder.DropTable(
                "Items");

            migrationBuilder.DropTable(
                "Countries");
        }
    }
}