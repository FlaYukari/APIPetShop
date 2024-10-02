using PetShop.Model;

namespace PetShop.Repositories
{
    public interface IPetRepository : IRepository<Pet>
    {
        public IEnumerable<Pet> GetPetsPorTutor(int id);
    }
}
