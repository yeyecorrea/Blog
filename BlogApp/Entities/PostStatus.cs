using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Entities
{
    public class PostStatus
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatio")]
        [MaxLength(50, ErrorMessage = "El campo {0} es demsiado largo")]
        [Display(Name = "Nombre del estado")]
        public string StatusName { get; set; }
    }
}
