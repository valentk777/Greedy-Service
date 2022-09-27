using System.Data.Entity;
using Greedy.Domain.Receipts;

namespace Greedy.Integration.DataManagers.Receipts
{
    public class ReceiptManager : ManagerBase, IReceiptManager
    {
        public ReceiptManager(DbContext context) : base(context) { }

        //TODO: do not return model object
        public ReceiptDataModel GetReceipt(int receiptId) =>
            context
                .Set<ReceiptDataModel>()
                .Include(x => x.Shop)
                .First(x => x.ReceiptId == receiptId);
    }
}
