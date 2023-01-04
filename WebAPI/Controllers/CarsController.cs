using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carservice;

        public CarsController(ICarService carservice)
        {
            _carservice = carservice;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carservice.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carservice.GetById(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
                   
        }

        [HttpGet("getcarsbybrandid")]    
        public IActionResult GetCarsByBrandId(int id)
        {
            var result = _carservice.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _carservice.GetCarsByColorId(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carservice.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carservice.Add(car);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carservice.Update(car);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carservice.Delete(car);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

    }
}
