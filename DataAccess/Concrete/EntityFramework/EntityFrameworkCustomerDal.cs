using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EntityFrameworkCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {             
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.Id equals c.UserId
                             select new CustomerDetailDto
                             {
                                       Id = c.Id,
                                       UserId = u.Id,
                                       FirstName = u.FirstName,
                                       LastName = u.LastName,
                                       CompanyName = c.CompanyName,
                                       Email = u.Email                                     
                             };
                return result.ToList();
            }
        }
                      
    }
}

