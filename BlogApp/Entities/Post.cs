using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100)]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Contenido")]
        public string Content { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50)]
        [Display(Name = "Slug")]
        public string Slug { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateCreated { get; set; } = DateTime.MinValue;

        [DataType(DataType.DateTime)]
        public DateTime? DateUpdated { get; set; }

        // Colección de Comentarios (Navegación)
        public ICollection<Comment> Comments { get; set; }

        //// Realaciones 
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Estado")]
        public int PostStatusId { get; set; }
        public PostStatus PostStatus { get; set; }

    }
}
