using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzjobApi.Models
{
    [Table("Subcategory")]
    public class Subcategory
    {
        public Subcategory()
        {
            Name = string.Empty;
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
