// News API
// Шагиахметова Зиля 220

using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            var ApiKey = "04c0d59649d6485891b181368147ffa4";
            var q = "Apple";
            var from = "2021-06-07";
            var sortBy = "popularity";
            var url = $"https://newsapi.org/v2/everything?q={q}&from={from}&sortBy={sortBy}&apiKey={ApiKey}";

            var request = WebRequest.Create(url);

            var response = request.GetResponse();
            var httpStatusCode = (response as HttpWebResponse).StatusCode;

            if (httpStatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(httpStatusCode);
                return;
            }

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                //Console.WriteLine(result);
                var news = JsonConvert.DeserializeObject<Root>(result);
                foreach (Article art in news.articles)
                    Console.WriteLine(art.title);
            }

        }
    }

    public class Source
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Article
    {
        public Source source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public DateTime publishedAt { get; set; }
        public string content { get; set; }
    }

    public class Root
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }
    }
}