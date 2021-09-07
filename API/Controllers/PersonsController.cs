using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _personService;
        public PersonsController(IService<Person> personService)
        {
            _personService = personService;
        }
        public async Task<IActionResult> GetAll ()
        {
            var persons =  await _personService.GetAllAsync();
           
            return Ok(JsonConvert.SerializeObject(persons));
        }
        [HttpPost]
        public async Task<IActionResult> Save (Person person)
        {
            var newperson =await  _personService.AddAsync(person);
            return Ok(newperson);
        }
        [HttpDelete("{id}")]
        public IActionResult Remove (int Id)
        {
            var person =  _personService.GetByIdAsync(Id).Result;
            _personService.Remove(person);
            return NoContent();
        }

    }
}
