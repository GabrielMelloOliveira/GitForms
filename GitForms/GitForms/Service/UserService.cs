using GitForms.Util;
using GitHubLibrary.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GitForms.Service
{
    public class UserService
    {
        private string BaseAddress = "https://api.github.com";

        public async Task<User> GetUser(string username)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            string text = await client.GetStringAsync(BaseAddress + "/users/" + username);

            JsonConvert<User> convert = new JsonConvert<User>();

            return convert.ToObject(text);
        }

        public async Task<List<User>> GetFollowers(string username)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            string text = await client.GetStringAsync(BaseAddress + "/users/" + username + "/followers");

            JsonConvert<List<User>> convert = new JsonConvert<List<User>>();

            return convert.ToObject(text);
        }

        public async Task<List<User>> GetFollowing(string username)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            string text = await client.GetStringAsync(BaseAddress + "/users/" + username + "/following");

            JsonConvert<List<User>> convert = new JsonConvert<List<User>>();

            return convert.ToObject(text);
        }
    }
}
