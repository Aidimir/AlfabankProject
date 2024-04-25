using AlfabankProjectApi.App.DTO.LocationsDTO.Response;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AlfabankProjectApi.Services;
public interface ILocationsService
{
    public Task<object> GetNearestRestaurantsAsync(string point, int radius);
}