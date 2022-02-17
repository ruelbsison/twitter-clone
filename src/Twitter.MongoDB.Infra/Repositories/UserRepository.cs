using Twitter.MongoDB.Core.Entities;
using Twitter.MongoDB.Core.Repositories;
using Twitter.MongoDB.Infra.Data;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Collections;
using MongoDB.Bson;

namespace Twitter.MongoDB.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ITwitterContext twitterContext) : base(twitterContext)
        {
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            var filter = Builders<User>.Filter.Eq("UserName", userName);

            return await collection.Find(filter).FirstAsync();
        }

        //public Task<User> GetByUserNameAsync(string userName)
        //{
        //    List<User> returnList = new List<User>();
        //    var query? = Builders<BsonDocument>.Filter.Empty;
        //    var criteriaFilter = Builders<BsonDocument>.Filter.Empty;

        //    if (string.IsNullOrEmpty(userName) == false)
        //    {
        //        criteriaFilter = Builders<BsonDocument>.Filter.Eq("UserName", userName);
        //        query = query & criteriaFilter;

        //        var result = collection.Find(query)
        //            .FirstAsync();
        //    }



        //    var results = collection.Aggregate()
        //        .Match(user => user.UserName == userName)
        //        .ToListAsync();

        //    var results = collection.Aggregate()
        //                               .Match(query)
        //                               .Group(new BsonDocument
        //                               { { "_id", "$cuisine" },
        //                               { "count", new BsonDocument("$sum", 1) } })
        //                               .ToListAsync();

        //    //Parsing results (block 3):
        //    foreach (BsonDocument item in results)
        //    {
        //        returnList.Add(new DTO.Aggregatedtem()
        //        {
        //            Label = item.Elements.ElementAtOrDefault(0).Value.AsString,
        //            Value = item.Elements.ElementAtOrDefault(1).Value.AsInt32
        //        });
        //    }

        //    //collection.Aggregate()
        //    //                .Lookup("items", "items.itemId", "_id", @as: "items")
        //    //                .Unwind("items", new AggregateUnwindOptions<ItemDetail>() { PreserveNullAndEmptyArrays = true })
        //    //                .Lookup("vendors", "items.vendorId", "_id", @as: "items.vendor")
        //    //                .Unwind("items.vendor", new AggregateUnwindOptions<VendorDetail>() { PreserveNullAndEmptyArrays = true })
        //    //                .Group(group)
        //    //                .ReplaceRoot<object>("{$mergeObjects:['$root', '$$ROOT']}")
        //    //                .Project("{root:0}")
        //    //                .As<OrderDetail>().ToEnumerable();
        //    var users = collection.Aggregate<User>().
        //        Lookup<User, Tweet>(
        //            collection,
        //            a => a.UserName,
        //            b => b.UserName,
        //            a => a.myBs);
    }
}
