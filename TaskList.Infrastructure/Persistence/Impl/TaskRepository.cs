using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using TaskList.Domain.Entities.Tasks;
using TaskList.Domain.Persistence.Interfaces;
using TaskList.Domain.Tools.ResultPattern;
using TaskList.Infrastructure.Context;

namespace TaskList.Infrastructure.Persistence.Impl;

public class TaskRepository(TaskContext context): ITaskRepository
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

    public async Task<Result> ConcludeTaskByIdAsync(int id)
    { 
        try
        {
            var entity = await context.Tasks.FindAsync(id);

            if (entity is null)
            {
                return Error.NotFound($"Não foi possível encontrar o registro com ID {id}");
            }

            entity.Done = true;
            entity.ConslusionDateTime = DateTime.Now;

            await context.SaveChangesAsync();
            return Result.Ok();
        } 
        catch (Exception ex)
        {
            return Error.InternalServer($"Não foi possível concluir a tarefa de ID {id}. Detalhes: {ex.Message}");
        }
    }

    public async Task<Result> DeleteTaskByIdAsync(int id)
    {
        try
        {
            var entity = await context.Tasks.FindAsync(id);

            if (entity is null)
            {
                return Error.NotFound($"Não foi possível encontrar o registro com ID {id}");
            }
            
            context.Tasks.Remove(entity);
            await context.SaveChangesAsync();
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Error.InternalServer($"Não foi possível remover a tarefa de ID {id}. Detalhes: {ex.Message}");
        }
    }

    public async Task<Result<IEnumerable<UserTask>>> FindAsync()
    {
        try
        {
            return Result<IEnumerable<UserTask>>.Ok(await context.Tasks.ToListAsync());
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
