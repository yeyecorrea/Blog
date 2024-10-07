using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Entities
{
    public class PostCategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int PostId { get; set; }
        public Post Post { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
