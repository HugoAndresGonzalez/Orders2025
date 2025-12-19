using Microsoft.EntityFrameworkCore;
using Order.Backend.Data;
using Order.Backend.Repositories.Implementations;
using Order.Backend.Repositories.Interfaces;
using Order.Shared.Entidades;
using Order.Shared.Responses;

namespace Orders.Backend.Repositories.Implementations;

public class StatesRepository : GenericRepository<State>, IStatesRepository
{
    private readonly DataContext _context;

    public StatesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync()
    {
        var states = await _context.States
        .Include(s => s.Cities)
        .ToListAsync();
        return new ActionResponse<IEnumerable<State>>
        {
            IsSuccess = true,
            Result = states
        };
    }

    public override async Task<ActionResponse<State>> GetAsync(int id)
    {
        var state = await _context.States
        .Include(s => s.Cities)
        .FirstOrDefaultAsync(s => s.Id == id);

        if (state == null)
        {
            return new ActionResponse<State>
            {
                IsSuccess = false,
                Message = "Estado no existe"
            };
        }
        return new ActionResponse<State>
        {
            IsSuccess = true,
            Result = state
        };
    }
}