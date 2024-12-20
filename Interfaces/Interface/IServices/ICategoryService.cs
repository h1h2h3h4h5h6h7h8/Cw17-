using ShopManagement.Domain.Entities;


namespace Interfaces.Interfaces.IServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
    }
}
