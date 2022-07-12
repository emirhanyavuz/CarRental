using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _cardal;
        public CarManager(ICarDal carDal)
        {
            _cardal = carDal;

        }

        public IResult Add(Car car)
        {
            if (car.Description.Length<2)
            {
                return new ErrorResult(Messages.CarNameInvalid);

            }
            _cardal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _cardal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (System.DateTime.Now.Hour == 03)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(), Messages.CarsListed);

        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_cardal.Get(c => c.Id == id), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (System.DateTime.Now.Hour == 03)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetails(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(c => c.BrandId == id), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(c => c.ColorId == id), Messages.CarsListed);
        }

        public IResult Update(Car car)
        {
            _cardal.Update(car);
            return new SuccessResult();
        }
    }
}
