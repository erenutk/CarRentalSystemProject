using Core.Utilies.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService 
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int Id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int BrandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int ColorId);
        IDataResult<List<CarDetailDto>> GetCarsByBrandAndColorId(int BrandId, int ColorId);
        IDataResult<List<CarDetailDto>> GetCarDetails(int carId);
        IDataResult<List<CarDetailDto>> GetAllCarsDetails();
    }
}