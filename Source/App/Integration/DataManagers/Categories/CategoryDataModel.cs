using System.ComponentModel.DataAnnotations;

namespace Greedy.Integration.DataManagers.Categories
{
    public class CategoryDataModel
    {
        [Key]
        public string Keyword { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
