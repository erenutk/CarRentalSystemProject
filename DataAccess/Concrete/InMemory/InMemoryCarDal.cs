using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=300,Description="Renault Megane Sedan",ModelYear=2011},
                new Car{Id=2,BrandId=5,ColorId=3,DailyPrice=450,Description="Fiat Egea Sedan",ModelYear=2006},
                new Car{Id=3,BrandId=34,ColorId=8,DailyPrice=200,Description="Renault Clio",ModelYear=2003},
                new Car{Id=4,BrandId=12,ColorId=4,DailyPrice=1000,Description="Volkswagen Passat",ModelYear=2000}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Console.WriteLine();
            Car carToDelete = _cars.Find(c => car.Id == c.Id);
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

        public List<CarDetailDto> GetAllCarsDetails()
        {
            throw new NotImplementedException();
        }

        public Car GetById(int Id)
        {
            return _cars.Find(c => c.Id == Id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByBrandId(int BrandId)
        {
            return GetAll().Where(c => c.BrandId == BrandId).ToList();
        }

        public List<Car> GetCarsByColorId(int ColorId)
        {
            return GetAll().Where(c => c.ColorId == ColorId).ToList();
        }

        public void Update(int CarId)
        {
            Car carToUpdate = _cars.Find(c => CarId == c.Id);
            Console.Write("Yeni ID'yi girin : ");
            carToUpdate.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Yeni BrandID'yi girin : ");
            carToUpdate.BrandId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Yeni ColorID'yi girin : ");
            carToUpdate.ColorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Yeni Günlük Ücreti girin : ");
            carToUpdate.DailyPrice = Convert.ToInt32(Console.ReadLine());
            Console.Write("Yeni Açıklamayı girin : ");
            carToUpdate.Description = Console.ReadLine();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }


    }
}