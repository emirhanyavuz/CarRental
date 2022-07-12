using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<CustomerDetailDto>> GetCustomersDetail();
        IDataResult<Customer> Get(int id);

        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);

        IResult DeleteByUserId(int userId);
    }
}
