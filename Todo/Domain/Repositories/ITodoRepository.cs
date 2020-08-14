using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Models;
using System.Linq;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        /// <summary>
        /// List All Todos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TodoItem>> ListAsync();

        /// <summary>
        /// Add New Todos
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        Task AddAsync(TodoItem todoItem);

        /// <summary>
        /// Find todo By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TodoItem> FindByIdAsync(long id);




        /// <summary>
        /// Update Existing Todo
        /// </summary>
        /// <param name="todo"></param>
        void Update(TodoItem todo);

        /// <summary>
        /// Delete Existing Todo
        /// </summary>
        /// <param name="todo"></param>
        void Remove(TodoItem todo);

    }
}
