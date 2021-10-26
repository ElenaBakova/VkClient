using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await httpClient.GetStringAsync(uri);
        }

        private static async Task Main(string[] args)
        {
            string token = "44fcc8d244fcc8d244fcc8d2e944851f70444fc44fcc8d2258b3199825618b6202a56f8";
            string userId = "560243831";
            var json = await UserInfo(token, userId);
            
            Console.WriteLine(json);
        }
    }
}
