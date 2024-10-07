using Blog.Domain.Entities;

namespace BlogApp.Models
{
    public class HomeIndexModel
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}
