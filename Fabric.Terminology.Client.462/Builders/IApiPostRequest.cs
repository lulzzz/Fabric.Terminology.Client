namespace Fabric.Terminology.Client.Builders
{
    public interface IApiPostRequest<out TModel, out TResult> : IApiRequest<TResult>
    {
        TModel BuildModel();
    }
}
