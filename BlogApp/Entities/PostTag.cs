using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Entities
{
    public class PostTag
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int PostId { get; set; }
        public Post Post { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
