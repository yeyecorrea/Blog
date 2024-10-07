using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50)]
        [Display(Name = "Nombre Categoria")]
        public string CategoryName { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} es demasiado largo")]
        [Display(Name = "Descripcion")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        public ICollection<PostCategory> PostCategories { get; set; }
    }
}
