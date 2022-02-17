using Twitter.GraphQL.API.Configurations;
using Twitter.GraphQL.API.Mutations;
using Twitter.GraphQL.API.Queries;
//using GraphQL.API.Resolvers;
using Twitter.GraphQL.API.Subscriptions;
using Twitter.GraphQL.API.Types;
using Twitter.MongoDB.Core.Repositories;
using Twitter.MongoDB.Infra.Data;
using Twitter.MongoDB.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Twitter.GraphQL.API
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        private readonly ApiConfiguration apiConfiguration;

        public Startup(IConfigurationRoot configuration)
        {
            System.Console.WriteLine($"Startup");

            Configuration = configuration;
            this.apiConfiguration = configuration.Get<ApiConfiguration>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            System.Console.WriteLine($"Startup.ConfigureServices");

            // Configurations
            services.AddSingleton(this.apiConfiguration.MongoDbConfiguration);

            // Repositories
            services.AddSingleton<ITwitterContext, TwitterContext>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFollowingRepository, FollowingRepository>();
            services.AddScoped<ITweetRepository, TweetRepository>();

            // GraphQL
            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<TweetQuery>()
                    .AddTypeExtension<FollowingQuery>()
                    .AddTypeExtension<UserQuery>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<TweetMutation>()
                    .AddTypeExtension<FollowingMutation>()
                    .AddTypeExtension<UserMutation>()
                .AddSubscriptionType(d => d.Name("Subscription"))
                    .AddTypeExtension<TweetSubscriptions>()
                    .AddTypeExtension<FollowingSubscriptions>()
                    .AddTypeExtension<UserSubscriptions>()
                .AddType<TweetType>()
                .AddType<FollowingType>()
                .AddType<UserType>()
                .AddInMemorySubscriptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app) //, IWebHostEnvironment env)
        {
            System.Console.WriteLine($"Startup.Configure");

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseWebSockets();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/api/graphql");
            });
        }
    }
}
