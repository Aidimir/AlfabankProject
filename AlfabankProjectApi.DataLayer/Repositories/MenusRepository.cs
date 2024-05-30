using AlfabankProjectApi.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlfabankProjectApi.DataLayer.Repositories;

public class RestaurantContext : DbContext
{
    private DbSet<MenuItem> _menuItems;
    private DbSet<Restaurant> _restaurants;

    public async Task<Restaurant> AddRestaurantToDbAsync(Restaurant restaurant)
    {
        var sameContactsInDb = await _restaurants.FirstOrDefaultAsync(g => g.Id == restaurant.Id);

        if (sameContactsInDb != null)
        {
            throw new Exception("Ресторан уже существует в базе данных");
        }

        await _restaurants.AddAsync(restaurant);
        await SaveChangesAsync();

        return await FetchRestaurantById(restaurant.Id);
    }

    private async Task<Restaurant> FetchRestaurantById(Guid id)
    {
        var result = await _restaurants.FirstOrDefaultAsync(x => x.Id == id);

        if (result == null)
        {
            throw new Exception("Ресторана с таким id не существует");
        }

        return result;
    }

    public async Task AddMenusToDbAsync(List<MenuItem> menus)
    {
        var existingMenus = await _menuItems
            .Where(m => menus.Select(menu => menu.Id).Contains(m.Id))
            .ToListAsync();

        var newMenus = menus
            .Where(menu => !existingMenus.Select(m => m.Id).Contains(menu.Id))
            .ToList();

        await _menuItems.AddRangeAsync(newMenus);
        await SaveChangesAsync();
    }

    private async Task<List<MenuItem>> FetchMenuItemByIds(List<Guid> ids)
    {
        var result = await _menuItems.Where(i => ids.Contains(i.Id)).ToListAsync();

        if (result == null)
        {
            throw new Exception("Таких позиций в меню не существует");
        }

        return result;
    }
}
