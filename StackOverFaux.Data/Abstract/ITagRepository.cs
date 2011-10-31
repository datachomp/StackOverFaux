using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackOverFaux.Data.Model;

namespace StackOverFaux.Data.Abstract
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetTagList();
        //IQueryable<Post> GetPostsByTag(string tagid);
		TagCount GetTagCount(string tagname);
		TagCount GetdynPostsByTag(string tagname);
    }
}
