using ToDoApp.Models;

namespace ToDoApp.Services;

public interface IDataAccess
{
    Task<List<ToDo>>GetToDoListAsync();

    Task<ToDo> SaveNoteAsync(ToDo newItemToDo);
}