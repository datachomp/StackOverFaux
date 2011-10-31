using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StackOverFaux.Data.Model
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }


        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
