using Order.Backend.Repositories.Interfaces;
using Order.Backend.UnitsOfWork.Interfaces;
using Order.Shared.DTO;
using Order.Shared.Entidades;
using Order.Shared.Responses;
using Orders.Backend.Repositories.Implementations;

namespace Order.Backend.UnitsOfWork.Implementations
{
    public class CitiesUnitsOfWork : GenericUnitsOfWork<City>, ICitiesUnitsOfWork
    {
        private readonly ICitiesRepository _citiesRepository;

        public CitiesUnitsOfWork(IGenericRepository<City> repository, ICitiesRepository citiesRepository) : base(repository)
        {
            _citiesRepository = citiesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination) => await _citiesRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _citiesRepository.GetTotalRecordsAsync(pagination);
    }
}