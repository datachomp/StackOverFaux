using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StackOverFaux.Data.Model
{
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }
        public int BountyAmount { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Post Post { get; set; }
        public virtual VoteType VoteType { get; set; }
        public virtual User User {get;set;}

    }


    public class VoteType
    {
        [Key]
        public int VoteTypeId { get; set; }
        public string Name { get; set; }
    }
}
