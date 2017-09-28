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
    using Newtonsoft.Json.Linq;

    internal class ApiTransactionManager : IApiTransactionManager
    {
        private readonly ITerminologyApiSettings apiSettings;

        private readonly ILogger logger;

        public ApiTransactionManager(ITerminologyApiSettings settings, ILogger logger)
        {
            this.apiSettings = settings;
            this.logger = logger;
        }

        public string GetBaseUrl(string endPoint) => $"{this.apiSettings.TerminologyApiUri}/{this.apiSettings.ApiVersion}/{endPoint}";

        public async Task<Maybe<TResult>> GetApiResult<TResult>(string url)
        {
            return (await this.GetApiJson(url)).Select(t => t.ToObject<TResult>());
        }

        public async Task<Maybe<TResult>> PostApiResult<TResult, TModel>(string url, TModel model)
            where TModel : class
        {
            return (await this.PostApiResult(url, model))
                        .Select(t => t.ToObject<TResult>());
        }

        public async Task<IReadOnlyCollection<TResult>> GetApiResultList<TResult>(string url)
        {
            return (await this.GetApiJson(url))
                .Select(t => t.ToObject<IReadOnlyCollection<TResult>>())
                .Else(new List<TResult>());
        }

        public async Task<PagedCollection<TResult>> GetApiResultPage<TResult>(string url)
        {
            return (await this.GetApiJson(url))
                    .Select(t => t.ToObject<PagedCollection<TResult>>())
                    .Else(PagedCollection<TResult>.Empty);
        }

        public async Task<PagedCollection<TResult>> PostApiResultPage<TResult, TModel>(string url, TModel model)
            where TModel : class
        {
            return (await this.PostApiResult(url, model))
                    .Select(t => t.ToObject<PagedCollection<TResult>>())
                    .Else(PagedCollection<TResult>.Empty);
        }

        private async Task<Maybe<JToken>> GetApiJson(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    using (var response = await client.GetAsync(url))
                    {
                        var token = await this.GetHttpContent(HttpMethod.Get, url, response);
                        return token;
                    }
                }
                catch (Exception ex)
                {
                    this.logger.Error<ApiTransactionManager>("Failed HttpGet - Fabric.Terminology.API", ex);
                    throw;
                }
            }
        }

        private async Task<Maybe<JToken>> PostApiResult<TModel>(string url, TModel model)
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
                    this.logger.Error<ApiTransactionManager>("Failed HttpPost - Fabric.Terminology.API", ex);
                    throw;
                }
            }
        }

        private async Task<Maybe<JToken>> GetHttpContent(HttpMethod method, string url, HttpResponseMessage response)
        {
            using (var content = response.Content)
            {
                var json = await content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var jo = JObject.Parse(json);
                    return Maybe.If(jo["result"] != null, jo["result"])
                            .Else(jo);
                }

                var error = ErrorFactory.CreateError<ApiTransactionManager>(json, response.StatusCode);
                this.logger.Error<ApiTransactionManager>(
                    "{@Method} {@Url} returned status {@StatusCode}",
                    error,
                    method,
                    url,
                    response.StatusCode.ToString());
                return Maybe<JToken>.Not;
            }
        }
    }
}