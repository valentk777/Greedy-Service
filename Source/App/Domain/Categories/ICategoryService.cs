namespace Greedy.Domain.Categories
{
    public interface ICategoryService
    {
        List<string> GetAllDistinctCategories();
    }
}