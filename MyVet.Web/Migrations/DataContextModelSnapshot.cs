﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema.Web.Data;

namespace Sistema.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sistema.Web.Data.Entities.Article", b =>
                {
                    b.Property<int>("Article_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArtC_Id")
                        .HasColumnType("int");

                    b.Property<string>("Article_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Brand_Id")
                        .HasColumnType("int");

                    b.HasKey("Article_Id");

                    b.HasIndex("ArtC_Id");

                    b.HasIndex("Brand_Id");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.ArticleClassification", b =>
                {
                    b.Property<int>("ArtC_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_ArtC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtC_Id");

                    b.ToTable("ArticleClassification");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Brand", b =>
                {
                    b.Property<int>("Brand_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Brand_Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.City", b =>
                {
                    b.Property<int>("City_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("State_Id")
                        .HasColumnType("int");

                    b.HasKey("City_Id");

                    b.HasIndex("State_Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Client_Classification", b =>
                {
                    b.Property<int>("ClientClass_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Classicifcation_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ClientClass_Id");

                    b.ToTable("Client_Classification");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Company", b =>
                {
                    b.Property<int>("Company_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientClass_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Client_ClassificationClientClass_Id")
                        .HasColumnType("int");

                    b.Property<string>("Company_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("DocumentsDocument_Id")
                        .HasColumnType("int");

                    b.Property<int>("ID_Doc")
                        .HasColumnType("int");

                    b.Property<int>("Neighborhood_Id")
                        .HasColumnType("int");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Company_Id");

                    b.HasIndex("Client_ClassificationClientClass_Id");

                    b.HasIndex("DocumentsDocument_Id");

                    b.HasIndex("Neighborhood_Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Country", b =>
                {
                    b.Property<int>("Country_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Country_Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Customer", b =>
                {
                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidoC")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("ClientClass_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Client_ClassificationClientClass_Id")
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionC")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("Document_Id")
                        .HasColumnType("int");

                    b.Property<string>("Document_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NombreC")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("TelefonC")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Customer_Id");

                    b.HasIndex("Client_ClassificationClientClass_Id");

                    b.HasIndex("Document_Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Document", b =>
                {
                    b.Property<int>("Document_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Document_Id");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Employe_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cellphone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Codigo_Empleado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Document_Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Document_Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Employee_Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Employee_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.Property<DateTime>("Fecha_Ingreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Position_Id")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Employe_Id");

                    b.HasIndex("Document_Id");

                    b.HasIndex("Position_Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.FormPago", b =>
                {
                    b.Property<int>("Id_Pago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Moneda_Id")
                        .HasColumnType("int");

                    b.Property<string>("pago_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Pago");

                    b.HasIndex("Moneda_Id");

                    b.ToTable("FormPago");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Moneda", b =>
                {
                    b.Property<int>("Moneda_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name_moneda")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nmoneda")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Tasa_moneda")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Moneda_Id");

                    b.ToTable("Moneda");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Neighborhood", b =>
                {
                    b.Property<int>("Neighborhood_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("City_Id")
                        .HasColumnType("int");

                    b.Property<string>("Neighborhood_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Neighborhood_Id");

                    b.HasIndex("City_Id");

                    b.ToTable("Neighborhood");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Position", b =>
                {
                    b.Property<int>("Position_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Position_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Position_Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Seller", b =>
                {
                    b.Property<int>("Seller_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cellphone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Codigo_Vendedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentRef")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Document_Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Seller_Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Seller_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Seller_Id");

                    b.HasIndex("Document_Id");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.State", b =>
                {
                    b.Property<int>("State_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Country_Id")
                        .HasColumnType("int");

                    b.Property<string>("State_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("State_Id");

                    b.HasIndex("Country_Id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Supplier", b =>
                {
                    b.Property<int>("Supplier_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Neighborhood_Id")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SupplierC")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Supplier_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("name_contacta")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Supplier_Id");

                    b.HasIndex("Neighborhood_Id");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Article", b =>
                {
                    b.HasOne("Sistema.Web.Data.Entities.ArticleClassification", "ArticleClassification")
                        .WithMany("Articles")
                        .HasForeignKey("ArtC_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema.Web.Data.Entities.Brand", "Brand")
                        .WithMany("Articles")
                        .HasForeignKey("Brand_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.City", b =>
                {
                    b.HasOne("Sistema.Web.Data.Entities.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("State_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Company", b =>
                {
                    b.HasOne("Sistema.Web.Data.Entities.Client_Classification", "Client_Classification")
                        .WithMany("Companies")
                        .HasForeignKey("Client_ClassificationClientClass_Id");

                    b.HasOne("Sistema.Web.Data.Entities.Document", "Documents")
                        .WithMany("Companies")
                        .HasForeignKey("DocumentsDocument_Id");

                    b.HasOne("Sistema.Web.Data.Entities.Neighborhood", "Neighborhood")
                        .WithMany("Companies")
                        .HasForeignKey("Neighborhood_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Customer", b =>
                {
                    b.HasOne("Sistema.Web.Data.Entities.Client_Classification", "Client_Classification")
                        .WithMany("Customers")
                        .HasForeignKey("Client_ClassificationClientClass_Id");

                    b.HasOne("Sistema.Web.Data.Entities.Document", "Document")
                        .WithMany("Customers")
                        .HasForeignKey("Document_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Employee", b =>
                {
                    b.HasOne("Sistema.Web.Data.Entities.Document", "Document")
                        .WithMany("Employees")
                        .HasForeignKey("Document_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema.Web.Data.Entities.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("Position_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.FormPago", b =>
                {
                    b.HasOne("Sistema.Web.Data.Entities.Moneda", "Moneda")
                        .WithMany("FormPagos")
                        .HasForeignKey("Moneda_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Neighborhood", b =>
                {
                    b.HasOne("Sistema.Web.Data.Entities.City", "City")
                        .WithMany("Neighborhoods")
                        .HasForeignKey("City_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Seller", b =>
                {
                    b.HasOne("Sistema.Web.Data.Entities.Document", "Document")
                        .WithMany("Sellers")
                        .HasForeignKey("Document_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.State", b =>
                {
                    b.HasOne("Sistema.Web.Data.Entities.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("Country_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema.Web.Data.Entities.Supplier", b =>
                {
                    b.HasOne("Sistema.Web.Data.Entities.Neighborhood", "Neighborhood")
                        .WithMany("Suppliers")
                        .HasForeignKey("Neighborhood_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
