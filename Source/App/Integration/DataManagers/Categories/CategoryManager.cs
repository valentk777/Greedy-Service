using System.Data.Entity;
using Greedy.Domain.Categories;

namespace Greedy.Integration.DataManagers.Categories
{
    public class CategoryManager : ManagerBase, ICategoryManager
    {
        public CategoryManager(DbContext context) : base(context) { }

        string Add(Category category)
        {
            context.Set<CategoryDataModel>().Add(new CategoryDataModel
            {
                Name = newItem.Name,
                Category = newItem.Category,
                Price = newItem.Price,
                Receipt = receipt
            });

            context.SaveChanges();

            return category;
        }

        public List<string> GetAll() =>
            context
                .Set<CategoryDataModel>()
                .Select(x => x.Category)
                .ToList();
    }
}