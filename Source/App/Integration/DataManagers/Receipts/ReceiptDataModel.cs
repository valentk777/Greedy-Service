using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Greedy.Integration.DataManagers.Users;
using Greedy.Integration.DataManagers.Shops;
using Greedy.Integration.DataManagers.Items;

namespace Greedy.Integration.DataManagers.Receipts
{
    public class ReceiptDataModel
    {
        [Key]
        public int ReceiptId { get; set; }

        public decimal Total { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? ReceiptDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime UpdateDate { get; set; }

        [Required]
        public virtual UserDataModel User { get; set; }

        public virtual ShopDataModel Shop { get; set; }

        [Required]
        public virtual ICollection<ItemDataModel> Items { get; set; }
    }
}
