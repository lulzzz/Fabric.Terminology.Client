using System.Threading.Tasks;

namespace Fabric.Terminology.Client.Builders
{
    public interface IApiRequest<TResult> : IApiRequest
    {
        Task<TResult> Execute();
    }

    public interface IApiRequest
    {
        string GetEndpoint();
    }
}