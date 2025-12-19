using Order.Backend.UnitsOfWork.Interfaces;
using Order.Shared.Entidades;
using Order.Backend.Repositories.Interfaces;
using Order.Shared.Responses;

namespace Order.Backend.UnitsOfWork.Implementations;

public class CountriesUnitsOfWork : GenericUnitsOfWork<Country>, ICountriesUnitOfWork
{
    private readonly ICountriesRepository _countriesRepository;

    public CountriesUnitsOfWork(IGenericRepository<Country> repository, ICountriesRepository countriesRepository) : base(repository)
    {
        _countriesRepository = countriesRepository;
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync() => await _countriesRepository.GetAsync();

    public override async Task<ActionResponse<Country>> GetAsync(int id) => await _countriesRepository.GetAsync(id);
}