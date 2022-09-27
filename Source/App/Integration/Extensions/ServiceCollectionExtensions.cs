using Greedy.Integration.DataManagers;
using Greedy.Integration.DataManagers.Categories;
using Greedy.Integration.DataManagers.Graphs;
using Greedy.Integration.DataManagers.Items;
using Greedy.Integration.DataManagers.Receipts;
using Greedy.Integration.DataManagers.Shops;
using Greedy.Integration.DataManagers.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Entity;
using Greedy.Domain.Items;
using Greedy.Integration.Authentication;
using Greedy.Domain.Users;
using Greedy.Domain.Graphs;
using Greedy.Domain.Receipts;
using Greedy.Domain.Categories;
using Greedy.Domain.Shops;
using Greedy.Integration.FacebookLogin;

namespace Greedy.Integration.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataManagers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICategoryManager, CategoryManager>();
            serviceCollection.AddSingleton<IGraphManager, GraphManager>();
            serviceCollection.AddSingleton<IItemManager, ItemManager>();
            serviceCollection.AddSingleton<IReceiptManager, ReceiptManager>();
            serviceCollection.AddSingleton<IShopManager, ShopManager>();
            serviceCollection.AddSingleton<IUserManager, UserManager>();
            serviceCollection.AddSingleton<DbContext, DataBaseModel>();

            return serviceCollection;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAuthenticationService, AuthenticationService>();

            return serviceCollection;
        }

        public static IServiceCollection AddFacebookLogin(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IFacebookLoginService, FacebookLoginService>();

            return serviceCollection;
        }
    }
}