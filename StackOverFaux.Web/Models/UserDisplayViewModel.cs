using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackOverFaux.Data.Model;

namespace StackOverFaux.Web.Models
{
    public class UserDisplayViewModel
    {
        public User User;
        public IEnumerable<Post> Questions;
        public IEnumerable<Post> Answers;
		public IEnumerable<Badge> Badges;
    }
}