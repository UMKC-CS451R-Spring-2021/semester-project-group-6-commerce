using Commerce_Bank.Screen.Models;
using Commerce_Bank.Screen.ScreenServices.ScreenInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Commerce_Bank.Screen.ScreenServices
{
    public class ScreenAccountService : IScreenAccountService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient client;
        public ScreenAccountService(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;
            client = _httpClientFactory.CreateClient("meta");
        }

        public async Task<IEnumerable<TrasactionDisplayModel>> GetUserBankTransactions(int PersonId)
        {
            var response=await client.GetAsync($"Account/GetUserBankTransactions?personId={PersonId}");
            if(response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data=await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(data))
                {
                    //deserialize the Json formatted data (stringified format)
                    //in this case we want to change the string to an object
                    var options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;//this ignores the case difference between properties
                    return JsonSerializer.Deserialize<List<TrasactionDisplayModel>>(data, options);

                }
            }
            return null;
        }

        public async Task<LoginUserResponse> LoginUser(LoginModel model)
        {
            
            var response = await client.PostAsJsonAsync<LoginModel>($"Account/Login", model);
            if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(data))
                    {
                        var options = new JsonSerializerOptions();
                        options.PropertyNameCaseInsensitive = true;
                        return JsonSerializer.Deserialize<LoginUserResponse>(data, options);
                    }
            }
            return null;
        }
    }
}
