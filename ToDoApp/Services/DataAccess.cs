using ToDoApp.Models;

namespace ToDoApp.Services;

public class DataAccess : IDataAccess
{
    public Task<List<ToDo>> GetToDoListAsync()
    {
        return Task.FromResult(new List<ToDo>()
        {
            new ToDo()
            {
                Completed = true,
                createdDate = DateTime.Today,
                dateCompleted = DateTime.Today,
                Title = "New Note",
                Description = "Here's a description",
                Summary = "Summary!"
            }
        });
    }

    public Task<ToDo> SaveNoteAsync(ToDo newItemToDo)
    {

        return Task.FromResult(new ToDo());
    }
}