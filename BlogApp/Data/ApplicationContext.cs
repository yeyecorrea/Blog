using Blog.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<PostCategory> PostCategories => Set<PostCategory>();
        public DbSet<PostStatus> PostStatuses => Set<PostStatus>();
        public DbSet<PostTag> PostTags => Set<PostTag>();
        public DbSet<Tag> Tags => Set<Tag>();
    }
}
