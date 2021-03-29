using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilies.BusinessRules;
using Core.Utilies.Helpers;
using Core.Utilies.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file,CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
            
            
        }

        public IResult Delete(CarImage carImage)
        {
            var imagePath = _carImageDal.Get(ci => ci.Id == carImage.Id).ImagePath;
            FileHelper.Delete(imagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {            
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int CarId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(CarId));           
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == Id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file,CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(ci => ci.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }

        private IResult CheckIfImageLimitExceeded(int CarId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == CarId).Count;
            if (result<5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarImageLimitExceeded);
        }
        private List<CarImage> CheckIfCarImageNull(int CarId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == CarId);
            if (result.Count == 0)
            {
                return new List<CarImage>{ new CarImage { CarId=CarId,Date=DateTime.Now,ImagePath = "default.png" } };
            }
            return result;
        }
    }
}
