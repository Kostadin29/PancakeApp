
namespace PancakeApp.DataAccess.Repositories.Interfaces
{
    using PancakeApp.Domain.Models;
    public interface IRepository<T> where T : BaseEntity
    {
        // CRUD Operations
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert (T entity);
        Task Update (T entity);
        Task<int> DeleteById (int id);
    }
}
