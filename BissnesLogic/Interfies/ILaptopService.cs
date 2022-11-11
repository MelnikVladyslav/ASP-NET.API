using BusnessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnessLogic.Interfies
{
    public interface ILaptopService
    {
        IEnumerable<LaptopDTO> GetAll();
        void Create(LaptopDTO laptop);
        void Edit(LaptopDTO laptop);
        void Delete(int id);
    }
}
