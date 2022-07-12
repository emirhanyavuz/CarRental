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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;

        }

        public Result Add(Color color)
        {
            if (color.Name.Length < 2)
            {
                return new ErrorResult(Messages.ColorNameInvalid);

            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public Result Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
            
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id),Messages.ColorListed);
        }

        public Result Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult();
        }
    }
}
