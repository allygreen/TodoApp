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
}