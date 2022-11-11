using BusnessLogic.DTOs;
using BusnessLogic.Interfies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace restfull_api_server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopsController : ControllerBase
    {

        private readonly ILaptopService phoneService;

        public LaptopsController(ILaptopService phoneService)
        {
            this.phoneService = phoneService;
        }

        [HttpGet("collection")]          // GET: ~/api/phones/collection
        //[HttpGet("/phone-collection")] // GET: ~/phone-collection
        public IActionResult GetAll()
        {
            return Ok(phoneService.GetAll());
        }

        // POST: ~/api/phones
        [HttpPost]
        public IActionResult Create([FromBody] LaptopDTO phone) // get parameter from body (JSON)
        {
            if (!ModelState.IsValid) return BadRequest();

            phoneService.Create(phone);

            return Ok();
        }

        // PUT: ~/api/phones
        [HttpPut]
        public IActionResult Edit([FromBody] LaptopDTO phone)
        {
            if (!ModelState.IsValid) return BadRequest();

            phoneService.Edit(phone);

            return Ok();
        }

        // DELETE: ~/api/phones
        [HttpDelete("id")]
        public IActionResult Delete([FromRoute] int id)
        {
            phoneService.Delete(id);
            return Ok();
        }
    }
}