using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El comentario  es demasiado largo")]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [Required]
        [StringLength(100,ErrorMessage = "El comentario  es demasiado largo")]
        [Display(Name = "Comentario")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; } = DateTime.Now;


        [Display(Name = "Publicacion")]
        public int PostId { get; set; }
        public Post Post { get; set; }

        
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
