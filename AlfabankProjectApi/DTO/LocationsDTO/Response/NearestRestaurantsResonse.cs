using AlfabankProjectApi.DataLayer.Entities;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using System.ComponentModel;

namespace AlfabankProjectApi.App.DTO.LocationsDTO.Response;
public class NearestRestaurantsResonse
{
    public List<RestaurantResponse> Restaurants { get; set; }
    [JsonIgnore]
    public bool Success { get; set; }
}

public class ExternalContent
{
    [JsonProperty("main_photo_url")]
    [DisplayName("mainPhotoUrl")]
    public string MainPhotoUrl { get; set; }
}

public class Reviews
{
    [JsonProperty("general_rating")]
    [DisplayName("generalRating")]
    public double GeneralRating { get; set; }
    [DisplayName("generalCount")]
    [JsonProperty("general_review_count_with_stars")]
    public int GeneralCount { get; set; }
}
public class Rubrics
{
    [JsonProperty("name")]
    [DisplayName("name")]
    public string Name { get; set; }
}


public class RestaurantResponse
{
    [JsonProperty("address_name")]
    [DisplayName("address")]
    public string Address { get; set; }  
    [JsonProperty("id")]
    [DisplayName("id")]
    public string Id { get; set; }
    [JsonProperty("name")]
    [DisplayName("title")]
    public string Title { get; set; }
    [JsonProperty("external_content")]
    public List<ExternalContent> ExternalContent { get; set; }

    [JsonProperty("reviews")]
    public Reviews Reviews { get; set; }
    [JsonProperty("rubrics")]
    public IEnumerable<Rubrics> Rubrics { get; set; }
}

public class ApiRestaurantsResponse
{
    public ApiRestaurantsResult Result { get; set; }
}
public class ApiRestaurantsResult
{
    public List<RestaurantResponse> Items { get; set; }
}
