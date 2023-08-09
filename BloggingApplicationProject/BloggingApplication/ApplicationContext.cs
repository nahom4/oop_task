using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BloggingApplication
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(){} 
        public ApplicationContext(DbContextOptions options) : base(options){}
        public virtual DbSet<Post> Post { set; get;}
        public virtual DbSet<Comment> Comment { set; get;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=nahom;Database=bloggingapplicationdb;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Comment>().HasOne(p => p.Post).WithMany(c => c.ListOfComments)
            .HasForeignKey(p => p.PostId).HasConstraintName("FK_Post_Comment_PostId");
        }
    }
}