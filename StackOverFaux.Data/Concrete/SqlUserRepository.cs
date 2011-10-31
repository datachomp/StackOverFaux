using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackOverFaux.Data.Abstract;
using StackOverFaux.Data.Model;

namespace StackOverFaux.Data.Concrete
{
	public class SqlUserRepository : IUserRepository
	{
		SoFConnStr Data = new SoFConnStr();

		public User GetUser(string displayname)
		{
			var user = Data.Users.First(u => u.DisplayName == displayname);//varchar
			return user;
		}

		public IEnumerable<Post> GetUserQuestions(int userid)
		{
			var questions = Data.Posts.Where(p => p.OwnerUserId == userid && p.PostTypeId == 1);
			return questions;
		}
		public IEnumerable<Post> GetUserAnswers(int userid)
		{
			var answers = Data.Posts.Where(p => p.OwnerUserId == userid && p.PostTypeId == 2);
			return answers;
		}

		public IQueryable<Post> GetUserPosts(int userid)
		{
			var posts = Data.Posts.Where(p => p.OwnerUserId == userid);
			return posts;
		}


		public IEnumerable<Badge> GetUserBadgeCount(int userid)
		{
			var badge = Data.Badges.Where(b => b.UserId == userid);
			return badge;
		}



	}
}
