using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace ConsoleApp
{
    class Program 
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://jsonplaceholder.typicode.com/posts");
                var newPost = new Post()
                {
                    Title = "Test Requisition POST",
                    Body = "Hello World",
                    UserId = 11
                };
                var newPostJson = JsonConvert.SerializeObject(newPost); 
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;
            }
        }
    }
}