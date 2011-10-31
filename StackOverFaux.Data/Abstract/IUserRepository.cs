using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackOverFaux.Data.Model;

namespace StackOverFaux.Data.Abstract
{
    public interface IUserRepository
    {
        User GetUser(string displayname);
        IEnumerable<Post> GetUserQuestions(int userid);
        IEnumerable<Post> GetUserAnswers(int userid);
        IQueryable<Post> GetUserPosts(int userid);


        IEnumerable<Badge> GetUserBadgeCount(int userid);
    }
}
