namespace Fabric.Terminology.Client.Builders
{
    public interface IApiPostRequest<out TModel>
    {
        TModel BuildModel();
    }
}
