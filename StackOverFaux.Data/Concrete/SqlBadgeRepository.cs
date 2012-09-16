using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackOverFaux.Data.Abstract;
using StackOverFaux.Data.Model;

namespace StackOverFaux.Data.Concrete
{
	public class SqlBadgeRepository : IBadgeRepository
	{
		SoFConnStr Data = new SoFConnStr();

		public IQueryable<Badge> GetAllBadges()
		{
			var badges = from b in Data.Badges
						 join c in Data.Users on b.UserId equals c.UserId
						 select b;

			return badges;
		}

		public IEnumerable<Badge> GetBadgesByUserId(int userid)
		{
			var badges = from b in Data.Badges
						 join c in Data.Users on b.UserId equals c.UserId
						 where b.UserId == userid
						 select b;
			return badges;
		}
	}
}
