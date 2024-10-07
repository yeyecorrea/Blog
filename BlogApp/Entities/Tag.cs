using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Entities
{
    public class Tag
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} debe ser obligatorio")]
        [MaxLength(25, ErrorMessage = "El campo {0} es demasiado largo")]
        [Display(Name = "Nombre de la etiqueta")]
        public string TagName { get; set; }

        public ICollection<PostTag> PostTags { get; set; }
    }
}
