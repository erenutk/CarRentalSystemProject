using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EntityFrameworkCarDal());
            BrandManager brandManager = new BrandManager(new EntityFrameworkBrandDal());
            ColorManager colorManager = new ColorManager(new EntityFrameworkColorDal());
            UserManager userManager = new UserManager(new EntityFrameworkUserDal());
            CustomerManager customerManager = new CustomerManager(new EntityFrameworkCustomerDal());
            RentalManager rentalManager = new RentalManager(new EntityFrameworkRentalDal());
            
            //var result1 =rentalManager.Add(new Rental {CarId=1,CustomerId=1,RentDate=DateTime.Now, ReturnDate=null });
            //rentalManager.Update(new Rental { Id = 1 , CarId = 1, CustomerId = 1, RentDate = DateTime.Today, ReturnDate =DateTime.Now });

            //rentalManager.Delete(new Rental { Id = 3 });
            var result = rentalManager.Add(new Rental { CarId = 4, CustomerId = 1, RentDate = DateTime.Now });
            Console.WriteLine(result.Message);

            //User user1 = new User {FirstName="Elif",LastName="Karataş,",Email="dda@sd",Password="123" };
            //Customer customer1 = new Customer {UserId=1,CompanyName="x" };
            //userManager.Add(user1);
            //customerManager.Add(customer1);
            //var customerdetails =customerManager.GetCustomerDetails();
            //if (customerdetails.Success==true)
            //{
            //    foreach (var customer in customerdetails.Data)
            //    {
            //        Console.WriteLine(customer.Id + customer.FirstName + customer.CompanyName);
            //    }
            //}

            //// Name = "Toyota Verso", BrandId = 4, ColorId = 5, ModelYear = 2017, DailyPrice = 130, Description = "Manuel Vites"
            //Car car1 = new Car { Name = "ama ", BrandId = 4, ColorId = 5, DailyPrice = 130,ModelYear=2013, Description= "Manuel Vites" };
            //Car car2 = new Car { Name = "dsadas", BrandId = 1, ColorId = 1, DailyPrice = 100, ModelYear = 2015, Description = "122313" };
            //Console.WriteLine("-------CAR-------\n");

            //var result = carManager.GetCarDetails();

            //if (result.Success==true)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        Console.WriteLine(car.CarName + " /" + car.BrandName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
            ////carManager.Add(car1);
            //var result1 = carManager.Add(car1);
            //Console.WriteLine(result1.Message);


            //carManager.Add(car1); 
            //Console.WriteLine(carManager.Add(car1).Message);  // messages fonksiyonunu test et
            //carManager.Delete(car1);

            //carManager.Add(car1);

            //carManager.Update(new Car { Id = car1.Id, Name = "Toyota Auris", BrandId = 4, ColorId = 5, ModelYear = 2017, DailyPrice = 120, Description = "Manuel Vites" });
            //Console.WriteLine("\nMevcut Arabalar \n");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Id + " " + car.Name);
            //}

            //Console.WriteLine();
            //carManager.Delete(car1);


            //Console.WriteLine();
            //Console.WriteLine("Id'si 3 olan araba : {0}", carManager.GetById(3).Name);

            //Console.WriteLine();
            //Console.WriteLine("Araba \t\t\t Marka \t\t Renk \t\t Günlük Ücret");

            //foreach (var car in carManager.GetCarDetails())
            //{
            //    Console.WriteLine("{0}\t\t {1}\t {2}\t\t {3} ", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            //}
            //Console.WriteLine("\n");

            //Console.WriteLine("-------COLOR-------\n");

            //Color color1 = new Color { Name = "Pembe" };
            //colorManager.Add(color1);
            //colorManager.Update(new Color { Id = color1.Id, Name = "Turkuaz" });

            //Console.WriteLine("\nMevcut Renkler \n");
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine("{0} {1}", color.Id, color.Name);
            //}

            //Console.WriteLine();
            //colorManager.Delete(color1);

            //Console.WriteLine();
            //Console.WriteLine("Id'si 3 olan renk : {0}", colorManager.GetById(3).Name);

            //Console.WriteLine("\n");

            //Console.WriteLine("-------BRAND-------\n");

            //Brand brand1 = new Brand { Name = "Bentley" };
            //brandManager.Add(brand1);
            //brandManager.Update(new Brand { Id = brand1.Id, Name = "Bugatti" });

            //Console.WriteLine("\nMevcut Markalar \n");
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine("{0} {1}", brand.Id, brand.Name);
            //}

            //Console.WriteLine();
            //brandManager.Delete(brand1);

            //Console.WriteLine();
            //Console.WriteLine("Id'si 3 olan marka : " + brandManager.GetById(3).Name);

        }
    }
}