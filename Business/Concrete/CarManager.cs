using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilies.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {

            var result = _carDal.Get(c => c.Id == car.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.CarInvalid);
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);

        }

        //[SecuredOperation("admin")]
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == Id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandAndColorId(int BrandId, int ColorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId==BrandId & c.ColorId==ColorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int BrandId)
        {
            var result = _carDal.GetCarDetails(c=> c.BrandId==BrandId);
            if (result == null)
            {
                new ErrorDataResult<List<CarDetailDto>>();
                Console.WriteLine("Bu markada araba bulunmamaktadır.");

            }
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int ColorId)
        {
            var result = _carDal.GetCarDetails(c=>c.ColorId==ColorId);
            if (result == null)
            {
                Console.WriteLine("Bu renkte araba bulunmamaktadır.");
                return new ErrorDataResult<List<CarDetailDto>>();

            }
            return new SuccessDataResult<List<CarDetailDto>>(result);

        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);


            //var carToUpdate= Car
            //if (car.Description.Length >= 2 && car.DailyPrice > 0)
            //{
            //    _carDal.Update(CarID);
            //}
            //if (car.Description.Length < 2)
            //{
            //    Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır.");
            //}
            //if (car.DailyPrice <= 0)
            //{
            //    Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır.");
            //}

        }

    }
}