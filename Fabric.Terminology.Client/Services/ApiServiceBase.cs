namespace Fabric.Terminology.Client.Services
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Configuration;
    using Newtonsoft.Json;

    internal abstract class ApiServiceBase
    {
        private readonly string route;

        protected ApiServiceBase(ITerminologyApiSettings settings, string route)
        {
            this.ApiSettings = settings;
            this.route = route;
        }

        protected ITerminologyApiSettings ApiSettings { get; }

        protected string BaseUrl => $"{this.ApiSettings.TerminologyApiUri}/{this.ApiSettings.ApiVersion}/{this.route}";

        protected async Task<Maybe<TResult>> GetApiResult<TResult>(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await client.GetAsync(url))
                {
                    using (var content = response.Content)
                    {
                        var json = await content.ReadAsStringAsync();
                        return json != null
                            ? Maybe.From(JsonConvert.DeserializeObject<TResult>(json))
                            : Maybe<TResult>.Not;
                    }
                }
            }
        }

        protected async Task<Maybe<TResult>> PostApiResult<TResult>(string url, string jsonBody)
        {
            throw new NotImplementedException();
        }
    }
}