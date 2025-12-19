using ModeloServices.Entities;
using Microsoft.EntityFrameworkCore;
using ModeloServices.Context;
using ModeloServices.Models;

namespace ModeloServices.Managers;

public class ServicesManager(AppDbContext _dbContext)
{
    public List<Service> GetAll(int UserId,)
    {
        var list = _dbContext.Services
            .Where(item => item.UserId == UserId)
            .Select(Item => new ServiceVM
            {
                ServiceId = Item.ServiceId,
                UserId = Item.UserId,
                name = Item.name,
                type = Item.type
            })
            .ToList();
        return list;
    }
}