using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.Web.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client_Classification",
                columns: table => new
                {
                    ClientClass_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classicifcation_Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Classification", x => x.ClientClass_Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Document_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document_Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Document_Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Position_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position_Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Position_Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Name = table.Column<string>(maxLength: 50, nullable: false),
                    Employee_Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    Document_Id = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Cellphone = table.Column<string>(maxLength: 20, nullable: true),
                    Extension = table.Column<string>(maxLength: 6, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Position_Id = table.Column<int>(nullable: false),
                    Fecha_Ingreso = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Employee_Id);
                    table.ForeignKey(
                        name: "FK_Employee_Document_Document_Id",
                        column: x => x.Document_Id,
                        principalTable: "Document",
                        principalColumn: "Document_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Position_Position_Id",
                        column: x => x.Position_Id,
                        principalTable: "Position",
                        principalColumn: "Position_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Document_Id",
                table: "Employee",
                column: "Document_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Position_Id",
                table: "Employee",
                column: "Position_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client_Classification");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
