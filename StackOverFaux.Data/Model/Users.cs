using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace StackOverFaux.Data.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public int Reputation { get; set; }
        public string EmailHash { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastAccessDate { get; set; }
        public String WebsiteUrl { get; set; }
        public int ProfileViews { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }

        public string Location { get; set; }
        public int Age { get; set; }
        public string AboutMe { get; set; }
        
    }
}
