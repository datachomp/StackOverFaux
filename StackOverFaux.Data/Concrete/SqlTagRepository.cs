using System;
using System.Collections.Generic;
using System.Linq;
using StackOverFaux.Data.Abstract;
using StackOverFaux.Data.Model;
using Dapper;
using System.Configuration;

namespace StackOverFaux.Data.Concrete
{
	public class SqlTagRepository : ITagRepository
	{
		SoFConnStr Data = new SoFConnStr();

		public IEnumerable<Tag> GetTagList()
		{
			var tags = from t in Data.Tags
					   orderby t.TagName
					   select t;

			return tags;
		}


		//public IQueryable<Post> GetPostsByTag(string tagname)
		public TagCount GetTagCount(string tagname)
		{
			TagCount counter;
			int count;
			count = Data.Posts.Count(p => p.Tags.Contains(tagname));

			counter = new TagCount { TagName = tagname, CountTag = count };	

			return counter;
		}

		//This is the Dapper Version
		public TagCount GetdynPostsByTag(string tagname)
		{
			string connection = ConfigurationManager.ConnectionStrings["SoFConnStr"].ToString();
			int counter;

			using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(connection))
			{
				sqlConnection.Open();
				counter = sqlConnection.Query<int>("SELECT Count(0) as PostCount FROM dbo.Posts WHERE FREETEXT(tags, @tagname)", new { tagname = tagname }).Single();
			}
				TagCount taggy = new TagCount { TagName = tagname, CountTag = counter };
			return taggy;
		} 

	}
}

