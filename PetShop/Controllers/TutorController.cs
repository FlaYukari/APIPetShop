using Microsoft.AspNetCore.Mvc;
using PetShop.Model;
using PetShop.Repositories;

namespace PetShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ITutorRepository _tutorRepository;
        private readonly IPetRepository _petRepository;

        public TutorController(ITutorRepository tutorRepository, IPetRepository petRepository)
        {
            _tutorRepository = tutorRepository;
            _petRepository = petRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tutor>> Get()
        {
            var tutores = _tutorRepository.GetAll();
            return Ok(tutores);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Tutor> Get(int id)
        {
            var tutor = _tutorRepository.Get(c => c.TutorId == id);
            if(tutor == null)
                return NotFound();
            return Ok(tutor);
        }

        [HttpPost]
        public ActionResult<Tutor> Post(Tutor tutor)
        {
            if (tutor is null)
                return BadRequest("Dados inválidos.");
            var tutorNovo = _tutorRepository.Create(tutor);
            return Ok(tutorNovo);
        }

        [HttpPut]
        public ActionResult<Tutor> Update(Tutor tutor)
        {
            if (tutor is null)
                return BadRequest(new
                {
                    status = 400,
                    error = "Bad Request",
                    message = "O corpo da requisição não pode ser nulo.",
                    details = "Por favor, verifique os dados enviados e tente novamente."
                });
            var tutorAtualizado = _tutorRepository.Update(tutor);
            return Ok(tutorAtualizado);
        }

        [HttpDelete]
        public ActionResult Delete(Tutor tutor)
        {
            if(tutor is null)
                return NotFound();
            var tutorExcluido = _tutorRepository.Delete(tutor);
            return Ok(tutorExcluido);
        }

        [HttpGet("TutorPorPet/{petId}")]
        public ActionResult ObterTutorPorPet(int petId)
        {
            var petExiste = _petRepository.PetExiste(petId);
            if(!petExiste)
                return NotFound("Este Pet não existe.");
            var pet = _petRepository.Get(c => c.PetId == petId);
            var tutorExiste = _tutorRepository.TutorExiste(pet.TutorId);
            if (!tutorExiste)
                return NotFound("Este tutor não existe.");
            return Ok(_tutorRepository.GetTutorPorPet(petId));
        }
    }
}
