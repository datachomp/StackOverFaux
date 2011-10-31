using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace StackOverFaux.Data.Model
{
    public class Badge
    {
        [Key]
        public int BadgeId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
    }

}


