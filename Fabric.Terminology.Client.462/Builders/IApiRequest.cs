namespace Fabric.Terminology.Client.Builders
{
    using System.Threading.Tasks;

    public interface IApiRequest<TResult> : IApiRequest
    {
        Task<TResult> Execute();
    }

    public interface IApiRequest
    {
        string GetEndpoint();
    }
}