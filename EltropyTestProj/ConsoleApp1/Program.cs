using ApiHelper;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiMethods apiMethods = new ApiMethods();
            List<Tweet> X = apiMethods.GetTop10TweetsOf100("cnnbrk", 100).Result;
            //var contributors = JsonConvert.DeserializeObject<<IEnumerable<string>>(twitts);
            //contributors.ForEach(Console.WriteLine);

            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Text", typeof(string));
            table.Columns.Add("Retweet", typeof(int));
            table.Columns.Add("Fav", typeof(int));
            table.Columns.Add("CreateAt", typeof(DateTime));

            foreach (Tweet t in X)
            {
                table.Rows.Add(t.id, t.text, t.retweet_count, t.favourites_count, t.created_at);
            }


            List<string> Y = apiMethods.GetFriends("cnnbrk", 100).Result;

            // sort the list
            Y = apiMethods.InsertionSortNew(Y).Result;




            Console.ReadKey();
        }
    }
}
