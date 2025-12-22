using Microsoft.EntityFrameworkCore;
using Order.Backend.Data;
using Order.Backend.Helpers;
using Order.Backend.Repositories.Interfaces;
using Order.Shared.DTO;
using Order.Shared.Entidades;
using Order.Shared.Responses;

namespace Order.Backend.Repositories.Implementations
{
    public class CityRepository : GenericRepository<City>, ICitiesRepository
    {
        private readonly DataContext _context;

        public CityRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Cities
                .Where(x => x.State!.Id == pagination.Id)
                .AsQueryable();

            return new ActionResponse<IEnumerable<City>>
            {
                IsSuccess = true,
                Result = await queryable
                    .OrderBy(x => x.Name)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
        {
            var queryable = _context.Cities
                .Where(x => x.State!.Id == pagination.Id)
                .AsQueryable();

            double count = await queryable.CountAsync();
            return new ActionResponse<int>
            {
                IsSuccess = true,
                Result = (int)count
            };
        }
    }
}