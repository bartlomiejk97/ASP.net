using System;
using System.Linq;
using LibApp_Gr3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp_Gr3.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.MembershipTypes.Any())
                {
                    Console.WriteLine("MembershipTypes table already seeded");
                }
                else
                {
                    context.MembershipTypes.AddRange(
                          new MembershipType
                          {
                              Id = 1,
                              SignUpFee = 0,
                              DurationInMonths = 0,
                              DiscountRate = 0
                          },
                          new MembershipType
                          {
                              Id = 2,
                              SignUpFee = 30,
                              DurationInMonths = 1,
                              DiscountRate = 10
                          },
                          new MembershipType
                          {
                              Id = 3,
                              SignUpFee = 90,
                              DurationInMonths = 3,
                              DiscountRate = 15
                          },
                          new MembershipType
                          {
                              Id = 4,
                              SignUpFee = 300,
                              DurationInMonths = 12,
                              DiscountRate = 20
                          });
                }
                if (context.Books.Any())
                {
                    Console.WriteLine("Books table already seeded");
                }
                else
                {
                    context.Books.AddRange(
                        new Book
                        {
                            Author = "Adam Freeman",
                            Name = "ASP.NET Core 3. Zaawansowane programowanie. Wydanie VIII",
                            NumberInStock = 5,
                            PublicationYear = 2020,
                            PublishingHouse = "Helion"
                        },
                        new Book
                        {
                            Author = "Adam Freeman",
                            Name = "ASP.NET Core 3. Zaawansowane programowanie. Wydanie VIII",
                            NumberInStock = 5,
                            PublicationYear = 2020,
                            PublishingHouse = "Helion"
                        },
                        new Book
                        {
                            Author = "Dino Esposito",
                            Name = "Projektowanie w ASP.NET Core",
                            NumberInStock = 2,
                            PublicationYear = 2020,
                            PublishingHouse = "Promise"
                        },
                        new Book
                        {
                            Author = "Gynvael Coldwind",
                            Name = "Zrozumieć programowanie",
                            NumberInStock = 15,
                            PublicationYear = 2015,
                            PublishingHouse = "Wydawnictwo Naukowe PWN"
                        });
                    context.SaveChanges();
                }

                if (context.Customers.Any())
                {
                    Console.WriteLine("Customers table already seeded");
                }
                else
                {
                    context.Customers.AddRange(
                        new Customer
                        {
                            Name = "Jan Nowak",
                            HasNewsletterSubscribed = true,
                            MembershipTypeId = 1,
                        },
                        new Customer
                        {
                            Name = "Piotr Kowalski",
                            HasNewsletterSubscribed = false,
                            MembershipTypeId = 2,
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}