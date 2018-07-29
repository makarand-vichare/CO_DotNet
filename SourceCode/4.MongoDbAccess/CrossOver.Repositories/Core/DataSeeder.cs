using MongoDB.Driver;
using System.Configuration;

namespace CrossOver.Repositories.Core
{
    public class DataSeeder
    {
        public static IMongoDatabase GetDataBase()
        {
            var client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDbConnection"].ConnectionString);
            var database = client.GetDatabase(ConfigurationManager.AppSettings["MongoDbName"]);
           return database;
        }
    }
}
