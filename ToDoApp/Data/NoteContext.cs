namespace ToDoApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Models;

public class NoteContext : DbContext
{
    public DbSet<ToDo> Notes { get; set; }

    public string DbPath { get; }

    public NoteContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "todo.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
