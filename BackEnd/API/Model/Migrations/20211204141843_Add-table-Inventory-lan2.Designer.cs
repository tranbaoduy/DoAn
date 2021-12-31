﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

namespace Model.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20211204141843_Add-table-Inventory-lan2")]
    partial class AddtableInventorylan2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Model.Agent", b =>
                {
                    b.Property<int>("AgentCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AgentCode")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressAgent")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("AddressAgent");

                    b.Property<string>("NameAgent")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NameAgent");

                    b.Property<string>("PhoneAgent")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("PhoneAgent");

                    b.HasKey("AgentCode");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("Model.Model.Functions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Key")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("code")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("codeFunction");

                    b.Property<string>("component")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("component");

                    b.Property<string>("name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nameFunction");

                    b.Property<string>("url")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.ToTable("functions");
                });

            modelBuilder.Entity("Model.Model.Inventory", b =>
                {
                    b.Property<string>("InvoiceRefid")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("InvoiceRefid");

                    b.Property<int>("AgentCode")
                        .HasColumnType("int")
                        .HasColumnName("AgentCode");

                    b.Property<string>("CodeMedicine")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CodeMedicine");

                    b.Property<string>("Count")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Count");

                    b.Property<DateTime>("DateBuy")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateBuy");

                    b.Property<DateTime>("DateExpire")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateExpire");

                    b.Property<DateTime>("DateMade")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateMade");

                    b.Property<string>("NameMedice")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NameMedice");

                    b.Property<string>("Price")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Price");

                    b.Property<string>("PriceSell")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("PriceSell");

                    b.Property<string>("SeriNumber")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("SeriNumber");

                    b.Property<int>("SupCode")
                        .HasColumnType("int")
                        .HasColumnName("SupCode");

                    b.HasKey("InvoiceRefid");

                    b.ToTable("Inventorys");
                });

            modelBuilder.Entity("Model.Model.Invoice", b =>
                {
                    b.Property<string>("InvoiceCode")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("InvoiceCode");

                    b.Property<int>("AgentCode")
                        .HasColumnType("int")
                        .HasColumnName("AgentCode");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateCreate");

                    b.Property<string>("NameCus")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("NameCus");

                    b.Property<string>("Paid")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Paid");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("PhoneNumber");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.Property<int>("SupCode")
                        .HasColumnType("int")
                        .HasColumnName("SupCode");

                    b.Property<string>("TotalInvoice")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("TotalInvoice");

                    b.Property<int>("TypeInvoice")
                        .HasColumnType("int")
                        .HasColumnName("TypeInvoice");

                    b.Property<string>("UserCreate")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("UserCreate");

                    b.Property<string>("newDept")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("newDept");

                    b.Property<string>("oldDept")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("oldDept");

                    b.HasKey("InvoiceCode");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Model.Model.InvoiceDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgentCode")
                        .HasColumnType("int")
                        .HasColumnName("AgentCode");

                    b.Property<string>("CodeMedicine")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CodeMedicine");

                    b.Property<string>("Count")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Count");

                    b.Property<DateTime>("DateExpire")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateExpire");

                    b.Property<DateTime>("DateMade")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateMade");

                    b.Property<string>("InvoiceRefid")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("InvoiceRefid");

                    b.Property<string>("NameMedice")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NameMedice");

                    b.Property<string>("Price")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Price");

                    b.Property<string>("SeriNumber")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("SeriNumber");

                    b.Property<string>("Total")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Total");

                    b.HasKey("ID");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("Model.Model.Login.NguoiDung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgentCode")
                        .HasColumnType("int")
                        .HasColumnName("AgentCode");

                    b.Property<string>("fullName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("fullName");

                    b.Property<string>("passWord")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("passWord");

                    b.Property<string>("role")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("role");

                    b.Property<string>("userName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("userName");

                    b.HasKey("Id");

                    b.ToTable("NguoiDungs");
                });

            modelBuilder.Entity("Model.Model.Medicine", b =>
                {
                    b.Property<string>("CodeMedicine")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CodeMedicine");

                    b.Property<string>("DosageForm")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("DosageForm");

                    b.Property<string>("ExChange")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("ExChange");

                    b.Property<string>("NameMedice")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("NameMedice");

                    b.Property<string>("UnitLast")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("UnitLast");

                    b.HasKey("CodeMedicine");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("Model.Model.Permissions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Key")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Controller")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Controller");

                    b.Property<int>("Delete")
                        .HasColumnType("int")
                        .HasColumnName("Delete");

                    b.Property<int>("Edit")
                        .HasColumnType("int")
                        .HasColumnName("Edit");

                    b.Property<int>("Insert")
                        .HasColumnType("int")
                        .HasColumnName("Insert");

                    b.Property<string>("codeFunction")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("codeFunction");

                    b.Property<string>("userName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("userName");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Model.Model.Supplier", b =>
                {
                    b.Property<int>("SupCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SupCode")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dept")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Dept");

                    b.Property<string>("Paid")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Paid");

                    b.Property<string>("SupAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("SupAddress");

                    b.Property<string>("SupName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("SupName");

                    b.Property<string>("SupPhone")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("SupPhone");

                    b.HasKey("SupCode");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Model.Model.groupFunctions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Key")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("groups")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("groups");

                    b.Property<string>("role")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("groupFunctions");
                });
#pragma warning restore 612, 618
        }
    }
}
