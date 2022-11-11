using AutoMapper;
using BissnesLogic.Resourses;
using BusinessLogic.Exceptions;
using BusnessLogic.DTOs;
using BusnessLogic.Interfies;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BusnessLogic.Services
{
    public class LaptopServices : ILaptopService
    {
        private readonly StoreDbContext5 context;
        private readonly IMapper mapper;

        public LaptopServices(StoreDbContext5 context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Create(LaptopDTO phone)
        {

            context.Laptops.Add(mapper.Map<Laptop>(phone));
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var phone = context.Laptops.Find(id);

            if (phone == null)
                throw new HttpException(ErrorMessage.LaptopNotFound, HttpStatusCode.NotFound);

            context.Laptops.Remove(phone);
            context.SaveChanges();
        }

        public void Edit(LaptopDTO phone)
        {
            context.Laptops.Update(mapper.Map<Laptop>(phone));
            context.SaveChanges();
        }

        public IEnumerable<LaptopDTO> GetAll()
        {
            var phones = context.Laptops.Include(p => p.Memory).ToList();
            return mapper.Map<IEnumerable<LaptopDTO>>(phones);
        }
    }
}
