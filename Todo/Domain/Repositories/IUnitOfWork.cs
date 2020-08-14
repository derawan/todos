using System.Threading.Tasks;

namespace Todo.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
