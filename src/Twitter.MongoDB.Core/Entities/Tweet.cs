using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Twitter.MongoDB.Core.Entities
{
    public class Tweet : BaseEntity
    {
        public int TweetId { get; set; }
        [DisplayName("User Name")]
        public string? UserName { get; set; }
        public string? Message { get; set; }
        public string? ImageURL { get; set; }
        [DisplayName("Posted on")]
        public DateTime Created { get; set; }
        public int TotalReplies { get; set; }
        public int TotalRetweets { get; set; }
        public int TotalLikes { get; set; }
        public int TotalShares { get; set; }
        // public User? User { get; set; }
    }
}
