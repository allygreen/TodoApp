namespace ToDoApp.Models;

public class ToDo
{
    public DateTime createdDate { get; set; }
    
    public bool Completed { get; set; }
    
    public string Summary { get; set; }
    
    public string Description { get; set; }
    
    public string Title { get; set; }
    
    public DateTime dateCompleted { get; set; }
}
