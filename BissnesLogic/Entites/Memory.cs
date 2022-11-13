using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public enum Memories : int
    {
        Smal = 1,
        Ser,
        Big,
    }
    public class Memory : IBaseEntity
    {
        public int Id { get; set; }
        [Required, MinLength(3)]
        public string Name { get; set; }

        public ICollection<Laptop> Laptops { get; set; } = new HashSet<Laptop>();
    }
}