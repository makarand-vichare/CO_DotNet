using CrossOver.EntityModels.Identity;
using CrossOver.EntityModels.SearchBook;
using CrossOver.EntityModels.UserDemand;
using CrossOver.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace CrossOver.Tests.Common
{
    public static class Helper
    {
        public static void LoadMockData<T>() where T: class
        {
            var jsonData = GetJsonData(AppMethods.CorrectCollectionName(typeof(T).Name) + ".js");
            var mockDataList = new List<T>();
            if(!String.IsNullOrEmpty(jsonData))
            {
                jsonData = jsonData.Replace("_id", "id");
                mockDataList = JsonConvert.DeserializeObject<List<T>>(jsonData);
            }

            if (typeof(T).Name == typeof(UserEntityModel).Name)
            {
                MockDB.Collections.Users = mockDataList.Cast<UserEntityModel>().ToList();
            }
            else if (typeof(T).Name == typeof(UserDemandEntityModel).Name)
            {
                MockDB.Collections.UserDemands = mockDataList.Cast<UserDemandEntityModel>().ToList();
            }
            else if (typeof(T).Name == typeof(BookEntityModel).Name)
            {
                MockDB.Collections.Books = mockDataList.Cast<BookEntityModel>().ToList();
            }
        }

        private static string GetJsonData(string dataFileName)
        {
            var defaultDataFolderPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data");
            var configDataFolderPath = ConfigurationManager.AppSettings["DataFolderPath"];

            var dataFilePath = Directory.Exists(defaultDataFolderPath)
                ? Path.Combine(defaultDataFolderPath, dataFileName)
                : Path.Combine(configDataFolderPath, dataFileName);

            return File.ReadAllText(dataFilePath);
        }

        public static T DeepClone<T>(this T source)
        {
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            // return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
            return source;
        }
    }
}
