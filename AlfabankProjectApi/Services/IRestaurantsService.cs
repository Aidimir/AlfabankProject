namespace AlfabankProjectApi.App.Services;
public interface IRestaurantsService
{
    public Task<object> GetMenuAsync(string orgId);
}
