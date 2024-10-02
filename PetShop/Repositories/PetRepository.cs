using PetShop.Context;
using PetShop.Model;

namespace PetShop.Repositories
{
    public class PetRepository : Repository<Pet>, IPetRepository
    {
        //a palavra base é usada para acessar membros de classe base de dentro de uma classe derivada
        public PetRepository(APIPetShopDbContext context) : base(context)
        {
        }

        public IEnumerable<Pet> GetPetsPorTutor(int id)
        {
            return GetAll().Where(c => c.TutorId == id);
        }
    }
}
