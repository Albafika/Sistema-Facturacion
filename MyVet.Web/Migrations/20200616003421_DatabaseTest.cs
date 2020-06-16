using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.Web.Migrations
{
    public partial class DatabaseTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleClassification",
                columns: table => new
                {
                    ArtC_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: false),
                    Name_ArtC = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleClassification", x => x.ArtC_Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Brand_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: false),
                    Brand_Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Brand_Id);
                });

            migrationBuilder.CreateTable(
                name: "Client_Classification",
                columns: table => new
                {
                    ClientClass_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientClass_Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Classification", x => x.ClientClass_Id);
                });

            migrationBuilder.CreateTable(
                name: "Company_Classification",
                columns: table => new
                {
                    CompanyClass_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyClass_Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_Classification", x => x.CompanyClass_Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Country_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country_Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Country_Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Document_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Document_Id);
                });

            migrationBuilder.CreateTable(
                name: "Moneda",
                columns: table => new
                {
                    Moneda_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_moneda = table.Column<string>(maxLength: 50, nullable: false),
                    Tasa_moneda = table.Column<string>(maxLength: 50, nullable: false),
                    Nmoneda = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moneda", x => x.Moneda_Id);
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
                name: "Article",
                columns: table => new
                {
                    Article_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Article_Name = table.Column<string>(nullable: false),
                    ArtC_Id = table.Column<int>(nullable: false),
                    Brand_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Article_Id);
                    table.ForeignKey(
                        name: "FK_Article_ArticleClassification_ArtC_Id",
                        column: x => x.ArtC_Id,
                        principalTable: "ArticleClassification",
                        principalColumn: "ArtC_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Article_Brand_Brand_Id",
                        column: x => x.Brand_Id,
                        principalTable: "Brand",
                        principalColumn: "Brand_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    State_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State_Name = table.Column<string>(maxLength: 30, nullable: false),
                    Country_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.State_Id);
                    table.ForeignKey(
                        name: "FK_State_Country_Country_Id",
                        column: x => x.Country_Id,
                        principalTable: "Country",
                        principalColumn: "Country_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreC = table.Column<string>(maxLength: 30, nullable: false),
                    ApellidoC = table.Column<string>(maxLength: 30, nullable: false),
                    Document_Id = table.Column<int>(nullable: false),
                    ClientClass_Id = table.Column<int>(nullable: false),
                    Document_Number = table.Column<string>(maxLength: 50, nullable: false),
                    TelefonC = table.Column<string>(maxLength: 15, nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    DireccionC = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Customer_Id);
                    table.ForeignKey(
                        name: "FK_Customer_Client_Classification_ClientClass_Id",
                        column: x => x.ClientClass_Id,
                        principalTable: "Client_Classification",
                        principalColumn: "ClientClass_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_Document_Document_Id",
                        column: x => x.Document_Id,
                        principalTable: "Document",
                        principalColumn: "Document_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    Seller_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_Vendedor = table.Column<string>(nullable: true),
                    Seller_Name = table.Column<string>(maxLength: 50, nullable: false),
                    Seller_Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    Document_Id = table.Column<int>(nullable: false),
                    DocumentRef = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Cellphone = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.Seller_Id);
                    table.ForeignKey(
                        name: "FK_Seller_Document_Document_Id",
                        column: x => x.Document_Id,
                        principalTable: "Document",
                        principalColumn: "Document_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormPago",
                columns: table => new
                {
                    Id_Pago = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pago_Name = table.Column<string>(nullable: false),
                    Moneda_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormPago", x => x.Id_Pago);
                    table.ForeignKey(
                        name: "FK_FormPago_Moneda_Moneda_Id",
                        column: x => x.Moneda_Id,
                        principalTable: "Moneda",
                        principalColumn: "Moneda_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Employe_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_Empleado = table.Column<string>(nullable: true),
                    Employee_Name = table.Column<string>(maxLength: 50, nullable: false),
                    Employee_Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    Document_Id = table.Column<int>(nullable: false),
                    Document_Codigo = table.Column<string>(maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_Employee", x => x.Employe_Id);
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

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    City_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City_Name = table.Column<string>(maxLength: 30, nullable: false),
                    State_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.City_Id);
                    table.ForeignKey(
                        name: "FK_City_State_State_Id",
                        column: x => x.State_Id,
                        principalTable: "State",
                        principalColumn: "State_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhood",
                columns: table => new
                {
                    Neighborhood_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Neighborhood_Name = table.Column<string>(maxLength: 30, nullable: false),
                    City_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhood", x => x.Neighborhood_Id);
                    table.ForeignKey(
                        name: "FK_Neighborhood_City_City_Id",
                        column: x => x.City_Id,
                        principalTable: "City",
                        principalColumn: "City_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Company_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_Name = table.Column<string>(nullable: false),
                    CompanyClass_Id = table.Column<int>(nullable: false),
                    Document_Id = table.Column<int>(nullable: false),
                    Document_Code = table.Column<string>(maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Neighborhood_Id = table.Column<int>(nullable: false),
                    correo = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Company_Id);
                    table.ForeignKey(
                        name: "FK_Company_Company_Classification_CompanyClass_Id",
                        column: x => x.CompanyClass_Id,
                        principalTable: "Company_Classification",
                        principalColumn: "CompanyClass_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company_Document_Document_Id",
                        column: x => x.Document_Id,
                        principalTable: "Document",
                        principalColumn: "Document_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company_Neighborhood_Neighborhood_Id",
                        column: x => x.Neighborhood_Id,
                        principalTable: "Neighborhood",
                        principalColumn: "Neighborhood_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Supplier_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Supplier_Name = table.Column<string>(nullable: false),
                    Numero = table.Column<string>(maxLength: 50, nullable: false),
                    SupplierC = table.Column<string>(maxLength: 50, nullable: false),
                    phone = table.Column<string>(maxLength: 50, nullable: false),
                    Neighborhood_Id = table.Column<int>(nullable: false),
                    correo = table.Column<string>(maxLength: 50, nullable: false),
                    name_contacta = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Supplier_Id);
                    table.ForeignKey(
                        name: "FK_Supplier_Neighborhood_Neighborhood_Id",
                        column: x => x.Neighborhood_Id,
                        principalTable: "Neighborhood",
                        principalColumn: "Neighborhood_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_ArtC_Id",
                table: "Article",
                column: "ArtC_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Article_Brand_Id",
                table: "Article",
                column: "Brand_Id");

            migrationBuilder.CreateIndex(
                name: "IX_City_State_Id",
                table: "City",
                column: "State_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyClass_Id",
                table: "Company",
                column: "CompanyClass_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Document_Id",
                table: "Company",
                column: "Document_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Neighborhood_Id",
                table: "Company",
                column: "Neighborhood_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ClientClass_Id",
                table: "Customer",
                column: "ClientClass_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Document_Id",
                table: "Customer",
                column: "Document_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Document_Id",
                table: "Employee",
                column: "Document_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Position_Id",
                table: "Employee",
                column: "Position_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FormPago_Moneda_Id",
                table: "FormPago",
                column: "Moneda_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhood_City_Id",
                table: "Neighborhood",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Seller_Document_Id",
                table: "Seller",
                column: "Document_Id");

            migrationBuilder.CreateIndex(
                name: "IX_State_Country_Id",
                table: "State",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Neighborhood_Id",
                table: "Supplier",
                column: "Neighborhood_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "FormPago");

            migrationBuilder.DropTable(
                name: "Seller");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "ArticleClassification");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Company_Classification");

            migrationBuilder.DropTable(
                name: "Client_Classification");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Moneda");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Neighborhood");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
