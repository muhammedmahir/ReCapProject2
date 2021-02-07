using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        //global nesne olduğu için alt çizgi ile başlatıyoruz.
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=100,ModelYear="2020",Descriptions ="Hyundai A" },
                new Car{CarId=2,BrandId=1,ColorId=2,DailyPrice=120,ModelYear="2019",Descriptions ="Hyundai B" },
                new Car{CarId=3,BrandId=2,ColorId=2,DailyPrice=140,ModelYear="2018",Descriptions ="Hyundai C" },
                new Car{CarId=4,BrandId=2,ColorId=3,DailyPrice=150,ModelYear="2017",Descriptions ="Hyundai D" },
                new Car{CarId=5,BrandId=2,ColorId=3,DailyPrice=160,ModelYear="2016",Descriptions ="Hyundai E" },
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            // Link kullanarak ilgili listedeki kayıtlar arasından silinecek oları seçiyoruz. mantığı yukarıdaki foreach gibi çalışır.

            //foreach (var c in _cars)
            //{
            //    if(car.CarId == c.CarId)
            //    {
            //        carToDelete = c;
            //    }
            //}



            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            // gönderdiğim ürün id sine sahip olan listedeki ürünü bul ve güncelle
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Descriptions = car.Descriptions;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
