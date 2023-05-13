namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.CCContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.CCContext context)
        {

            Random random = new Random();

            
            //Seed for User Table
            for (int i = 1; i <= 15; i++)
            {
                int year = random.Next(1950, 2022); // Generate a random year between 1950 and 2021
                int month = random.Next(1, 13); // Generate a random month between 1 and 12
                int daysInMonth = DateTime.DaysInMonth(year, month);
                int day = random.Next(1, daysInMonth + 1);
                int genderValue = random.Next(1, 3);
                context.Users.AddOrUpdate(new Models.User
                {
                    Name = Guid.NewGuid().ToString().Substring(0, 10),
                    Username = "username-" + i,
                    Dob = new DateTime(year, month, day),
                    Gender = (genderValue == 1) ? "Male" : "Female",
                    Phone = "01" + random.Next(1, 10).ToString() + random.Next(10000000, 99999999).ToString(),
                    Email = "username-" + i + "@gmail.com",
                    Address = "Road-" + (i * 3) + ", Area-" + ((12 * i) - 11),
                    Password = Guid.NewGuid().ToString().Substring(0, 6),
                    Type = "General"
                });
            }



            //Seed for Supplier Table
            for (int i = 1; i <= 15; i++)
            {
                int year = random.Next(1950, 2022); // Generate a random year between 1950 and 2021
                int month = random.Next(1, 13); // Generate a random month between 1 and 12
                int daysInMonth = DateTime.DaysInMonth(year, month);
                int day = random.Next(1, daysInMonth + 1);
                int genderValue = random.Next(1, 3);
                context.Suppliers.AddOrUpdate(new Models.Supplier
                {
                    Name = Guid.NewGuid().ToString().Substring(0, 10),
                    Username = "username-" + i,
                    Dob = new DateTime(year, month, day),
                    Gender = (genderValue == 1) ? "Male" : "Female",
                    Phone = "01" + random.Next(1, 10).ToString() + random.Next(10000000, 99999999).ToString(),
                    Email = "username-" + i + "@gmail.com",
                    Address = "Road-" + (i * 3) + ", Area-" + ((12 * i) - 11),
                    Password = Guid.NewGuid().ToString().Substring(0, 6)
                    
                });
            }


            //Seed for Shippers Table
            for (int i = 1; i <= 15; i++)
            {
                int year = random.Next(1950, 2022); // Generate a random year between 1950 and 2021
                int month = random.Next(1, 13); // Generate a random month between 1 and 12
                int daysInMonth = DateTime.DaysInMonth(year, month);
                int day = random.Next(1, daysInMonth + 1);
                int genderValue = random.Next(1, 3);
                context.Shippers.AddOrUpdate(new Models.Shipper
                {
                    Name = Guid.NewGuid().ToString().Substring(0, 10),
                    Username = "username-" + i,
                    Dob = new DateTime(year, month, day),
                    Gender = (genderValue == 1) ? "Male" : "Female",
                    Phone = "01" + random.Next(1, 10).ToString() + random.Next(10000000, 99999999).ToString(),
                    Email = "username-" + i + "@gmail.com",
                    Address = "Road-" + (i * 3) + ", Area-" + ((12 * i) - 11),
                    Password = Guid.NewGuid().ToString().Substring(0, 6)

                });
            }


            //Seed for Discount Table
            for (int i = 1; i <= 5; i++)
            {
                
                context.Discounts.AddOrUpdate(new Models.Discount
                {
                    Id = i,
                    Name = "Object " + i,
                    Description = Guid.NewGuid().ToString().Substring(0, 20),
                    DiscountPercent = random.Next(0, 50),
                    Active = random.Next(2) == 0 ? true : false,
                    CreatedDate = DateTime.UtcNow.AddDays(-random.Next(1, 30)),
                    UpdatedDate = DateTime.UtcNow.AddDays(-random.Next(1, 30))

                });
            }

            //Seed for Category Table
            for (int i = 1; i <= 10; i++)
            {
                string[] categories ={"Apparel and Accessories", "Beauty and Personal Care", "Electronics and Gadgets",
                                    "Home and Garden", "Health and Wellness", "Sports and Fitness", "Books and Media",
                                    "Toys and Games", "Food and Beverages", "Pet Supplies"};
                int index = random.Next(categories.Length);


                context.Categories.AddOrUpdate(new Models.Category
                {
                    Id = i,
                    Name = categories[index],
                    Description = Guid.NewGuid().ToString().Substring(0, 20),
                    CreatedDate = DateTime.UtcNow.AddDays(-random.Next(1, 30)),
                    UpdatedDate = DateTime.UtcNow.AddDays(-random.Next(1, 30))

                });
            }


            //Seed for Product Table
            for (int i = 1; i <= 100; i++)
            {
               
                context.Products.AddOrUpdate(new Models.Product
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 6),
                    Price = random.Next(5, 5000),
                    Description = Guid.NewGuid().ToString().Substring(0, 20),
                    CreatedDate = DateTime.UtcNow,
                    Quantity = random.Next(1, 8),
                    CategoryId = random.Next(1, 10),
                    DiscountId = random.Next(1, 5),
                    SupplyBy = "username-" + random.Next(1, 11)
                });
            }


            //Seed for Review Table
            for (int i = 1; i <= 10; i++)
            {
                string[] reviews = { "This product is not so good", "This product is good" };
                int index = random.Next(reviews.Length);

                context.Reviews.AddOrUpdate(new Models.Review
                {
                    Id = i,

                    Description = reviews[index],
                    ProductId = random.Next(1, 90),
                    ReviewBy = "username-" + random.Next(1, 11)

                });
            }

            //Seed for Wishlist Table
            for (int i = 1; i <= 10; i++)
            {
                //string[] reviews = { "This product is not so good", "This product is good" };
                //int index = random.Next(reviews.Length);

                context.WishLists.AddOrUpdate(new Models.WishList
                {
                    Id = i,
                    Description = "I NEED" + random.Next(1, 90),
                    ProductId = random.Next(1, 90),
                    WishBy = "username-" + random.Next(1, 11)

                });
            }

            //seed for Order Table
            for (int i = 1; i <= 17; i++)
            {
                int status = random.Next(1, 3);
                context.Orders.AddOrUpdate(new Models.Order
                {
                    Id = i,
                    OrderedBy = "username-" + random.Next(1, 11),
                    OrderDate = DateTime.Now,
                    DeliveryAddress = "Road-" + random.Next(1, 15) + ", Area-" + random.Next(2, 5),
                    TotalPrice = random.Next(2000, 3000),
                    Status = status == 1 ? "Pending" : "Deliverd",
                    DeliveryBy = "username-" + random.Next(1, 11)

                });
            }

            //seed for OrderDetails Table
            for (int i = 1; i <= 17; i++)
            {
                
                context.OrderDetails.AddOrUpdate(new Models.OrderDetail
                {
                    Id = i,
                    ProductId = random.Next(1, 90),
                    OrderId = random.Next(1, 10),
                    Quantity = random.Next(1, 90),
                    Price = random.Next(2000, 300000)

                });
            }
            //seed for payment table
            for(int i=1; i<=10; i++)
            {
                context.PaymentDetails.AddOrUpdate(new Models.PaymentDetail
                {
                    Id = i,
                    PaymentBy = "username-" + random.Next(1, 11),
                    OrderId = random.Next(1, 10),
                    PaymentDate = DateTime.Now,
                    PaymentMethod = "credit card",
                    Amount = random.Next(1, 3010),
                    Status = "completed"

                });
            }

            //seed for Cart table
            for (int i = 1; i <= 10; i++)
            {
                context.Carts.AddOrUpdate(new Models.Cart
                {
                    Id = i,
                    CartBy = "username-" + random.Next(1, 11),
                    CreatedAt = DateTime.Now,
                    DeletedAt = DateTime.Now.AddDays(1)

                });
            }

            //seed for CartItem table
            for (int i = 1; i <= 10; i++)
            {
                context.CartItems.AddOrUpdate(new Models.CartItem
                {
                    Id = i,
                    CartId = random.Next(1, 10),
                    ProductId = random.Next(1, 10),
                    Quantity = random.Next(1, 10),
                    CreatedAt = DateTime.Now,
                    DeletedAt = DateTime.Now.AddDays(1)
                   

                });
            }




            
        }
    }
}
