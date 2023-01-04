using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.Add(new Rental { CarId = 20, CustomerId = 5, RentDate = new DateTime(2022, 07, 12, 01,29, 10) });
            if (result.Success == false)
            {
                Console.WriteLine(result.Message);

            }
            foreach (var rental in rentalManager.GetRentalsDetail().Data)
            {
                Console.WriteLine("{0} / {1} / {2} /     {3}--->>>{4}--->>>{5}  ", rental.FirstName,rental.BrandName,rental.DailyPrice,rental.Email,
                    rental.RentDate,rental.ReturnDate);


            }









        }

        private static void CustomerDetailDtoTest(CustomerManager customerManager)
        {
            var result = customerManager.Add(new Customer { UserId = 5, CompanyName = "Rito Games" });
            Console.WriteLine(result.Success);
            customerManager.Add(new Customer { UserId = 2, CompanyName = "Teams Worlds" });



            foreach (var customer in customerManager.GetCustomersDetail().Data)
            {
                Console.WriteLine("{0} {1}--->>> {2}--->>> {3}", customer.FirstName, customer.LastName, customer.CompanyName, customer.Email);


            }
        }

        private static void CarDetailDtoTest(CarManager carManager)
        {
            
            var result1 = carManager.Add(new Car { BrandId = 1, ColorId = 3, DailyPrice = 400, Description = "Osman", ModelYear = 2020 });
            Console.WriteLine(result1.Message);
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                Console.WriteLine(result.Message);

                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} / {1} / {2} / {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);

                }


            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}

       
        

    

