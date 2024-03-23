namespace MVC.Mediator
{
    public interface IMediatorService
    {
        Task<TResponse> SendAsync<TResponse>(HttpRequestMessage request);
    }
}
