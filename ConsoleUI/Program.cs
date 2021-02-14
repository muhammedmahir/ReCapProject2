using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManagerTest();
            //BrandManagerTest();
            //ColorManagerTest();
        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var brand in colorManager.GetAll())
            {
                Console.WriteLine(brand.ColorName);
            }
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {

                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Descriptions + " " + car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
