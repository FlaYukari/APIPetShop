using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.Model;
using PetShop.Repositories;

namespace PetShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        private readonly ITutorRepository _tutorRepository;

        public PetController(IPetRepository petRepository, ITutorRepository tutorRepository)
        {
            _petRepository = petRepository;
            _tutorRepository = tutorRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            var pets = _petRepository.GetAll();
            return Ok(pets);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Pet> Get(int id)
        {
            var pet = _petRepository.Get(c => c.PetId == id);
            if(pet == null)
                return NotFound();
            return Ok(pet);
        }

        [HttpPost]
        public ActionResult<Pet> Post(Pet pet)
        {
            if (pet is null)
                return BadRequest("Dados inválidos.");
            if(pet.TutorId <=0 || !_tutorRepository.TutorExiste(pet.TutorId))
                return BadRequest("Esse tutor não existe. Escolha um tutor cadastrado,");
            var petNovo = _petRepository.Create(pet);
            return Ok(petNovo);
        }

        [HttpPut]
        public ActionResult<Pet> Update(Pet pet)
        {
            if (pet is null)
                return BadRequest(new
                {
                    status = 400,
                    error = "Bad Request",
                    message = "O corpo da requisição não pode ser nulo.",
                    details = "Por favor, verifique os dados enviados e tente novamente."
                });
            var petAtualizado = _petRepository.Update(pet);
            return Ok(petAtualizado);
        }

        [HttpDelete]
        public ActionResult Delete(Pet pet)
        {
            if(pet is null)
                return NotFound();
            var petExcluido = _petRepository.Delete(pet);
            return Ok(petExcluido);
        }

        [HttpGet("PetsPorTutor/{tutorId}")]
        public ActionResult<IEnumerable<Pet>> ObterPetsPorTutor(int tutorId)
        {
            var tutorExiste = _tutorRepository.TutorExiste(tutorId);
            if(!tutorExiste)
                return NotFound("Este Tutor não existe. Por favor, cadstre o tutor desejado.");
            var pets = _petRepository.GetPetsPorTutor(tutorId);
            if (pets == null)
                return NotFound("Este Tutor não tem pets cadastrados.");
            return Ok(pets);
        }
    }
}
