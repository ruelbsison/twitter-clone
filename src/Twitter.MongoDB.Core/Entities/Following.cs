using System;
namespace Twitter.MongoDB.Core.Entities
{
    public class Following : BaseEntity
    {
        public string? UserId { get; set; }
        public string? FollowingUserId { get; set; }

        private DateTime? followed { get; set; }
        public DateTime Followed
        {
            get
            {
                return followed.HasValue
                   ? followed.Value
                   : DateTime.Now;
            }

            set { this.followed = value; }
        }
    }
}
