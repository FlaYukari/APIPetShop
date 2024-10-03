using PetShop.Model;

namespace PetShop.Repositories
{
    public interface ITutorRepository: IRepository<Tutor>
    {
        bool TutorExiste(int tutorId);
        public Tutor GetTutorPorPet(int petId);
    }
}
