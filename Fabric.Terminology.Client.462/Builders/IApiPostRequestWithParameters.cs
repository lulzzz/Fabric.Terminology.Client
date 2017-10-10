namespace Fabric.Terminology.Client.Builders
{
    public interface IApiPostRequestWithParameters<out TModel, TResult> : IApiRequestWithParameters<TResult>
    {
        TModel BuildModel();
    }
}