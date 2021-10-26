using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppVk
{
    class Program
    {
        static async Task GetUserInfo(string token, string userId)
        {
            var uri = $"https://api.vk.com/method/users.get?user_ids={userId}&access_token={token}&v=5.131";// &fields=can_write_private_message";
            var client = new HttpClient();
            var stringTask = client.GetStringAsync(uri);
           // var streamTask = client.GetStreamAsync(uri);
           // var item = await JsonSerializer.DeserializeAsync<User>(await streamTask);
           // dynamic item = JsonConvert.DeserializeObject<List<User>>(await stringTask);
            Console.WriteLine(await stringTask);
        }

        static void GetAccessToken(string clientId)
        {
            var redirectUri = "https://oauth.vk.com/blank.html";
            var requestMessage = $"https://oauth.vk.com/authorize?client_id={clientId}&display=page&redirect_uri={redirectUri}&scope=friends&response_type=token&v=5.131&state=123456";
            requestMessage = requestMessage.Replace("&", "^&");
            Process.Start(new ProcessStartInfo("cmd", $"/c start {requestMessage}") { CreateNoWindow = true });
        }

        static async Task DeleteFriend(string token)
        {
            Console.WriteLine("Please enter userId to delete");
            var userId = Console.ReadLine();
            var uri = $"https://api.vk.com/method/friends.delete?user_id={userId}&access_token={token}&v=5.131";
            var client = new HttpClient();
            var result = await client.GetStringAsync(uri);
        }
        
        static async Task AddFriend(string token)
        {
            Console.WriteLine("Please enter userId to add");
            var userId = Console.ReadLine();
            var uri = $"https://api.vk.com/method/friends.add?user_id={userId}&text=Hey_there&access_token={token}&v=5.131";
            var client = new HttpClient();
            var result = await client.GetStringAsync(uri);
        }
        
        static async Task GetFriensOnline(string token)
        {
            var uri = $"https://api.vk.com/method/friends.getOnline?access_token={token}&v=5.131";
            var client = new HttpClient();
            var result = await client.GetStringAsync(uri);
        }

        private static async Task Main(string[] args)
        {
            var token = "44fcc8d244fcc8d244fcc8d2e944851f70444fc44fcc8d2258b3199825618b6202a56f8";
            /*Console.WriteLine("Please enter userId");
            var userId = Console.ReadLine();*/
            var userId = "ilovetacoss";
            /*Console.WriteLine("Please enter your app id");
            var clientId = Console.ReadLine();*/
            var clientId = "7985058";
            await GetUserInfo(token, userId);
            //GetAccessToken(clientId);
        }
    }
}
