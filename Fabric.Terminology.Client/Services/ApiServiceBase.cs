﻿namespace Fabric.Terminology.Client.Services
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
    using Fabric.Terminology.Client.Models;
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

                using (var response = await client.GetAsync(url))
                {
                    using (var content = response.Content)
                    {
                        var json = await content.ReadAsStringAsync();
                        return json != null
                            ? Maybe.From(json)
                            : Maybe<string>.Not;
                    }
                }
            }
        }

        private async Task<Maybe<string>> PostApiResult<TModel>(string url, TModel model)
            where TModel : class
        {
            var requestContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                using (var response = await client.PostAsync(url, requestContent))
                {
                    using (var content = response.Content)
                    {
                        var json = await content.ReadAsStringAsync();
                        return json != null
                            ? Maybe.From(json)
                            : Maybe<string>.Not;
                    }
                }

            }
        }
    }
}