using Microsoft.EntityFrameworkCore;
using Order.Backend.Data;
using Order.Backend.Helpers;
using Order.Backend.Repositories.Interfaces;
using Order.Shared.DTO;
using Order.Shared.Entidades;
using Order.Shared.Responses;

namespace Order.Backend.Repositories.Implementations;

public class CountryRepository : GenericRepository<Country>, ICountriesRepository
{
    private readonly DataContext _contex;

    public CountryRepository(DataContext contex) : base(contex)
    {
        _contex = contex;
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync()
    {
        var countries = await _contex.Countries
            .Include(X => X.States)
            .ToListAsync();
        return new ActionResponse<IEnumerable<Country>>
        {
            IsSuccess = true,
            Result = countries
        };
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _contex.Countries
            .Include(c => c.States)
            .AsQueryable();

        return new ActionResponse<IEnumerable<Country>>
        {
            IsSuccess = true,
            Result = await queryable
            .OrderBy(x => x.Name)
            .Paginate(pagination)
            .ToListAsync()
        };

    }
    public override async Task<ActionResponse<Country>> GetAsync(int id)
    {
        var country = await _contex.Countries
         .Include(x => x.States!)
         .ThenInclude(x => x.Cities)
         .FirstOrDefaultAsync(x => x.Id == id);
        if (country == null)
        {
            return new ActionResponse<Country>
            {
                Message = "Registro no Encontrado",
            };
        }
        return new ActionResponse<Country>
        {
            IsSuccess = true,
            Result = country
        };
    }
}