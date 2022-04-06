using System.Collections.Generic;
using System.Data;
using System.Linq;
using Gregslist2.Models;
using Dapper;

namespace Gregslist2.Repositories
{
    public class CarsRepository
    {
        private readonly IDbConnection _db;

        public CarsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Car> Get()
        {
            string sql = "SELECT * FROM cars;";
            return _db.Query<Car>(sql).ToList();
        }

        internal Car Get(int id)
        {
            string sql = "SELECT * FROM cars WHERE id = @id;";
            return _db.QueryFirstOrDefault<Car>(sql, new { id });
        }

        internal Car Create(Car carData)
        {
            string sql = @"
        INSERT INTO cars
        (name, description, price)
        VALUES
        (@Name, @Description, @Price);
        SELECT LAST_INSERT_ID();";
            // ^^ this method returns the ID of the last object created;
            // vv This runs Two Command sequentially
            int id = _db.ExecuteScalar<int>(sql, carData);
            carData.Id = id;
            return carData;
        }

        internal void Update(Car original)
        {
            string sql = @"
            UPDATE cars
            SET
            description = @Description,
            name = @Name,
            price = @Price
            WHERE id = @Id;";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM cars WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}