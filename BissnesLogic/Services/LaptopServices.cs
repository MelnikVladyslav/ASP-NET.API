using AutoMapper;
using BissnesLogic.Resourses;
using BusinessLogic.Exceptions;
using BusnessLogic.DTOs;
using BusnessLogic.Interfies;
using Core.Interfaces;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusnessLogic.Services
{
    public class LaptopServices : ILaptopService
    {
        private readonly IRepository<Laptop> phoneRepo;
        private readonly IMapper mapper;

        public LaptopServices(IRepository<Laptop> phoneRepo, IMapper mapper)
        {
            this.phoneRepo = phoneRepo;
            this.mapper = mapper;
        }

        public void Create(LaptopDTO phone)
        {

            phoneRepo.Insert(mapper.Map<Laptop>(phone));
            phoneRepo.Save();
        }

        public void Delete(int id)
        {
            var phone = phoneRepo.GetByID(id);

            if (phone == null)
                throw new HttpException(ErrorMessage.LaptopNotFound, HttpStatusCode.NotFound);

            phoneRepo.Delete(phone);
            phoneRepo.Save();
        }

        public void Edit(LaptopDTO phone)
        {
            phoneRepo.Update(mapper.Map<Laptop>(phone));
            phoneRepo.Save();
        }

        public IEnumerable<LaptopDTO> GetAll()
        {
            var phones = phoneRepo.Get(includeProperties: $"{nameof(Laptop.Memory)}");
            return mapper.Map<IEnumerable<LaptopDTO>>(phones);
        }
    }
}
