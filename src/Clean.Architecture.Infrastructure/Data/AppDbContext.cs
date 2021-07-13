using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.EFCore.Extensions;
using Clean.Architecture.Core.Model;
using Clean.Architecture.Core.ProjectAggregate;
using Clean.Architecture.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        //public AppDbContext(DbContextOptions options) : base(options)
        //{
        //}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category_Post>()
                .HasOne(b => b.Category)
                .WithMany(b => b.Category_Posts)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Category_Post>()
                .HasOne(b => b.Post)
                .WithMany(b => b.Category_Posts)
                .HasForeignKey(b => b.PostId);


            // alternately this is built-in to EF Core 2.2
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Category_Post> Category_Posts { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        // public DbSet<ToDoItem> ToDoItems { get; set; }
        // public DbSet<Project> Projects { get; set; }

    }

}