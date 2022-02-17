using Twitter.MongoDB.Core.Entities;
using HotChocolate.Types;

namespace Twitter.GraphQL.API.Types
{
    public class TweetType : ObjectType<Tweet>
    {
        protected override void Configure(IObjectTypeDescriptor<Tweet> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.TweetId);
            descriptor.Field(_ => _.UserName);
            descriptor.Field(_ => _.Message);
            descriptor.Field(_ => _.ImageURL);
            descriptor.Field(_ => _.Created);
            descriptor.Field(_ => _.TotalReplies);
            descriptor.Field(_ => _.TotalRetweets);
            descriptor.Field(_ => _.TotalLikes);
            descriptor.Field(_ => _.TotalShares);
        }
    }
}
