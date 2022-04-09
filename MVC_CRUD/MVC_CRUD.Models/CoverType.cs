using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
    }
}
