using Microsoft.EntityFrameworkCore;
using TPShoes.Entidades;
using TPShoes.Entidades.Clases;

namespace TPShoes.Datos
{
    public class DBContextShoes : DbContext
    {
        public DBContextShoes() { }
        public DBContextShoes(DbContextOptions<DBContextShoes> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<SizeShoe> SizeShoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.; Initial Catalog=TPShoes;
                    Trusted_Connection=true; TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var BrandsList = new List<Brand>()
            {
                new Brand
                {
                    BrandId=1,
                   BrandName="Star"
                },
                new Brand
                {
                   BrandId=2,
                   BrandName="Shadow"
                },
                new Brand
                {
                   BrandId=3,
                   BrandName="Mr.Low"
                }
            };

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brands");

                entity.Property(e => e.BrandName)
                .HasMaxLength(50);
                entity.HasIndex(e => e.BrandName).IsUnique();
                entity.HasData(BrandsList);
            });

            var ColoursList = new List<Colour>()
            {
                new Colour
                {
                    ColourId=1,
                   ColourName="blanco"
                },
                new Colour
                {
                   ColourId=2,
                   ColourName="azul"
                },
                new Colour
                {
                   ColourId=3,
                   ColourName="rojo"
                }
            };


            modelBuilder.Entity<Colour>(entity =>
            {
                entity.ToTable("Colours");

                entity.Property(e => e.ColourName)
                .HasMaxLength(50);
                entity.HasIndex(e => e.ColourName).IsUnique();
                entity.HasData(ColoursList);
            });

            var GenresList = new List<Genre>()
            {
                new Genre
                {
                    GenreId=1,
                   GenreName="deportivo"
                },
                new Genre
                {
                   GenreId=2,
                   GenreName="casual"
                },
                new Genre
                {
                   GenreId=3,
                   GenreName="formal"
                }
            };


            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genres");

                entity.Property(e => e.GenreName)
                .HasMaxLength(10);
                entity.HasIndex(e => e.GenreName).IsUnique();
                entity.HasData(GenresList);
            });

            var SportsList = new List<Sport>()
            {
                new Sport
                {
                    SportId=1,
                   SportName="basquet"
                },
                new Sport
                {
                   SportId=2,
                   SportName="futbol"
                },
                new Sport
                {
                   SportId=3,
                   SportName="tenis"
                }
            };

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.ToTable("Sports");

                entity.Property(e => e.SportName)
                .HasMaxLength(20);
                entity.HasIndex(e => e.SportName).IsUnique();
                entity.HasData(SportsList);
            });


            var ShoesList = new List<Shoe>()
            {
                new Shoe
                {
                   ShoeId=1,
                   BrandId=1,
                   ColourId=1,
                   GenreId=1,
                   SportId=1,
                   Model="Soft",
                   Description="Ideal para los juanetes",
                   Price=222000
                },
                new Shoe
                {
                   ShoeId=2,
                   BrandId=1,
                   ColourId=1,
                   GenreId=1,
                   SportId=1,
                   Model="Clasic",
                   Description="El clasico de los juanetes",
                   Price=600000
                },
                new Shoe
                {
                   ShoeId=3,
                   BrandId=1,
                   ColourId=1,
                   GenreId=1,
                   SportId=1,
                   Model="Storm",
                   Description="No tan buenos para los juanetes",
                   Price=542000
                }
            };

            modelBuilder.Entity<Shoe>(entity =>
            {
                entity.ToTable("Shoes");

                entity.Property(e => e.Model)
                .HasMaxLength(150)
                .IsRequired();
                entity.HasIndex(e => e.Model).IsUnique();

                entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsRequired();
                entity.HasData(ShoesList);

                entity.Property(e => e.Model).IsRequired();
                entity.Property(e => e.Description).IsRequired();

            });

            //Cambiar el decimal del precio a (10,2)
            modelBuilder.Entity<Shoe>(entity =>
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)")

            // en MODEL y DESCRIPCION tiene caracteristica: "no nulo"
            // es lo mismo que que IsRequired()?
            );

            //
            // ------------- PARTE 3  -----------
            //

            // aca va lo de URI????
            //está bien asi??
            List<Size> sizes = new List<Size>();
            int keyId = 0;
            for (decimal i = 28; i <= 50; i += .5m)
            {
                keyId++;
                var size = new Size()
                {
                    SizeId = keyId,
                    SizeNumber = i,
                };
                sizes.Add(size);
            }

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Sizes");
                entity.HasIndex(e => e.SizeNumber).IsUnique();
                entity.Property(e => e.SizeNumber).HasColumnType("decimal(3, 1)");
                entity.HasData(sizes);
            });

            modelBuilder.Entity<SizeShoe>(entity =>
            {
                entity.ToTable("SizeShoes");
                entity.Property(e => e.Stok).IsRequired();
             
            });
        }
    }

}
