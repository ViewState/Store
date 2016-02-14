using System;
using System.Linq;
using Store.Data.Infrastructure;
using Store.Model;

namespace Store.Data.Repositories
{
    public class CatergoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CatergoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Category GetCategoryByName(String categoryName)
        {
            var category = DbContext.Categories.Where(c => c.Name == categoryName).FirstOrDefault();
            return category;
        }

        public override void Update(Category entity)
        {
            entity.DateUpdated = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryByName(String categoryName);
    }
}
