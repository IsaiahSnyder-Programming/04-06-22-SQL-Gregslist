using System.ComponentModel.DataAnnotations;


namespace Gregslist2.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

    }
}