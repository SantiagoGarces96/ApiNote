using Core.Entities;
using Infraestructure.Data;
using Infraestructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Infraestructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AplicationDbContext _db;

        public CategoryRepository(AplicationDbContext db):base(db) 
        {
            _db = db;
        }

        public void UpdateCategory(Category category)
        {
            var categorydb = _db.Categories.FirstOrDefault(l => l.Id == category.Id);

            if (categorydb != null)
            {
                categorydb.Name = category.Name;
                categorydb.Description = category.Description;
               _db.SaveChanges();
            }
        }
    }
}
