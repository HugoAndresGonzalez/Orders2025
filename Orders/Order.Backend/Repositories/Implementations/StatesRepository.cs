using Microsoft.EntityFrameworkCore;
using Order.Backend.Data;
using Order.Backend.Helpers;
using Order.Backend.Repositories.Implementations;
using Order.Backend.Repositories.Interfaces;
using Order.Shared.DTO;
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

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var queryable = _context.States
            .Where(x => x.Country!.Id == pagination.Id)
            .AsQueryable();

        double count = await queryable.CountAsync();
        return new ActionResponse<int>
        {
            IsSuccess = true,
            Result = (int)count
        };
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.States
            .Include(s => s.Cities)
            .Where(x => x.Country!.Id == pagination.Id)
            .AsQueryable();

        return new ActionResponse<IEnumerable<State>>
        {
            IsSuccess = true,
            Result = await queryable
            .OrderBy(x => x.Name)
            .Paginate(pagination)
            .ToListAsync()
        };
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