using AlfabankProjectApi.DataLayer.Entities;
using System.Text.Json.Serialization;

namespace AlfabankProjectApi.App.DTO.LocationsDTO.Response;
public class NearestRestaurantsResonse
{
    public List<Restaurant> Restaurants { get; set; }
    [JsonIgnore]
    public bool Success { get; set; }
}