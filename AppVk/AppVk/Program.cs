using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppVk
{
    class Program
    {        
        static async Task<string> UserInfo(string token, string userId)
        {
            
            string uri = $"https://api.vk.com/method/users.get?user_ids={userId}&access_token={token}&v=5.131&fields=can_write_private_message";
            var httpClient = new HttpClient();
            return await httpClient.GetStringAsync(uri);
        }

        static async Task Authorize(string userId)
        {
            string requestMessage = $"https://oauth.vk.com/authorize?client_id={userId}&display=page&redirect_uri=http://localhost/&scope=friends&response_type=token&v=5.131";
            requestMessage = requestMessage.Replace("&", "^&");
            Process.Start(new ProcessStartInfo(
            "cmd",
            $"/c start {requestMessage}")
            { CreateNoWindow = true });
        }

        private static async Task Main(string[] args)
        {
            var token = "44fcc8d244fcc8d244fcc8d2e944851f70444fc44fcc8d2258b3199825618b6202a56f8";
            Console.WriteLine("Please enter userId");
            var userId = Console.ReadLine();
            //string userId = "560243831";
            var json = await UserInfo(token, userId);            
            Console.WriteLine(json);
            await Authorize(userId);
        }
    }
}
