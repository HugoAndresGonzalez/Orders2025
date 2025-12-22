using Microsoft.EntityFrameworkCore;
using Order.Backend.Data;
using Order.Backend.Helpers;
using Order.Backend.Repositories.Interfaces;
using Order.Shared.DTO;
using Order.Shared.Responses;
using System;

namespace Order.Backend.Repositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DataContext _contex;
    private readonly DbSet<T> _entity;

    public GenericRepository(DataContext contex)
    {
        _contex = contex;
        _entity = contex.Set<T>();
    }

    public virtual async Task<ActionResponse<T>> AddAsync(T entity)
    {
        _contex.Add(entity);
        try
        {
            await _contex.SaveChangesAsync();
            return new ActionResponse<T>
            {
                IsSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception exception)
        {
            return ExceptionActionResponse(exception);
        }
    }

    public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
    {
        var row = await _entity.FindAsync(id);
        if (row == null)
        {
            return new ActionResponse<T>
            {
                Message = "El registro no existe."
            };
        }
        _entity.Remove(row);

        try
        {
            await _contex.SaveChangesAsync();
            return new ActionResponse<T>
            {
                IsSuccess = true,
            };
        }
        catch
        {
            return new ActionResponse<T>
            {
                Message = "No se pudo eliminar el registro, por tener registros relacionados."
            };
        }
    }

    public virtual async Task<ActionResponse<T>> GetAsync(int id)
    {
        var row = await _entity.FindAsync(id);
        if (row == null)
        {
            return new ActionResponse<T>
            {
                Message = "El registro no existe."
            };
        }
        return new ActionResponse<T>
        {
            IsSuccess = true,
            Result = row
        };
    }

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync()
    {
        return new ActionResponse<IEnumerable<T>>
        {
            IsSuccess = true,
            Result = await _entity.ToListAsync()
        };
    }

    public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
    {
        _contex.Update(entity);
        try
        {
            await _contex.SaveChangesAsync();
            return new ActionResponse<T>
            {
                IsSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception exception)
        {
            return ExceptionActionResponse(exception);
        }
    }

    private ActionResponse<T> ExceptionActionResponse(Exception exception)
    {
        return new ActionResponse<T>
        {
            Message = exception.Message
        };
    }

    private ActionResponse<T> DbUpdateExceptionActionResponse()
    {
        return new ActionResponse<T>
        {
            Message = "Ya existe el registro."
        };
    }

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _entity.AsQueryable();

        return new ActionResponse<IEnumerable<T>>
        {
            IsSuccess = true,
            Result = await queryable
            .Paginate(pagination)
            .ToListAsync()
        };
    }

    public virtual async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var queryable = _entity.AsQueryable();
        double count = await queryable.CountAsync();
        return new ActionResponse<int>
        {
            IsSuccess = true,
            Result = (int)count
        };
    }
}