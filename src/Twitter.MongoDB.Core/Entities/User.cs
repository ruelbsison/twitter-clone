using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Twitter.MongoDB.Core.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Followings = new HashSet<Following>();
            Tweets = new HashSet<Tweet>();
        }
        public DateTime Joined
        {
            get
            {
                return joined.HasValue
                   ? joined.Value
                   : DateTime.Now;
            }

            set { this.joined = value; }
        }

        [DisplayName("User Name")]
        public string? UserName { get; set; }
        public string? Password { get; set; }
        [DisplayName("Full Name")]
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? AvatarURL { get; set; }

        private DateTime? joined { get; set; }
        [DefaultValue(1)]
        public int Active { get; set; }

        public ICollection<Following> Followings { get; set; }
        public ICollection<Tweet> Tweets { get; set; }
    }
}
