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
    public class ReposService
    {
        private string BaseAddress = "https://api.github.com";

        public async Task<List<Repos>> GetRepos(string username)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            string text = await client.GetStringAsync(BaseAddress + "/users/" + username + "/repos");

            JsonConvert<List<Repos>> convert = new JsonConvert<List<Repos>>();

            return convert.ToObject(text);
        }
    }
}
