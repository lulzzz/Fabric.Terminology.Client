namespace Fabric.Terminology.Client.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Configuration;
    using Fabric.Terminology.Client.Logging;
    using Fabric.Terminology.Client.Models;
    using Newtonsoft.Json;

    internal abstract class ApiServiceBase
    {
        private readonly string route;

        protected ApiServiceBase(ITerminologyApiSettings settings, ILogger logger, string route)
        {
            this.ApiSettings = settings;
            this.Logger = logger;
            this.route = route;
        }

        protected ITerminologyApiSettings ApiSettings { get; }

        protected ILogger Logger { get; }

        protected string BaseUrl => $"{this.ApiSettings.TerminologyApiUri}/{this.ApiSettings.ApiVersion}/{this.route}";

        protected async Task<Maybe<TResult>> GetApiResult<TResult>(string url)
        {
            var json = await this.GetApiJson(url);

            return json.HasValue
                ? Maybe.From(JsonConvert.DeserializeObject<TResult>(json.Single()))
                : Maybe<TResult>.Not;
        }

        protected async Task<Maybe<TResult>> PostApiResult<TResult, TModel>(string url, TModel model)
            where TModel : class
        {
            var json = await this.PostApiResult(url, model);
            return json.HasValue
                ? Maybe.From(JsonConvert.DeserializeObject<TResult>(json.Single()))
                : Maybe<TResult>.Not;
        }

        protected async Task<IReadOnlyCollection<TResult>> GetApiResultList<TResult>(string url)
        {
            var json = await this.GetApiJson(url);

            var result = json.HasValue
                ? JsonConvert.DeserializeObject<IEnumerable<TResult>>(json.Single())
                : Enumerable.Empty<TResult>();

            return result.ToArray();
        }

        protected async Task<PagedCollection<TResult>> GetApiResultPage<TResult>(string url)
        {
            var json = await this.GetApiJson(url);

            return json.HasValue
                ? JsonConvert.DeserializeObject<PagedCollection<TResult>>(json.Single())
                : PagedCollection<TResult>.Empty();
        }

        protected async Task<PagedCollection<TResult>> PostApiResultPage<TResult, TModel>(string url, TModel model)
            where TModel : class
        {
            var json = await this.PostApiResult(url, model);
            return json.HasValue
                ? JsonConvert.DeserializeObject<PagedCollection<TResult>>(json.Single())
                : PagedCollection<TResult>.Empty();
        }

        private async Task<Maybe<string>> GetApiJson(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    using (var response = await client.GetAsync(url))
                    {
                        return await this.GetHttpContent(HttpMethod.Get, url, response);
                    }
                }
                catch (Exception ex)
                {
                    this.Logger.Error<ApiServiceBase>("Failed HttpGet - Fabric.Terminology.API", ex);
                    throw;
                }
            }
        }

        private async Task<Maybe<string>> PostApiResult<TModel>(string url, TModel model)
            where TModel : class
        {
            var requestContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    using (var response = await client.PostAsync(url, requestContent))
                    {
                        return await this.GetHttpContent(HttpMethod.Post, url, response);
                    }
                }
                catch (Exception ex)
                {
                    this.Logger.Error<ApiServiceBase>("Failed HttpPost - Fabric.Terminology.API", ex);
                    throw;
                }
            }
        }

        private async Task<Maybe<string>> GetHttpContent(HttpMethod method, string url, HttpResponseMessage response)
        {
            using (var content = response.Content)
            {
                var json = await content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return Maybe.If(json != null, json);
                }

                var error = ErrorFactory.CreateError<ApiServiceBase>(json, response.StatusCode);
                this.Logger.Error<ApiServiceBase>(
                    "{@Method} {@Url} returned status {@StatusCode}",
                    error,
                    method,
                    url,
                    response.StatusCode.ToString());
                return Maybe<string>.Not;
            }
        }
    }
}