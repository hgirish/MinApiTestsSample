﻿using Microsoft.EntityFrameworkCore;
using MinApiTestsSample.Data;

namespace MinApiTestsSample.Services;

public class TodoService : ITodoService
{
    private readonly TodoGroupDbContext _dbContext;
    private readonly IEmailService _emailService;

    public TodoService(TodoGroupDbContext dbContext,
        IEmailService emailService)
    {
        _dbContext = dbContext;
        _emailService = emailService;
    }
    public async Task Add(Todo todo)
    {
        await _dbContext.AddAsync(todo);

        if (await _dbContext.SaveChangesAsync() > 0)
        {
            await _emailService.Send("hello@example.com",
                $"New todo has been added: {todo.Title}");
        }
    }

    public async ValueTask<Todo?> Find(int id)
    {
        return await _dbContext.Todos.FindAsync(id);
    }

    public async Task<List<Todo>> GetAll()
    {
        return await _dbContext.Todos.ToListAsync();
    }

    public async Task<List<Todo>> GetIncompleteTodos()
    {
        return await _dbContext.Todos.Where(t => t.IsDone == false).ToListAsync();
    }

    public async Task Remove(Todo todo)
    {
        _dbContext.Todos.Remove(todo);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Todo todo)
    {
        _dbContext.Todos.Update(todo);
        await _dbContext.SaveChangesAsync();
    }
}