using ToDoApp.Models;

namespace ToDoApp.Services;

public interface IDataAccess
{
    Task<List<ToDo>>GetToDoListAsync();
    Task<bool> SaveNoteAsync(ToDo newItemToDo);
    Task<bool> UpdateNoteAsync(ToDo updatedToDo);
}