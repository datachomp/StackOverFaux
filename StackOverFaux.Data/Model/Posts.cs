using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace StackOverFaux.Data.Model
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public int? AcceptedAnswerId {get;set;}
        public DateTime CreationDate {get;set;}
        public int Score {get;set;}
        public string Body { get; set; }
        public int OwnerUserId { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public int ViewCount { get; set; }
        public int? AnswerCount { get; set; }
        public int? CommentCount { get; set; }
        public int? FavoriteCount { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int? ParentId { get; set; }
        public DateTime? CommunityOwnedDate { get; set; }

        public int PostTypeId { get; set; }
    }

    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }
    }

	public class TagCount
	{
		public string TagName;
		public int CountTag;
	}


    public class PostTypes
    {
        [Key]
        public int PostTypeId { get; set; }
        public string PostType { get; set; }
    }


    public class PostTags
    {
        public Post PostId { get; set; }
        public Tag TagId { get; set; }
    }


    public class FrontPage
    {

        public int PostId {get;set;}
        public int? AnswerCount{get;set;}
        public int ViewCount{get;set;}
        public string Title{get;set;}
        public string Tags{get;set;}
        public int UserId {get;set;}
        public string DisplayName{get;set;}
        public int Reputation { get; set; }
    }


}
