using System.Linq.Expressions;

namespace PetShop.Repositories
{
    public interface IRepository<T>
    {
        //Não violar o Princípio ISP: Interface Segregation Principle (os clientes da interface não devem ser forçados a depender de interface que não utilizam.
        IEnumerable<T> GetAll();

        T? Get(Expression<Func<T, bool>> predicate);

        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);

    }
}
