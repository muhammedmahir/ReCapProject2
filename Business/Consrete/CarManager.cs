using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Consrete
{
    public class CarManager : ICarService
    {
        //injection yapıyoruz. 
        //Bunu veri erişim seçeneğimizi belirlemek için yapıyoruz. 
        //ICarDal referansı alıyoruz. 
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            // İş kodları
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetAllByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(p => p.DailyPrice > min && p.DailyPrice <= max);
        }
    }
}
