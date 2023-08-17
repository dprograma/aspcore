using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{

		}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
				new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
				new Category { Id = 3, Name = "History", DisplayOrder = 3 }
				);

			modelBuilder.Entity<Product>().HasData(
				new Product {
					Id = 1,
					Title = "Fortune of time",
					Author = "Billy Spark",
					Description = "is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",

                    ISBN = "SWD9999001",
					ListPrice = 99,
					Price = 90,
					Price50 = 94,
					Price100 = 92,
                    CategoryId = 2,
                    ImageUrl = "",
				},
                new Product
                {
                    Id = 2,
                    Title = "Adventures of Sinbad",
                    Author = "Joddy Pearls",
                    Description = "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",

                    ISBN = "SWD9999002",
                    ListPrice = 100,
                    Price = 98,
                    Price50 = 95,
                    Price100 = 94,
                    CategoryId = 3,
                    ImageUrl = "",
                },
                new Product
                {
                    Id = 3,
                    Title = "Aladdin and the 4o thieves",
                    Author = "Andy Olsen",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.",

                    ISBN = "SWD9999003",
                    ListPrice = 88,
                    Price = 80,
                    Price50 = 74,
                    Price100 = 72,
                    CategoryId = 1,
                    ImageUrl = "",
                },
                new Product
                {
                    Id = 4,
                    Title = "Guardians of the galaxy",
                    Author = "Alice Badwick",
                    Description = "Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose.",

                    ISBN = "SWD9999004",
                    ListPrice = 109,
                    Price = 100,
                    Price50 = 104,
                    Price100 = 102,
                    CategoryId = 1,
                    ImageUrl = "",
                },
                new Product
                {
                    Id = 5,
                    Title = "Booths in boots",
                    Author = "Elena James",
                    Description = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text.",

                    ISBN = "SWD9999005",
                    ListPrice = 119,
                    Price = 109,
                    Price50 = 114,
                    Price100 = 112,
                    CategoryId = 2,
                    ImageUrl = "",
                },
                new Product
                {
                    Id = 6,
                    Title = "The million dollar story",
                    Author = "Ken programa",
                    Description = "All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable.",

                    ISBN = "SWD9999006",
                    ListPrice = 129,
                    Price = 119,
                    Price50 = 114,
                    Price100 = 112,
                    CategoryId = 3,
                    ImageUrl = "",
                }

                );
        }
    }

}

