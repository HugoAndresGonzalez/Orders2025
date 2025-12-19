using Microsoft.AspNetCore.Mvc;
using Order.Backend.UnitsOfWork.Interfaces;
using Order.Shared.DTO;

namespace Order.Backend.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private readonly IGenericUnitsOfWork<T> _unitsOfWork;

        public GenericController(IGenericUnitsOfWork<T> UnitsOfWork)
        {
            _unitsOfWork = UnitsOfWork;
        }

        [HttpGet("paginated")]
        public virtual async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _unitsOfWork.GetAsync(pagination);
            if (response.IsSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("totalRecords")]
        public virtual async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _unitsOfWork.GetTotalRecordsAsync(pagination);
            if (response.IsSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAsync()
        {
            var response = await _unitsOfWork.GetAsync();
            if (response.IsSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetAsync(int id)
        {
            var action = await _unitsOfWork.GetAsync(id);
            if (action.IsSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpPost]
        public virtual async Task<IActionResult> PostAsync(T model)
        {
            var action = await _unitsOfWork.AddAsync(model);
            if (action.IsSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpPut]
        public virtual async Task<IActionResult> PutAsync(T model)
        {
            var action = await _unitsOfWork.UpdateAsync(model);
            if (action.IsSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            var action = await _unitsOfWork.DeleteAsync(id);
            if (action.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(action.Message);
        }
    }
}