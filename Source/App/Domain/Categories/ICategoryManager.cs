namespace Greedy.Domain.Categories
{
    public interface ICategoryManager
    {
        List<Category> GetAll();

        Category Add(Category category);
    }
}