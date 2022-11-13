using Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Laptop : IBaseEntity
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Model { get; set; }

        public string Color { get; set; }

        [Range(0, 100_000)]
        public decimal Price { get; set; }

        public int MemoryId { get; set; }
        [Range(0, 100_000)]
        public Memory? Memory { get; set; }

        [StringLength(1000, MinimumLength = 10)]
        public string? Description { get; set; }

    }
}