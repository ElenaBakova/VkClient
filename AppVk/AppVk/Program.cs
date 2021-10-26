using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppVk
{
    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }

    class Program
    {
        static async Task<string> UserInfo(string token, string userId)
        {
            string uri = $"https://api.vk.com/method/users.get?user_ids={userId}&access_token={token}&v=5.131";
            var httpClient = new HttpClient();
            return await httpClient.GetStringAsync(uri);
        }

        static async Task Authorize(string userId)
        {
            string requestMessage = $"https://oauth.vk.com/authorize?client_id={userId}&display=page&redirect_uri=http://localhost/&scope=friends&response_type=token&v=5.131";
            System.Diagnostics.Process.Start(requestMessage);
            ////string uri = $"https://api.vk.com/method/users.get?user_ids={userId}&access_token={token}&v=5.131";
            //var httpClient = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Get, requestMessage);
            //await httpClient.SendAsync(request);
        }

        private static async Task Main(string[] args)
        {
            string token = "44fcc8d244fcc8d244fcc8d2e944851f70444fc44fcc8d2258b3199825618b6202a56f8";
            string userId = "ilovetacoss";
            var json = await UserInfo(token, userId);
            var account = JsonConvert.DeserializeObject<Account>(json);
            await Authorize(userId);
            
            Console.WriteLine(json);
        }
    }
}
