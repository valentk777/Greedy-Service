namespace Greedy.Domain.Shops
{
    public interface IShopManager
    {
        List<Shop> GetExistingShops();

        List<ShopData> GetAllUserShops(string username);
    }
}