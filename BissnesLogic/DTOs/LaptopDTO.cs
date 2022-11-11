using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnessLogic.DTOs
{
    public class LaptopDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MemoryId { get; set; }
        public string? MemoryName { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string? Description { get; set; }
    }
}