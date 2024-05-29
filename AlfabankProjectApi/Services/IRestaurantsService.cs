using AlfabankProjectApi.App.DTO.LocationsDTO.Response;

namespace AlfabankProjectApi.App.Services;
public interface IRestaurantsService
{
    public Task<List<MenuByCategoriesResponse>> GetMenuAsync(string orgId);
}
