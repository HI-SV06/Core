using Microsoft.EntityFrameworkCore;

namespace Core.Data
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            //Below code Ensures that the latest database migrations are applied to the database.
            context.Database.Migrate();

            if (context.Products.Count() == 0 && context.Categories.Count() == 0)
            {
                //Creates two new Category objects with names "fruits" and "shirts".
                Category fruits = new Category { Name = "fruits" };
                Category shirts = new Category { Name = "shirts" };

                /*
                 * context.Products.AddRange(...) =>Adds new Product objects to the Products table.
                 */
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Apples",
                        Price = 2.5M,
                        Category = fruits,
                    },
                    new Product
                    {
                        Name = "Banaa",
                        Price = 3.5M,
                        Category = fruits,
                    },
                    new Product
                    {
                        Name = "Grapes",
                        Price = 5.5M,
                        Category = fruits,
                    },
                    new Product
                    {
                        Name = "Pineapple",
                        Price = 6.0M,
                        Category = fruits,
                    },
                    new Product
                    {
                        Name = "Back Shirt",
                        Price = 15.5M,
                        Category = shirts,
                    },
                    new Product
                    {
                        Name = "Orange Shirt",
                        Price = 16.5M,
                        Category = shirts,
                    },
                    new Product
                    {
                        Name = "Blue Shirt",
                        Price = 10.5M,
                        Category = shirts,
                    },
                    new Product
                    {
                        Name = "White Shirt",
                        Price = 15.5M,
                        Category = shirts,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
