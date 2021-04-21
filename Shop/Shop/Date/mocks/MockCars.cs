using Shop.Date.interfaces;
using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date.mocks
{
    public class MockCars : IAllCars { 

    private readonly ICarsCategory _categoryCars = new MockCategory();
    
        public IEnumerable<Car> Cars {

            get
            {
                return new List<Car>
                {

                    new Car
                    {
                        name = "Tesla Model S",
                        shortDesk = "Быстрый автомобиль",
                        longDesc = "красивый быстрый и очень тихий автомобиль компании Tesla",
                        img = "/img/tesla.jpg",
                        price = 45000,
                        isFovourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
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
                        Category = _categoryCars.AllCategories.Last()
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
                        Category = _categoryCars.AllCategories.Last()
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
                        Category = _categoryCars.AllCategories.Last()
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
                        Category = _categoryCars.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Car> getFavCars { get ; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
