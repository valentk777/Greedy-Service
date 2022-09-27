using System.Data.Entity;
using Greedy.Integration.DataManagers.Users;
using Greedy.Integration.DataManagers.Shops;
using Greedy.Integration.DataManagers.Receipts;
using Greedy.Domain.Items;
using Greedy.Domain.Receipts;

namespace Greedy.Integration.DataManagers.Items
{
    public class ItemManager : ManagerBase, IItemManager
    {
        public ItemManager(DbContext context) : base(context) { }





        public int AddItems(Receipt receipt, string username)
        {
            UserDataModel userDataModel = context
                .Set<UserDataModel>()
                .FirstOrDefault(x => x.Username.ToLower() == username.ToLower());

            if (userDataModel == null)
            {
                //TODO: MOVE somewhere 
                //TODO: create custom expections
                //throw new Exception(Properties.Resources.UserNotFound);
                throw new Exception("UserNotFound");
            }

            ShopDataModel shopDataModel;

            if (receipt.Shop == null)
            {
                shopDataModel = null;
            }
            else
            {
                var shops = context
                    .Set<ShopDataModel>()
                    .Select(x => x)
                    .Where(x => x.Name == receipt.Shop.Name);

                if (receipt.Shop.Address == null)
                {
                    shopDataModel = shops
                        .Where(x => x.Address == null)
                        .FirstOrDefault();
                }
                else
                {
                    shopDataModel = shops
                        .Select(x => x)
                        .Where(x => x.Address == receipt.Shop.Address)
                        .FirstOrDefault();
                }
            }

            ReceiptDataModel receiptDataModel = new ReceiptDataModel()
            {
                ReceiptDate = receipt.ReceiptDate,
                UpdateDate = receipt.UpdateDate,
                Shop = shopDataModel,
                User = userDataModel,
                Total = 0
            };

            receiptDataModel.Items = new List<ItemDataModel>();
            foreach (Item item in receipt.ItemsList)
            {
                receiptDataModel.Items.Add(new ItemDataModel()
                {
                    Receipt = receiptDataModel,
                    Price = item.Price,
                    Name = item.Name,
                    Category = item.Category
                });

                receiptDataModel.Total += item.Price;
            }
            context
                .Set<ReceiptDataModel>()
                .Add(receiptDataModel);
            context.SaveChanges();
            return receiptDataModel.ReceiptId;
        }

        public List<Item> GetItemsOfSingleReceipt(int receiptId)
        {
            var temp = context
                .Set<ReceiptDataModel>()
                .Include(x => x.Items)
                .FirstOrDefault(x => x.ReceiptId == receiptId);

            return temp.Items.Select(ToItem).ToList();
        }

        public List<Item> GetAllUserItems(string username) =>
            context
                .Set<ItemDataModel>()
                .Where(x => x.Receipt.User.Username.ToLower() == username.ToLower())
                .Select(ToItem)
                .ToList();

        //TODO: for now this only saves the changed item to ItemDataModels table
        //nothing is written for categorizations.
        //Once categoraziation is sorted out need to add extra logic
        public void UpdateItem(Item updatedItem)
        {
            var itemToUpdate = context.Set<ItemDataModel>()
                .FirstOrDefault(x => x.ItemId == updatedItem.ItemId);
            //TODO: I believe this can be written in more SOLID style
            //Using explicit/implicit type conversion operators
            //Didn't have the time to research this
            itemToUpdate.Name = updatedItem.Name;
            itemToUpdate.Category = updatedItem.Category;
            itemToUpdate.Receipt.Total += updatedItem.Price - itemToUpdate.Price;
            itemToUpdate.Price = updatedItem.Price;
            context.SaveChanges();
        }

        public void AddItem(Item newItem, int receiptId)
        {
            var receipt = context.Set<ReceiptDataModel>().First(x => x.ReceiptId == receiptId);
            receipt.Total += newItem.Price;
            context.Set<ItemDataModel>().Add(new ItemDataModel
            {
                Name = newItem.Name,
                Category = newItem.Category,
                Price = newItem.Price,
                Receipt = receipt
            });

            context.SaveChanges();
        }

        public Item GetItem(int itemId)
        {
            var item = context
                .Set<ItemDataModel>()
                .First(x => x.ItemId == itemId);

            return ToItem(item);
        }

        public void DeleteItem(int itemId)
        {
            var itemToDelete = context
                .Set<ItemDataModel>()
                .First(x => x.ItemId == itemId);

            itemToDelete.Receipt.Total -= itemToDelete.Price;
            context.Set<ItemDataModel>().Remove(itemToDelete);
            context.SaveChanges();
        }

        private Item ToItem(ItemDataModel item) =>
            new Item
            {
                Category = item.Category,
                Name = item.Name,
                Price = item.Price,
                ItemId = item.ItemId
            };
    }
}
