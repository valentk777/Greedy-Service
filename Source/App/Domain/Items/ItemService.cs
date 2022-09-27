namespace Greedy.Domain.Items
{
    public class ItemService : IItemService
    {
        private readonly IItemManager _itemManager;

        public ItemService(IItemManager itemManager)
        {
            _itemManager = itemManager;
        }
    }
}