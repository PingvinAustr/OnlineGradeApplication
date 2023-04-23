using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository person)
        {
            _personRepository = person;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.PersonDTO>> GetPeople()
        {
            return _personRepository.GetPeopleAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.PersonDTO> GetPerson(int id)
        {
            var person = _personRepository.GetPersonAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);

        }
    }
}
