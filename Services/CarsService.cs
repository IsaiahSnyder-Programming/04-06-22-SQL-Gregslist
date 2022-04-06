using System;
using System.Collections.Generic;
using Gregslist2.Models;
using Gregslist2.Repositories;

namespace Gregslist2.Services
{
    public class CarsService
    {
        private readonly CarsRepository _repo;

        public CarsService(CarsRepository repo)
        {
            _repo = repo;
        }

        internal List<Car> Get()
        {
            return _repo.Get();
        }

        internal Car Get(int id)
        {
            Car found = _repo.Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Car Create(Car carData)
        {
            return _repo.Create(carData);
        }

        internal Car Update(Car carData)
        {
            Car original = Get(carData.Id);
            original.Description = carData.Description ?? original.Description;
            original.Price = carData.Price;
            original.Name = carData.Name ?? original.Name;
            _repo.Update(original);
            return original;
        }

        internal void Delete(int id)
        {
            Get(id);
            _repo.Delete(id);
        }
    }
}