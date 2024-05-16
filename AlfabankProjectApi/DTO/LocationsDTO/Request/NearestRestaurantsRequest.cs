using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace AlfabankProjectApi.App.DTO.LocationsDTO.Request;
public class NearestRestaurantsRequest
{
    public NearestRestaurantsRequest() { }

    [Required]
    [MinLength(1, ErrorMessage = "Координаты не могут быть пустой строкой")]
    public string Point { get; set; }
    [Required]
    public int Radius { get; set; }
}
