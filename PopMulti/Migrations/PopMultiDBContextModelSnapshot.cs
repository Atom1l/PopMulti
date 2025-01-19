﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PopMulti.Data;

#nullable disable

namespace PopMulti.Migrations
{
    [DbContext(typeof(PopMultiDBContext))]
    partial class PopMultiDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PopMulti.Models.PopModel.PopMultiModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KMUTT")
                        .HasColumnType("int");

                    b.Property<int>("SU")
                        .HasColumnType("int");

                    b.Property<int>("SWU")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PopMultiDB");
                });
#pragma warning restore 612, 618
        }
    }
}
