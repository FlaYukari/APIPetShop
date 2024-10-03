using PetShop.Model;

namespace PetShop.Repositories
{
    public interface IPetRepository : IRepository<Pet>
    {
        public bool PetExiste(int petId);
        public IEnumerable<Pet> GetPetsPorTutor(int id);
    }
}
