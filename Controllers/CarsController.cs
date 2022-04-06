using System;
using System.Collections.Generic;
using Gregslist2.Models;
using Gregslist2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gregslist2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarsService _bs;

        public CarsController(CarsService bs)
        {
            _bs = bs;
        }

        // GetAll
        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            try
            {
                List<Car> cars = _bs.Get();
                return Ok(cars);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GetById
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            try
            {
                Car car = _bs.Get(id);
                return Ok(car);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Post
        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car carData)
        {
            try
            {
                Car car = _bs.Create(carData);
                // return Ok(car);
                return Created($"api/cars/{car.Id}", car);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Put
        [HttpPut("{id}")]
        public ActionResult<Car> Update(int id, [FromBody] Car carData)
        {
            try
            {
                carData.Id = id;
                Car car = _bs.Update(carData);
                return Ok(car);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Delete
        [HttpDelete("{id}")]
        public ActionResult<String> Delete(int id)
        {
            try
            {
                _bs.Delete(id);
                return Ok("Delorted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}