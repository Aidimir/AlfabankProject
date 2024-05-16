
using AlfabankProjectApi.App.DTO.LocationsDTO.Response;
using AlfabankProjectApi.App.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Web;

namespace AlfabankProjectApi.Services;

public enum GisApiLocationsHeaders
{
    point, radius, type, q, key
}
public enum GisApiProductHeaders
{
    key, locale, featureConfig, branchId
}

public static class GisApiExtensions
{
    public static string GetStringValue(this GisApiLocationsHeaders header)
    {
        switch (header)
        {
            case GisApiLocationsHeaders.q: return "q";
            case GisApiLocationsHeaders.type: return "type";
            case GisApiLocationsHeaders.key: return "key";
            case GisApiLocationsHeaders.point: return "point";
            case GisApiLocationsHeaders.radius: return "radius";
            default: return string.Empty;
        }
    }    
    public static string GetStringValue(this GisApiProductHeaders header)
    {
        switch (header)
        {
            case GisApiProductHeaders.key: return "key";
            case GisApiProductHeaders.locale: return "locale";
            case GisApiProductHeaders.featureConfig: return "feature_config";
            case GisApiProductHeaders.branchId: return "branch_id";
            default: return string.Empty;
        }
    }
}
public class ApiService : ILocationsService, IRestaurantsService
{
    private string key;

    private string locationsRequestUrl = "https://catalog.api.2gis.ru/3.0/items";
    private string searchTags = "Поесть";
    private List<string> searchFields = new List<string> { "items.rubrics", "items.ads.options", "items.reviews", "items.external_content" };
    private string productsRequestUrl = "https://market-backend.api.2gis.ru/5.0/product/items_by_branch";
    private string featureConfig = "categories_without_fake_first_level,range_price_type_supported,from_price_type_supported";
    private string locale = "ru_RU";

    public ApiService(IConfiguration config)
    {
        key = config["2Gis:ApiKey"];
    }

    public async Task<NearestRestaurantsResonse> GetNearestRestaurantsAsync(string point, int radius)
    {
        var uriBuilder = new UriBuilder(locationsRequestUrl);
        var queryParams = HttpUtility.ParseQueryString(uriBuilder.Query);

        queryParams[GisApiLocationsHeaders.point.GetStringValue()] = point;
        queryParams[GisApiLocationsHeaders.radius.GetStringValue()] = radius.ToString();
        queryParams[GisApiLocationsHeaders.type.GetStringValue()] = "branch";
        queryParams[GisApiLocationsHeaders.q.GetStringValue()] = searchTags;
        queryParams[GisApiLocationsHeaders.key.GetStringValue()] = key;
        queryParams["fields"] = string.Join(",", searchFields);
        queryParams[GisApiProductHeaders.locale.GetStringValue()] = locale;

        uriBuilder.Query = queryParams.ToString();

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(uriBuilder.ToString());

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                ApiRestaurantsResponse restaurants = JsonConvert.DeserializeObject<ApiRestaurantsResponse>(responseBody);
                return new NearestRestaurantsResonse { Restaurants = restaurants.Result.Items, Success = true };
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
    public async Task<object> GetMenuAsync(string orgId)
    {
        var uriBuilder = new UriBuilder(productsRequestUrl);
        var queryParams = HttpUtility.ParseQueryString(uriBuilder.Query);
        queryParams[GisApiProductHeaders.locale.GetStringValue()] = locale;
        queryParams[GisApiProductHeaders.featureConfig.GetStringValue()] = featureConfig;
        queryParams[GisApiProductHeaders.key.GetStringValue()] = key;
        queryParams[GisApiProductHeaders.branchId.GetStringValue()] = orgId;
        uriBuilder.Query = queryParams.ToString();

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(uriBuilder.ToString());

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}
