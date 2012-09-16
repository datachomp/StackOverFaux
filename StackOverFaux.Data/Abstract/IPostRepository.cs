using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackOverFaux.Data.Model;

namespace StackOverFaux.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<FrontPage> GetRecentPosts();
        IQueryable<FrontPage> GetHotPosts();
        IQueryable<FrontPage> GetMostRecentPostsCache();
        IQueryable<FrontPage> GetHotPostsCache();
    }
}
