using Infra.DTOs;
using Infra.Entities;
using Infra.Interface;
using Microsoft.AspNetCore.Mvc;

namespace SmartInnovationTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        IPersonService _personService;

        PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("CreatePerson")]
        public IActionResult Index(PersonDTO person)
		{
            _personService.CreatePerson(person);

			return Ok(person);
		}
	}
}
