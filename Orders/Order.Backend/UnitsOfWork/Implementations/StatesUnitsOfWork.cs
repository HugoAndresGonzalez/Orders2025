using Order.Backend.Repositories.Interfaces;
using Order.Backend.UnitsOfWork.Implementations;
using Order.Backend.UnitsOfWork.Interfaces;
using Order.Shared.Entidades;
using Order.Shared.Responses;

namespace Orders.Backend.UnitsOfWork.Implementations;

public class StatesUnitOfWork : GenericUnitsOfWork<State>, IStatesUnitsOfWork
{
    private readonly IStatesRepository _statesRepository;

    public StatesUnitOfWork(IGenericRepository<State> repository, IStatesRepository statesRepository) : base(repository)
    {
        _statesRepository = statesRepository;
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync() => await
    _statesRepository.GetAsync();

    public override async Task<ActionResponse<State>> GetAsync(int id) => await _statesRepository.GetAsync(id);
}