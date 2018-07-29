using System;
using System.Configuration;

namespace CrossOver.Tests.Common
{
    public static class Globals
    {

        private static string _mongodbConnectionString;
        public static string MongodbConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(_mongodbConnectionString))
                {
                    _mongodbConnectionString = ConfigurationManager.ConnectionStrings["MongodbConnectionString"].ConnectionString;
                }

                return _mongodbConnectionString;
            }
        }
    }
}
