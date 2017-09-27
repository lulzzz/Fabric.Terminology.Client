namespace Fabric.Terminology.Client.Builders
{
    using System.Threading.Tasks;

    public interface IApiRequest<out TResult> : IApiRequest
    {
        TResult Execute();
    }

    public interface IApiRequest
    {
        string GetEndpoint();
    }
}