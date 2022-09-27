using System.Data.Entity;
using Greedy.Integration.DataManagers.Receipts;
using Greedy.Domain.Shops;

namespace Greedy.Integration.DataManagers.Shops
{
    public class ShopManager : ManagerBase, IShopManager
    {
        public ShopManager(DbContext context) : base(context) { }

        public List<Shop> GetExistingShops()
        {
            using (context)
            {
                return context.Set<ShopDataModel>()
                    .Where(x => x.Address != null)
                    .Select(x => new Shop()
                    {
                        Name = x.Name,
                        Location = x.Location,
                        Address = x.Address,
                        SubName = x.SubName
                    })
                    .ToList();
            }
        }

        public List<ShopData> GetAllUserShops(string username)
        {
            using (context)
            {
                var AllUserReceipts = context
                    .Set<ReceiptDataModel>()
                    .Where(x => x.User.Username == username && x.Shop.Address != null)
                    .GroupBy(x => x.Shop)
                    .ToList();

                return AllUserReceipts
                    .Select(x => new ShopData
                    {
                        Name = x.Key.Name,
                        Location = x.Key.Location,
                        Address = x.Key.Address,
                        Total = x.Select(y => y.Total).Sum(),
                        ReceiptNumber = x.Key.Receipts.Count(),
                        Date = x.Select(y => y.ReceiptDate).Last().HasValue
                            ? x.Select(y => y.ReceiptDate).Last().Value.ToString("d")
                            : x.Select(y => y.UpdateDate).Last().ToString("d")
                    }).ToList();
            }
        }
    }
}