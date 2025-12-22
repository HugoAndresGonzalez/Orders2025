using Order.Shared.DTO;
using Order.Shared.Entidades;
using Order.Shared.Responses;

namespace Order.Backend.UnitsOfWork.Interfaces
{
    public interface ICitiesUnitsOfWork
    {
        Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    }
}