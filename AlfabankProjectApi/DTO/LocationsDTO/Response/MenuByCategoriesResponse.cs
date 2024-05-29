﻿namespace AlfabankProjectApi.App.DTO.LocationsDTO.Response;
public class MenuByCategoriesResponse
{
    public string Category { get; set; }
    public List<ApiMenuProductWithOffer> Items { get; set; }
}

public class ApiMenuResponse
{
    public ApiMenuResult Result { get; set; }
}

public class ApiMenuResult
{
    public List<ApiMenuProductWithOffer> Items { get; set; }
}

public class ApiMenuProductWithOffer
{
    public ApiMenuProduct Product { get; set; }
    public ApiMenuProductOffer Offer { get; set; }
}

public class ApiMenuProduct
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Uri> Images { get; set; }
    public List<ApiMenuProductCategory> Categories { get; set; }
}
public class ApiMenuProductCategory
{
    public string Id { get; set; }
    public string Name { get; set; }
}
public class ApiMenuProductOffer
{
    public double Price { get; set; }
    public string Currency { get; set; }
}
