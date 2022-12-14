// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WepApiComputadoras;

#nullable disable

namespace WepApiComputadoras.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220919074841_Classes")]
    partial class Classes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WepApiComputadoras.Entidades.Caracteristicas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ComputadoraId")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComputadoraId");

                    b.ToTable("Caracteristicas");
                });

            modelBuilder.Entity("WepApiComputadoras.Entidades.Computadora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Computadoras");
                });

            modelBuilder.Entity("WepApiComputadoras.Entidades.Caracteristicas", b =>
                {
                    b.HasOne("WepApiComputadoras.Entidades.Computadora", "Computadora")
                        .WithMany("Caracteristicas")
                        .HasForeignKey("ComputadoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Computadora");
                });

            modelBuilder.Entity("WepApiComputadoras.Entidades.Computadora", b =>
                {
                    b.Navigation("Caracteristicas");
                });
#pragma warning restore 612, 618
        }
    }
}
