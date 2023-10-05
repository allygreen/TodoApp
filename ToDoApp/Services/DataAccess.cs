using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Services;

using Data;

public class DataAccess : IDataAccess
{
    public NoteContext _dbContext;
    public DataAccess(NoteContext noteContext)
    {
        _dbContext = noteContext;
    }
    
    public async Task<List<ToDo>> GetToDoListAsync()
    {
        return await _dbContext.Notes.ToListAsync();
        
    }

    public async Task<bool> SaveNoteAsync(ToDo newItemToDo)
    {
        try
        {
            newItemToDo.createdDate = DateTime.Now;
            await _dbContext.AddAsync(newItemToDo);
            await _dbContext.SaveChangesAsync(true);
            return true;
        }
        catch (Exception ex)
        {
           // _logger.LogError(ex, "Error creating app");
            return false;
        }
    }
    public async Task<ToDo> UpdateNoteAsync(ToDo updatedToDo)
    {
        try
        {
            var existingToDo = await _dbContext.Notes.FirstOrDefaultAsync(n => n.ToDoId == updatedToDo.ToDoId);
            if (existingToDo == null)
            {
                // new note
                updatedToDo.createdDate = DateTime.Now;
                await _dbContext.Notes.AddAsync(updatedToDo); 
                await _dbContext.SaveChangesAsync();
                
                return updatedToDo;
            }

            // Updating properties all of them - maybe better as an attach
            existingToDo.createdDate = updatedToDo.createdDate;
            existingToDo.Completed = updatedToDo.Completed;
            existingToDo.Summary = updatedToDo.Summary;
            existingToDo.Description = updatedToDo.Description;
            existingToDo.Title = updatedToDo.Title;
            existingToDo.dateCompleted = updatedToDo.dateCompleted;

            _dbContext.Notes.Update(existingToDo); 
            await _dbContext.SaveChangesAsync();
            return existingToDo;
        }
        catch (Exception ex)
        {
            // _logger.LogError(ex, "Error updating note");
            return null;
        }
    }

}