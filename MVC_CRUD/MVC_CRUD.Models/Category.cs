using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [DisplayName("Display Order")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
