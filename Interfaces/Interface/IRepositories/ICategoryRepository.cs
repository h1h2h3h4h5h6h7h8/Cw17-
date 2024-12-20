using ShopManagement.Domain.Entities;


namespace Interfaces.Interfaces.IRepositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
    }
}
