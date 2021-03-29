using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EntityFrameworkCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        //public List<CarDetailDto> GetCarsByBrandId(int BrandId)
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        var result = from c in context.Cars
        //                     join cl in context.Colors
        //                     on c.ColorId equals cl.Id
        //                     join b in context.Brands
        //                     on c.BrandId equals b.Id
        //                     //join i in context.CarImages
        //                     //on c.Id equals i.CarId
        //                     where b.Id == BrandId
        //                     select new CarDetailDto
        //                     {
        //                         Id = c.Id,
        //                         CarName = c.Name,
        //                         BrandName = b.Name,
        //                         ColorName = cl.Name,
        //                         ModelYear = c.ModelYear,
        //                         DailyPrice = c.DailyPrice,
        //                         Description = c.Description,
        //                         ImagePath= (from a in context.CarImages where a.CarId == c.Id select a.ImagePath).FirstOrDefault()

        //                     };
        //        return result.ToList();
        //    }
        //}

        //public List<CarDetailDto> GetCarsByColorId(int ColorId)
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        var result = from c in context.Cars
        //                     join cl in context.Colors
        //                     on c.ColorId equals cl.Id
        //                     where cl.Id == ColorId
        //                     join b in context.Brands
        //                     on c.BrandId equals b.Id
        //                     //join i in context.CarImages
        //                     //on c.Id equals i.CarId
        //                     select new CarDetailDto
        //                     {
        //                         Id = c.Id,
        //                         CarName = c.Name,
        //                         BrandName = b.Name,
        //                         ColorName = cl.Name,
        //                         ModelYear = c.ModelYear,
        //                         DailyPrice = c.DailyPrice,
        //                         Description = c.Description,
        //                         ImagePath= (from a in context.CarImages where a.CarId == c.Id select a.ImagePath).FirstOrDefault()

        //                     };
        //        return result.ToList();
        //    }
        //}
        public List<CarDetailDto> GetCarDetails(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             where c.Id == carId
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join i in context.CarImages
                             on c.Id equals i.CarId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.Name,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ImagePath = i.ImagePath

                             };
                return result.ToList();
            }
        }

        //public List<CarDetailDto> GetAllCarsDetails()
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        var result = from c in context.Cars
        //                     join cl in context.Colors
        //                     on c.ColorId equals cl.Id
        //                     join b in context.Brands
        //                     on c.BrandId equals b.Id
        //                     //join i in context.CarImages
        //                     //on c.Id equals i.CarId
        //                     select new CarDetailDto
        //                     {
        //                         Id = c.Id,
        //                         CarName = c.Name,
        //                         BrandName = b.Name,
        //                         ColorName = cl.Name,
        //                         ModelYear = c.ModelYear,
        //                         DailyPrice = c.DailyPrice,
        //                         Description = c.Description,
        //                         ImagePath = (from a in context.CarImages where a.CarId==c.Id select a.ImagePath).FirstOrDefault()

        //                     };
        //        return result.ToList();
        //    }
        //}

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.Name,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = (from a in context.CarImages where a.CarId == c.Id select a.ImagePath).FirstOrDefault()
                             };



                return result.ToList();
            }
        }
    }
}
