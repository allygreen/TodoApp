using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoController : ControllerBase
{
    private IDataAccess _dataAccess;
    private readonly ILogger<ToDoController> _logger;

    public ToDoController(ILogger<ToDoController> logger, IDataAccess dataAccess)
    {
        _logger = logger;
        _dataAccess = dataAccess;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var toDoList = await _dataAccess.GetToDoListAsync();
        return Ok(toDoList);
    }
    
    [HttpPost]
    public Task<IActionResult> Post()
    {
        return Task.FromResult((IActionResult) Ok());
    }
}