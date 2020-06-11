using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ValueObjectDemo.Migrations
{
    public partial class InitialDatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(maxLength: 600, nullable: true, defaultValue: "Available")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    StreetAddress = table.Column<string>(maxLength: 600, nullable: true, defaultValue: ""),
                    City = table.Column<string>(maxLength: 150, nullable: true, defaultValue: ""),
                    State = table.Column<string>(maxLength: 60, nullable: true, defaultValue: ""),
                    ZipCode = table.Column<string>(nullable: true, defaultValue: ""),
                    PlusFour = table.Column<string>(nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Addresses_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
