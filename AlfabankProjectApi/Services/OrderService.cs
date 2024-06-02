using AlfabankProjectApi.DataLayer.Entities;
using System.Diagnostics.Contracts;

namespace AlfabankProjectApi.App.Services;

public class OrderService
{
    public int ProcessCart(List<MenuItem> menus)
    {
        return GenerateRandomOrderNum();
    }
    public int GenerateRandomOrderNum() 
    {
        int _min = 100;
        int _max = 999;
        Random _rdm = new Random();
        return _rdm.Next(_min, _max);
    }
}
