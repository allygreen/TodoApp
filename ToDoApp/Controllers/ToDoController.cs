using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ToDoController> _logger;

    public ToDoController(ILogger<ToDoController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<ToDo> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new ToDo()
            {
                createdDate = DateTime.Now,
                Title = "Title",
                Summary = "Summary"
            })
            .ToArray();
    }
    
    [HttpPost]
    public Task<IActionResult> Post()
    {
        return Task.FromResult((IActionResult) Ok());
    }
}