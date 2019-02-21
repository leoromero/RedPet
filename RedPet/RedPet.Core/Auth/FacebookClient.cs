using Microsoft.Extensions.Options;
using RedPet.Common.Auth.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RedPet.Core.Auth
{
    public interface IFacebookClient
    {
        Task<string> GenerateAppAccessTokenAsync();
        Task<string> ValidateUserAccessTokenAsync(string token, string appAccessToken);
        Task<string> GetUserInfoAsync(string token);
    }

    public class FacebookClient : IFacebookClient
    {
        private readonly HttpClient _client;
        private readonly FacebookAuthSettings fbSettings;

        public FacebookClient(HttpClient httpClient, IOptions<FacebookAuthSettings> fbSettings)
        {
            httpClient.BaseAddress = new Uri("https://graph.facebook.com/");
            //httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            //httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            _client = httpClient;

            this.fbSettings = fbSettings.Value;
        }

        public async Task<string> GenerateAppAccessTokenAsync()
        {
            return await _client.GetStringAsync($"oauth/access_token?client_id={fbSettings.AppId}&client_secret={fbSettings.AppSecret}&grant_type=client_credentials");
        }

        public async Task<string> GetData()
        {
            return await _client.GetStringAsync("/");
        }

        public async Task<string> GetUserInfoAsync(string token)
        {
            return await _client.GetStringAsync($"v2.8/me?fields=id,email,first_name,last_name,name,gender,locale,birthday,picture&access_token={token}");
        }

        public async Task<string> ValidateUserAccessTokenAsync(string token, string appAccessToken)
        {
            return await _client.GetStringAsync($"debug_token?input_token={token}&access_token={appAccessToken}");
        }
    }
}
