using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StackOverFaux.Data.Model;

namespace StackOverFaux.Data.Abstract
{
    public interface IBadgeRepository
    {
        //IEnumerable<Badge> GetAllBadges();
        IQueryable<Badge> GetAllBadges();
        IEnumerable<Badge> GetBadgesByUserId(int userid);
    }
}
