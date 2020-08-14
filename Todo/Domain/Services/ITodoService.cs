using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Models;
using Todo.Domain.Responses;

namespace Todo.Domain.Services
{
    public interface ITodoService
    {
        /// <summary>
        /// Get All Todo
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TodoItem>> ListAsync();


        /// <summary>
        ///  Get Specific Todo - Get Todo By Criteria
        ///  % complete, date or title
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TodoItem>> ListByCriteriaAsync();

        /// <summary>
        /// Get Incoming ToDo (for today/next day/current week)
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TodoItem>> GetIncomingTodoAsync();

        /// <summary>
        /// Create New Todo Item
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        Task<SaveTodoResponse> SaveAsync(TodoItem todo);

        /// <summary>
        /// Update Existing Todo Item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todo"></param>
        /// <returns></returns>
        Task<SaveTodoResponse> UpdateAsync(long id, TodoItem todo);

        /// <summary>
        /// Update Existing Todo Completion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todo"></param>
        /// <returns></returns>
        Task<SaveTodoResponse> UpdateCompletionAsync(long id, decimal percentage);


        /// <summary>
        /// Mark As Complete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todo"></param>
        /// <returns></returns>
        Task<SaveTodoResponse> MarkComplete(long id);

        /// <summary>
        /// Delete Existing Todo Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SaveTodoResponse> DeleteAsync(long id);
        /*
         * Get All Todo’s
         * Get Specific Todo
         * Get Incoming ToDo (for today/next day/current week)
         * Create Todo
         * Update Todo
         * Set Todo percent complete
         * Delete Todo
         * Mark Todo as Done
         */
    }
}
