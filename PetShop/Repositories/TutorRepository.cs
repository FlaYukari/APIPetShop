using PetShop.Context;
using PetShop.Model;

namespace PetShop.Repositories
{
    public class TutorRepository : Repository<Tutor>, ITutorRepositoy
    {
        public TutorRepository(APIPetShopDbContext context) : base(context) 
        { 

        }
    }
}
