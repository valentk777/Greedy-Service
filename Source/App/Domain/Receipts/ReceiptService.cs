namespace Greedy.Domain.Receipts
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptManager _receiptManager;

        public ReceiptService(IReceiptManager receiptManager)
        {
            _receiptManager = receiptManager;
        }
    }
}