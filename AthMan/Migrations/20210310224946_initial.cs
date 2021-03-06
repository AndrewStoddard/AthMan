// ***********************************************************************
// Author           : Andrew Stoddard
// Created          : 03-10-2021
//
// Last Modified By : Andrew Stoddard
// Last Modified On : 03-10-2021
// ***********************************************************************
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AthMan.Migrations
{
    /// <summary>
    /// Class initial.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    public partial class initial : Migration
    {
        /// <summary>
        /// <para>
        /// Builds the operations that will migrate the database 'up'.
        /// </para>
        /// <para>
        /// That is, builds the operations that will take the database from the state left in by the
        /// previous migration so that it is up-to-date with regard to this migration.
        /// </para>
        /// <para>
        /// This method must be overridden in each class the inherits from <see cref="T:Microsoft.EntityFrameworkCore.Migrations.Migration" />.
        /// </para>
        /// </summary>
        /// <param name="migrationBuilder">The <see cref="T:Microsoft.EntityFrameworkCore.Migrations.MigrationBuilder" /> that will build the operations.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearlyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clients_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentID);
                    table.ForeignKey(
                        name: "FK_Incidents_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[,]
                {
                    { "AU", "Australia" },
                    { "NZ", "New Zealand" },
                    { "NG", "Nigeria" },
                    { "PH", "Philippines" },
                    { "PR", "Puerto Rico" },
                    { "QA", "Qatar" },
                    { "SG", "Singapore" },
                    { "ES", "Spain" },
                    { "SE", "Sweden" },
                    { "CH", "Switzerland" },
                    { "TH", "Thailand" },
                    { "TR", "Turkey" },
                    { "UA", "Ukraine" },
                    { "AE", "United Arab Emirates" },
                    { "GB", "United Kingdom" },
                    { "US", "United States" },
                    { "VN", "Vietnam" },
                    { "ZW", "Zimbabwe" },
                    { "NL", "Netherlands" },
                    { "MX", "Mexico" },
                    { "PT", "Portugal" },
                    { "LR", "Liberia" },
                    { "AT", "Austria" },
                    { "BE", "Belgium" },
                    { "BR", "Brazil" },
                    { "MY", "Malaysia" },
                    { "CN", "China" },
                    { "DK", "Denmark" },
                    { "FI", "Finland" },
                    { "FR", "France" },
                    { "GR", "Greece" },
                    { "CA", "Canada" },
                    { "HK", "Hong Kong" },
                    { "IS", "Iceland" },
                    { "IN", "India" },
                    { "IE", "Ireland" },
                    { "IL", "Israel" },
                    { "IT", "Italy" },
                    { "JP", "Japan" },
                    { "GL", "Greenland" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 15, "tfiori@athman.com", "Tina Fiori", "800-555-1459" },
                    { 14, "gwendt@athman.com", "George Wendt", "800-555-1400" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 12, "jason@athman.com", "Jason Lea", "800-555-1444" },
                    { 11, "alie@athman.com", "Alie Diaz", "800-555-1443" },
                    { 13, "andy@athman.com", "Andy Wilson", "800-555-1449" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "ItemCode", "Name", "ReleaseDate", "YearlyPrice" },
                values: new object[,]
                {
                    { 6, "TRNY10", "Tournament Master 1.0", new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 1, "DRFT15", "Draft Manager 1.5", new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 2, "DRFT24", "Draft Manager 2.4", new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.99m },
                    { 3, "LEAG11", "League Scheduler 1.1", new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 4, "LEAGD20", "League Scheduler Deluxe 2.0", new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.99m },
                    { 5, "TEAM10", "Team Manager 1.0", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 7, "TRNY20", "Tournament Master 2.0", new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.99m }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "Address", "City", "CountryID", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1002, "PO Box 96621", "Washington", "US", "anita@mma.nidc.com", "Anita", "Ervin", "(301) 555-8950", "20090", "DC" },
                    { 1004, "1990 Westwood Blvd Ste 260", "Los Angeles", "US", "kenzie@mma.jobtrak.com", "Kenzie", "Quinne", "(800) 555-8725", "90025", "CA" },
                    { 1006, "3255 Ramos Cir", "Sacramento", "US", "amauro@yahoo.org", "Anton", "Mauro", "(916) 555-6670", "95827", "CA" },
                    { 1008, "Box 52001", "San Francisco", "US", "kanthoni@pge.com", "Kaitlin", "Anthoni", "(800) 555-6081", "94152", "CA" },
                    { 1010, "PO Box 2069", "Fresno", "US", "kmay@fresno.ca.gov", "Kendall", "May", "(559) 555-9999", "93718", "CA" },
                    { 1012, "4420 N. First Street, Suite 108", "Fresno", "US", "marvin@expedata.com", "Marvin", "Keeton", "(559) 555-9586", "93726", "CA" },
                    { 1015, "27371 Valderas", "Mission Viejo", "US", "", "Gonzalo", "Quintin", "(214) 555-3647", "92691", "CA" }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentID", "ClientID", "DateClosed", "DateOpened", "Description", "EmployeeID", "ItemID", "Title" },
                values: new object[,]
                {
                    { 2, 1002, null, new DateTime(2021, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Received error message 415 while trying to import data from previous version.", 14, 4, "Error importing data" },
                    { 1, 1010, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Media appears to be bad.", 11, 1, "Could not install" },
                    { 4, 1010, null, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Program fails with error code 510, unable to open database.", null, 3, "Error launching program" },
                    { 3, 1015, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Setup failed with code 104.", 15, 6, "Could not install" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CountryID",
                table: "Clients",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ClientID",
                table: "Incidents",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_EmployeeID",
                table: "Incidents",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ItemID",
                table: "Incidents",
                column: "ItemID");
        }

        /// <summary>
        /// <para>
        /// Builds the operations that will migrate the database 'down'.
        /// </para>
        /// <para>
        /// That is, builds the operations that will take the database from the state left in by
        /// this migration so that it returns to the state that it was in before this migration was applied.
        /// </para>
        /// <para>
        /// This method must be overridden in each class the inherits from <see cref="T:Microsoft.EntityFrameworkCore.Migrations.Migration" /> if
        /// both 'up' and 'down' migrations are to be supported. If it is not overridden, then calling it
        /// will throw and it will not be possible to migrate in the 'down' direction.
        /// </para>
        /// </summary>
        /// <param name="migrationBuilder">The <see cref="T:Microsoft.EntityFrameworkCore.Migrations.MigrationBuilder" /> that will build the operations.</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
