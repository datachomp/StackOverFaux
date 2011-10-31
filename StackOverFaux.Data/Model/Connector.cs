using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace StackOverFaux.Data.Model
{

	//Time to wire!
    public class SoFConnStr : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTypes> PostTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<VoteType> VoteTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        
    }
}
