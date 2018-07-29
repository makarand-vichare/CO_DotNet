using System.Collections.Generic;
using CrossOver.EntityModels.Identity;
using CrossOver.EntityModels.SearchBook;
using CrossOver.EntityModels.UserDemand;

namespace CrossOver.Tests.Common
{
    public static class MockDB
    {
        public static MockDataCollection Collections = new MockDataCollection();

        public static void LoadAllDataFiles()
        {
            Helper.LoadMockData<UserDemandEntityModel>();
            Helper.LoadMockData<BookEntityModel>();
            Helper.LoadMockData<UserEntityModel>();
        }
    }

    public class MockDataCollection
    {
        public List<UserDemandEntityModel> UserDemands = new List<UserDemandEntityModel>();
        public List<BookEntityModel> Books = new List<BookEntityModel>();
        public List<UserEntityModel> Users = new List<UserEntityModel>();
    }
}
