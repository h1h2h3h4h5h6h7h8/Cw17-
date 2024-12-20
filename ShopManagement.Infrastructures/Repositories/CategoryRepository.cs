
using Interfaces.Interfaces.IRepositories;
using ShopManagement.Domain.Entities;
using ShopManagement.Infrastructures.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructures.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }
    }
}
