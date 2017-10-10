namespace Fabric.Terminology.Client.Builders
{
    public interface IApiPostRequest<out TModel, TResult> : IApiRequest<TResult>
    {
        TModel BuildModel();
    }
}
