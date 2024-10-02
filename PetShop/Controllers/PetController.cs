using Microsoft.AspNetCore.Mvc;
using PetShop.Model;
using PetShop.Repositories;

namespace PetShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;

        PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
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

        [HttpGet("PetsPorTutor/{id}")]
        public ActionResult<IEnumerable<Pet>> ObterPetsPorTutor(int id)
        {
            var pets = _petRepository.GetPetsPorTutor(id);
            if (pets == null)
                return NotFound("");
            else if (pets.Any())
                //resposta 204:
                //return NoContent();
                //resposta 404:
                return NotFound("Este Tutor não possui pets cadastrados.");
            return Ok(pets);
        }
    }
}
