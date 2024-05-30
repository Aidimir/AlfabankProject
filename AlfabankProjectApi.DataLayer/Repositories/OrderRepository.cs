using AlfabankProjectApi.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlfabankProjectApi.DataLayer.Repositories;
public class OrderContext : DbContext
{
    private DbSet<Order> _orders;
    public async Task<Order> AddOrderToDbAsync(Order order)
    {
        var orderInDb = await _orders.FirstOrDefaultAsync(g => g.Id == order.Id);
        if (orderInDb == null)
        {
            orderInDb.MenuItems = order.MenuItems;
            _orders.Update(orderInDb);
        }
        else
        {
            await _orders.AddAsync(order);
        }

        await SaveChangesAsync();

        return await FetchOrderById(order.Id);
    }

    private async Task<Order> FetchOrderById(Guid id)
    {
        var result = await _orders.FirstOrDefaultAsync(x => x.Id == id);

        if (result == null)
        {
            throw new Exception("Ресторана с таким id не существует");
        }

        return result;
    }
}
