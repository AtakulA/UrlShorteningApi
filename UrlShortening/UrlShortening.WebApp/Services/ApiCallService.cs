namespace UrlShortening.WebApp.Services
{
    public class ApiCallService
    {
        private readonly HttpClient client;
        private readonly string baseApiUrl = "https://localhost:7081/";

        public ApiCallService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseApiUrl);
        }


        public async Task<string> CreateShortUrl(string originalUrl)
        {
            var response = await client.PostAsJsonAsync("api/Urls",originalUrl);

            string result = await response.Content.ReadAsStringAsync();

            return result;
        }


        public async Task<string> GetOriginalUrl(string shortUrl)
        {
            var response = await client.GetAsync("api/Urls/" + shortUrl);

            string result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
