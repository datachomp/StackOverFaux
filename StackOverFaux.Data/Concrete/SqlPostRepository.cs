using System;
using System.Linq;
using StackOverFaux.Data.Abstract;
using StackOverFaux.Data.Model;

namespace StackOverFaux.Data.Concrete
{
	public class SqlPostRepository : IPostRepository
	{
		SoFConnStr Data = new SoFConnStr();

		public IQueryable<FrontPage> GetRecentPosts()
		{
			

			var recentposts = from p in Data.Posts
							  join u in Data.Users on p.OwnerUserId equals u.UserId

							  //yep, making assumptions here with the post types. saving joins though!
							  //join pt in posts.PostTypes on p.PostType.PostTypeId equals pt.PostTypeId
							  where p.PostTypeId == 1
							  orderby p.CreationDate descending
							  select new FrontPage
							  {
								  PostId = p.PostId,
								  AnswerCount = p.AnswerCount,
								  ViewCount = p.ViewCount,
								  Title = p.Title,
								  Tags = p.Tags,
								  UserId = u.UserId,
								  DisplayName = u.DisplayName,
								  Reputation = u.Reputation
							  };
			
			return recentposts.Take(20).AsQueryable();
		}


		public IQueryable<FrontPage> GetHotPosts()
		{
			//The dataset isn't recent, so we get to fake some dates!
			DateTime WhenItAllBegins = new DateTime(2011, 3, 20, 0, 0, 0);
			var recentposts = from p in Data.Posts
							  join u in Data.Users on p.OwnerUserId equals u.UserId
							  //where p.PostTypeId == 1 && p.CreationDate >= DateTime.Parse("03/20/2011").Date
							  where p.PostTypeId == 1 && p.CreationDate >= WhenItAllBegins
							  //where p.PostTypeId ==1 && p.CreationDate >= DateTime.Today.AddDays(-7);
							  orderby p.ViewCount descending
							  //select p;
							  select new FrontPage {
							   PostId = p.PostId, AnswerCount = p.AnswerCount, ViewCount= p.ViewCount, Title= p.Title , Tags= p.Tags
								,UserId= u.UserId, DisplayName= u.DisplayName, Reputation= u.Reputation};
			
			
			return recentposts.Take(20).AsQueryable(); ;
		}
	}
}
