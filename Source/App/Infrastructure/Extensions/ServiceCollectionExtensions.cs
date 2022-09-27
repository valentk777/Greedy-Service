using Greedy.Domain.Extensions;
using Greedy.Integration.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Shared.Serializers;

namespace Greedy.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGreedyApp(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDataManagers();
            serviceCollection.AddAuthentication();
            serviceCollection.AddFacebookLogin();
            serviceCollection.AddSingleton<ICustomJsonConverter, CustomJsonConverter>();
            serviceCollection.AddDomain();

            return serviceCollection;
        }
    }
}