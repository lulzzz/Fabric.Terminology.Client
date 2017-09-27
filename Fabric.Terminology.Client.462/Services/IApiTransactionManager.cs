namespace Fabric.Terminology.Client.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CallMeMaybe;
    using Fabric.Terminology.Client.Models;

    public interface IApiTransactionManager
    {
        string GetBaseUrl(string endPoint);

        Task<Maybe<TResult>> GetApiResult<TResult>(string url);

        Task<IReadOnlyCollection<TResult>> GetApiResultList<TResult>(string url);

        Task<PagedCollection<TResult>> GetApiResultPage<TResult>(string url);

        Task<Maybe<TResult>> PostApiResult<TResult, TModel>(string url, TModel model)
            where TModel : class;

        Task<PagedCollection<TResult>> PostApiResultPage<TResult, TModel>(string url, TModel model)
            where TModel : class;
    }
}