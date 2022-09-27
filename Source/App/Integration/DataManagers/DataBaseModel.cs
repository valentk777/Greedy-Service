using Greedy.Integration.DataManagers.Categories;
using Greedy.Integration.DataManagers.Items;
using Greedy.Integration.DataManagers.Receipts;
using Greedy.Integration.DataManagers.Shops;
using Greedy.Integration.DataManagers.Users;
using System.Data.Entity;
namespace Greedy.Integration.DataManagers
{
    public class DataBaseModel : DbContext
    {
        public DataBaseModel() : base()
        {
        }

        public virtual DbSet<UserDataModel> User { get; set; }
        public virtual DbSet<ReceiptDataModel> Receipt { get; set; }
        public virtual DbSet<ShopDataModel> Shop { get; set; }
        public virtual DbSet<ItemDataModel> Item { get; set; }
        public virtual DbSet<CategoryDataModel> Category { get; set; }
    }
}
