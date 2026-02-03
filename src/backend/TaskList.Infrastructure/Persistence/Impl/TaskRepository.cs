using Microsoft.EntityFrameworkCore;
using TaskList.Domain.Entities.Tasks;
using TaskList.Domain.Persistence.Interfaces;
using TaskList.Domain.Tools.ResultPattern;
using TaskList.Infrastructure.Context;
using TaskList.Infrastructure.Extensions;

namespace TaskList.Infrastructure.Persistence.Impl;

public class TaskRepository(TaskContext context) : ITaskRepository
{
    public async Task<Result<int>> AddAsync(UserTask value)
    {
        try
        {
            await context.Tasks.AddAsync(value);
            await context.SaveChangesAsync();

            return Result<int>.Ok(value.Id);
        }
        catch (Exception ex)
        {
            return Error.InternalServer($"Não foi possível criar o registro. Detalhes: {ex.Message}");
        }
    }

    public async Task<Result> ConcludeTasksByIdAsync(IEnumerable<int> ids)
    {
        try
        {
            var affected = await context.Tasks
                .Where(task => ids.Contains(task.Id))
                .ExecuteUpdateAsync(task =>
                {
                    task.SetProperty(x => x.ConslusionDateTime, DateTime.Now);
                    task.SetProperty(x => x.Done, true);
                });

            if (affected != ids.Count())
            {
                return Error.NotFound($"Somente {affected} registros de {ids.Count()} foram marcados como 'Concluído'.");
            }

            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Error.InternalServer($"Não foi possível concluir a tarefa de ID {ids}. Detalhes: {ex.Message}");
        }
    }

    public async Task<Result> DeleteTasksByIdAsync(IEnumerable<int> ids)
    {
        try
        {
            var affected = await context.Tasks
                .Where(task => ids.Contains(task.Id))
                .ExecuteDeleteAsync();

            if (affected != ids.Count())
            {
                return Error.NotFound($"Somente {affected} registros de {ids.Count()} foram deletados.");
            }

            await context.SaveChangesAsync();
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Error.InternalServer($"Não foi possível remover a tarefa de ID {ids}. Detalhes: {ex.Message}");
        }
    }

    public async Task<Result<IEnumerable<UserTask>>> FindManyAsync(TaskFilters filters)
    {
        try
        {
            var found = await context.Tasks
                .AsQueryable()
                .ApplyFilters(filters)
                .ToListAsync();

            if (found is null)
            {
                return Error.NotFound($"Não foi possível encontrar registros com os filtros {filters}.");
            }

            return Result<IEnumerable<UserTask>>.Ok(found);
        }
        catch (Exception ex)
        {
            return Error.InternalServer($"Não foi possível buscar as tarefas. Detalhes: {ex.Message}");
        }
    }

    public async Task<Result<UserTask>> FindByIdAsync(int id)
    {
        try
        {
            var entity = await context.Tasks.FindAsync(id);

            if (entity is null)
            {
                return Error.NotFound($"Não foi possível encontrar o registro com ID {id}");
            }

            return entity;
        }
        catch (Exception ex)
        {
            return Error.InternalServer($"Não foi possível buscar a tarefa de ID {id}. Detalhes: {ex.Message}");
        }
    }

    public async Task<Result> UpdateTaskByIdAsync(int id, UserTask value)
    {
        try
        {
            var entity = await context.Tasks.FindAsync(id);

            if (entity is null)
            {
                return Error.NotFound($"Não foi possível encontrar o registro com ID {id}");
            }

            entity = value;
            await context.SaveChangesAsync();
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Error.InternalServer($"Não foi possível remover a tarefa de id {id}. Detalhes: {ex.Message}");
        }
    }
}
