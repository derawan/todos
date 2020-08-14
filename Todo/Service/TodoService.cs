using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Models;
using Todo.Domain.Repositories;
using Todo.Domain.Responses;
using Todo.Domain.Services;

namespace Todo.Service
{
    public class TodoService : ITodoService
    {
        private ITodoRepository _todoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TodoService(ITodoRepository todoRepository, IUnitOfWork unitOfWork)
        {
            this._todoRepository = todoRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get All Todo
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TodoItem>> ListAsync()
        {
            return await _todoRepository.ListAsync();
        }

       


        /// <summary>
        /// Get Incoming Todo
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TodoItem>> GetIncomingTodoAsync()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// List Todo By Criteria
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TodoItem>> ListByCriteriaAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create New Todo Items
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        public async Task<SaveTodoResponse> SaveAsync(TodoItem todo)
        {
            try
            {
                await _todoRepository.AddAsync(todo);
                await _unitOfWork.CompleteAsync();

                return new SaveTodoResponse(todo);
            }
            catch (Exception ex)
            {
                return new SaveTodoResponse($"An error occurred when saving the todo item: {ex.Message}");
            }
        }

        /// <summary>
        /// Update Existing Todo Items
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todo"></param>
        /// <returns></returns>
        public async Task<SaveTodoResponse> UpdateAsync(long id, TodoItem todo)
        {
            var existingTodo = await _todoRepository.FindByIdAsync(id);

            if (existingTodo == null)
                return new SaveTodoResponse("Todo Item not found.");
            if (existingTodo.Complete == 1)
            {
                return new SaveTodoResponse("Unable to modified completed todo item");
            }

            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;
            existingTodo.ExpiryDate = todo.ExpiryDate;

            try
            {
                _todoRepository.Update(existingTodo);
                await _unitOfWork.CompleteAsync();

                return new SaveTodoResponse(existingTodo);
            }
            catch (Exception ex)
            {
                return new SaveTodoResponse($"An error occurred when updating the todo item: {ex.Message}");
            }
        }

        public async Task<SaveTodoResponse> UpdateCompletionAsync(long id, decimal percentage)
        {
            var existingTodo = await _todoRepository.FindByIdAsync(id);

            if (existingTodo == null)
                return new SaveTodoResponse("Todo Item not found.");
            if (existingTodo.Complete == 1)
            {
                return new SaveTodoResponse("Unable to modified completed todo item");
            }
            if (percentage > 1 && percentage < 0)
            {
                return new SaveTodoResponse("percentage should be between 0-1");
            }

            existingTodo.Complete = percentage;


            try
            {
                _todoRepository.Update(existingTodo);
                await _unitOfWork.CompleteAsync();

                return new SaveTodoResponse(existingTodo);
            }
            catch (Exception ex)
            {
                return new SaveTodoResponse($"An error occurred when updating the todo item: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete Existing Todo Items
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SaveTodoResponse> DeleteAsync(long id)
        {
            var existingTodo = await _todoRepository.FindByIdAsync(id);

            if (existingTodo == null)
                return new SaveTodoResponse("Todo not found.");

            try
            {
                _todoRepository.Remove(existingTodo);
                await _unitOfWork.CompleteAsync();

                return new SaveTodoResponse(existingTodo);
            }
            catch (Exception ex)
            {
                return new SaveTodoResponse($"An error occurred when deleting the todo: {ex.Message}");
            }
        }

        public async Task<SaveTodoResponse> MarkComplete(long id)
        {
            var existingTodo = await _todoRepository.FindByIdAsync(id);

            if (existingTodo == null)
                return new SaveTodoResponse("Todo Item not found.");
            if (existingTodo.Status)
            {
                return new SaveTodoResponse("Unable to modified completed todo item");
            }

            existingTodo.Complete = 1;
            existingTodo.Status = true;


            try
            {
                _todoRepository.Update(existingTodo);
                await _unitOfWork.CompleteAsync();

                return new SaveTodoResponse(existingTodo);
            }
            catch (Exception ex)
            {
                return new SaveTodoResponse($"An error occurred when updating the todo item: {ex.Message}");
            }
        }
    }
}
