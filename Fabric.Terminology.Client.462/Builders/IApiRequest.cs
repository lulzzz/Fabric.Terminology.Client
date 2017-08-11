namespace Fabric.Terminology.Client.Builders
{
    using System.Threading.Tasks;

    public interface IApiRequest<out TResult>
    {
        TResult Execute();
    }
}