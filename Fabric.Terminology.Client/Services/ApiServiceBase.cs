namespace Fabric.Terminology.Client.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Newtonsoft.Json;

    internal abstract class ApiServiceBase
    {
        protected async Task<Maybe<TResult>> GetApiResult<TResult>(string url)
        {
            using (var client = new HttpClient())
            {
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