namespace Fabric.Terminology.Client.Builders
{
    public interface IApiRequest<out TResult> : IApiRequest
    {
        TResult Execute();
    }

    public interface IApiRequest
    {
        string GetEndpoint();
    }
}