namespace Greedy.Domain.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryService(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public List<string> GetAllDistinctCategories() =>
            _categoryManager.GetAll().Distinct().ToList();

        public string AddNew(Category category) =>
            _categoryManager.Add(category);
    }
}