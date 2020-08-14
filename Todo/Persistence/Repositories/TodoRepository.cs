using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Models;
using Todo.Domain.Repositories;
using Todo.Persistence.Contexts;

namespace Todo.Persistence.Repositories
{
    public class TodoRepository : BaseRepository, ITodoRepository
    {
        public TodoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(TodoItem todoItem)
        {
            await _context.TodoItems.AddAsync(todoItem);
        }

        public async Task<TodoItem> FindByIdAsync(long id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task<IEnumerable<TodoItem>> ListAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public void Remove(TodoItem todo)
        {
            _context.TodoItems.Remove(todo);
        }

        public void Update(TodoItem todo)
        {
            _context.TodoItems.Update(todo);
        }
    }
}
