using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Stuart.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Ensures auto-increment for the CategoryId
        public int CategoryId { get; set; }  // Primary key for Category

        [Required]  // CategoryName is required
        public string CategoryName { get; set; }  // Name of the category
    }
}
