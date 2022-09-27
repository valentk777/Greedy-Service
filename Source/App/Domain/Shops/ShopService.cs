namespace Greedy.Domain.Shops
{
    public class ShopService : IShopService
    {
        private readonly IShopManager _shopManager;

        public ShopService(IShopManager shopManager)
        {
            _shopManager = shopManager;
        }
    }
}