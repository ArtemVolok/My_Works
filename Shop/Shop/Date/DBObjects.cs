using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                     new Car
                     {
                         name = "Tesla Model S",
                         shortDesk = "Быстрый автомобиль",
                         longDesc = "красивый быстрый и очень тихий автомобиль компании Tesla",
                         img = "/img/tesla.jpg",
                         price = 45000,
                         isFovourite = true,
                         available = true,
                         Category = Categories["Электромобили"]
                     },

                    new Car
                    {
                        name = "Ford Fiesta",
                        shortDesk = "Тихий и спокойный",
                        longDesc = "удобный автомобиль для городской жизни",
                        img = "/img/fiesta.jpg",
                        price = 11000,
                        isFovourite = false,
                        available = true,
                        Category = Categories["Классические автомобили"]
                    },

                    new Car
                    {
                        name = "BMW M3",
                        shortDesk = "Дерзкий и стильный",
                        longDesc = "удобный автомобиль для городской жизни",
                        img = "/img/m3.jpg ",
                        price = 65000,
                        isFovourite = true,
                        available = true,
                        Category = Categories["Классические автомобили"]
                    },

                    new Car
                    {
                        name = "Mersedes C class",
                        shortDesk = "Уютный и большой",
                        longDesc = "удобный автомобиль для городской жизни",
                        img = "/img/mercedes.jpg",
                        price = 40000,
                        isFovourite = false,
                        available = false,
                        Category = Categories["Классические автомобили"]
                    },

                    new Car
                    {
                        name = "Nissan Leaf",
                        shortDesk = "Бесшумный и экономный",
                        longDesc = "удобный автомобиль для городской жизни",
                        img = "/img/nissan.jpg",
                        price = 14000,
                        isFovourite = true,
                        available = true,
                        Category = Categories["Электромобили"]
                    }
                );
            }

            content.SaveChanges();

        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
            if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category { categoryName = "Электромобили", desc= "Современный вид транспорта" },
                        new Category { categoryName = "Классические автомобили", desc= "Машины с двигателем внутреннего згорания" }
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }

                return category;
            }
        }

       
    }
}
