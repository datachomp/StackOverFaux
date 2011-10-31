using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackOverFaux.Data.Model;

namespace StackOverFaux.Web.Models
{
    public class TagSearchViewModel
    {
        public IEnumerable<Tag> TagList;
        public TagCount TagCount;
    }

}