using Twitter.MongoDB.Infra.Configurations;

namespace Twitter.GraphQL.API.Configurations
{
    public class ApiConfiguration
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MongoDbConfiguration MongoDbConfiguration { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
