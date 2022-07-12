using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext carRentalContext=new CarRentalContext())
            {
                var result = from c in carRentalContext.Cars
                             join b in carRentalContext.Brands
                             on c.BrandId equals b.Id
                             join co in carRentalContext.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 CarName = c.Description,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice,
                                 
                             };

                return result.ToList();

            }
        }
    }
}
