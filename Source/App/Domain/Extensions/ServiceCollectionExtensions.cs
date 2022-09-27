using Greedy.Domain.Categories;
using Greedy.Domain.Graphs;
using Microsoft.Extensions.DependencyInjection;

namespace Greedy.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICategoryService, CategoryService>();
            serviceCollection.AddSingleton<IGraphService, GraphService>();
            //serviceCollection.AddSingleton<ICategoryService, CategoryService>();
            //serviceCollection.AddSingleton<ICategoryService, CategoryService>();
            //serviceCollection.AddSingleton<ICategoryService, CategoryService>();
            //serviceCollection.AddSingleton<ICategoryService, CategoryService>();

            return serviceCollection;
        }
    }
}