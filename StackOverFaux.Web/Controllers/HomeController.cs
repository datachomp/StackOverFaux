using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Profiling;
using StackOverFaux.Controllers;
using StackOverFaux.Data.Abstract;
using StackOverFaux.Data.Model;
using StackOverFaux.Web.Models;

namespace StackOverFaux.Web.Controllers
{
	public class HomeController : BaseController
	{

		//IOC 
		private IBadgeRepository ibadgeRepository;
		private IPostRepository ipostRepository;
		private ITagRepository itagRepository;
		private IUserRepository iuserRepository;

		public HomeController(IBadgeRepository ibadgeRepository, IPostRepository ipostRepository
				, ITagRepository itagRepository, IUserRepository iuserRepository)
		{
			this.ibadgeRepository = ibadgeRepository;
			this.ipostRepository = ipostRepository;
			this.itagRepository = itagRepository;
			this.iuserRepository = iuserRepository;
		}

		public ActionResult Index()
		{
			var profiler = GetProfiler();

			//we load both tabs on startup so that the second tab is instant when user clicks
			//This works great when you don't have huge record sets.
			using (profiler.Step("Recent Posts Call"))
			{
				ViewBag.RecentPosts = ipostRepository.GetRecentPosts();
			}

			using (profiler.Step("Hottest Posts Call"))
			{
				ViewBag.HotPosts = ipostRepository.GetHotPosts();
			}

			return View();
		}

		public ActionResult Badges()
		{

			var profiler = GetProfiler();

			IQueryable<Badge> badges;
			IEnumerable<BadgeViewModel> counts;

			using (profiler.Step("Grab Badges"))
			  {
				   //var badges = ibadgeRepository.GetBadgesByUserId(23354);
				   badges = ibadgeRepository.GetAllBadges();

			   }

			using (profiler.Step("Count them up - yum"))
			   {
					counts = from b in badges
							 group b by b.Name into c
							 select new BadgeViewModel { BadgeName = c.Key, BadgeCount = c.Count() };


				}

				ViewBag.Badges = counts;
				
			return View();
		}


		public ActionResult DisplayUser()
		{

			//This section hardcoded to save time for demo.
			var user = iuserRepository.GetUser("Gator");
			var questions = iuserRepository.GetUserQuestions(91254);
			var answers = iuserRepository.GetUserAnswers(91254);
			var badges = iuserRepository.GetUserBadgeCount(91254);

			var viewModel = new UserDisplayViewModel
			{
				User = user,
				Questions = questions,
				Answers = answers,
				Badges = badges
			};

			return View(viewModel);
		}



		public ActionResult Tags()
		{
			IEnumerable<Tag> taglist;

			var profiler = GetProfiler();
			using (profiler.Step("get tag dropdown"))
			{
				taglist = itagRepository.GetTagList();
			}

			using (profiler.Step("get Tag Count"))
			{ }
				var viewModel = new TagSearchViewModel
				{
					TagList = taglist,
					TagCount = null
				};
		  return View(viewModel);
		}

		[HttpPost]
		public ActionResult Tags(FormCollection formy)
		{
			var tagname = formy["TagSelect"];

			IEnumerable<Tag> taglist;
			TagCount taggy;
			

			var profiler = GetProfiler();
			using (profiler.Step("get tag dropdown"))
			{
				taglist = itagRepository.GetTagList();
			}

			using (profiler.Step("get Tag Count"))
			{
				taggy = itagRepository.GetTagCount(tagname);

				//uncomment for the Dapper version
				//taggy = itagRepository.GetdynPostsByTag(tagname);
			}
			

				var viewModel = new TagSearchViewModel
				{
					TagList = taglist,
					TagCount = taggy
				};

				return View(viewModel);
			
		}

	}
}

