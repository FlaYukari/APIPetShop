using Microsoft.AspNetCore.Http.HttpResults;
using PetShop.Context;
using PetShop.Model;
using Microsoft.EntityFrameworkCore;

namespace PetShop.Repositories
{
    public class TutorRepository : Repository<Tutor>, ITutorRepository
    {
        public TutorRepository(APIPetShopDbContext context) : base(context) 
        { 
        }
        public Tutor GetTutorPorPet(int petId)
        {
            var pet = _context.Pets.FirstOrDefault(p => p.PetId == petId);
            // Usa o método Get para buscar o tutor pelo TutorId do pet
            return Get(t => t.TutorId == pet.TutorId);
        }

        public bool TutorExiste(int tutorId)
        {
            return _context.Tutores.Any(t => t.TutorId == tutorId);
        }
    }
}
