using Order.Shared.Entidades;
using Order.Shared.Responses;

namespace Order.Backend.UnitsOfWork.Interfaces;

public interface IStatesUnitsOfWork
{
    Task<ActionResponse<State>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<State>>> GetAsync();
}