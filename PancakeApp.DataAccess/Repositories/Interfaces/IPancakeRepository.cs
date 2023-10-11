
namespace PancakeApp.DataAccess.Repositories.Interfaces
{
    using PancakeApp.Domain.Models;
    public interface IPancakeRepository : IRepository<Pancake>
    {
        List<Pancake> GetPancakesOnPromotion();
    }
}
