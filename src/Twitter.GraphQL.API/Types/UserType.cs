using Twitter.MongoDB.Core.Entities;
using Twitter.GraphQL.API.Resolvers;
using HotChocolate.Types;

namespace Twitter.GraphQL.API.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.UserName);
            descriptor.Field(_ => _.Password);
            descriptor.Field(_ => _.Fullname);
            descriptor.Field(_ => _.Email);
            descriptor.Field(_ => _.AvatarURL);
            descriptor.Field(_ => _.Joined);
            descriptor.Field(_ => _.Active);

            descriptor.Field<FollowingResolver>(_ => _.GetFollowingsAsync(default, default));
            descriptor.Field<TweetResolver>(_ => _.GetTweetsAsync(default, default));
        }
    }
}
