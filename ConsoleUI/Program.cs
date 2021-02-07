using Business.Consrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());

            foreach (var car in carManager.GetAllByDailyPrice(130, 160))
            {
                Console.WriteLine(car.Descriptions);
            }
        }
    }
}
