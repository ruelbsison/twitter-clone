using Twitter.MongoDB.Core.Entities;
using HotChocolate.Types;

namespace Twitter.GraphQL.API.Types
{
    public class FollowingType : ObjectType<Following>
    {
        protected override void Configure(IObjectTypeDescriptor<Following> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.UserId);
            descriptor.Field(_ => _.FollowingUserId);
            descriptor.Field(_ => _.Followed);
        }
    }
}
