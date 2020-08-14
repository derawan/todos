using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Domain.Models;
using Todo.Domain.Services;
using Todo.Resources;
using Todo.Utilities;
using System.Linq;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public TodosController(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        /// <summary>
        /// * Get All Todo’s or by its id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id?}")]
        public async Task<IEnumerable<TodoResource>> GetAllTodoAsync(int? id)
        {
            IEnumerable<TodoItem> todos = null;
            if (id.HasValue)
            {
                todos = await _todoService.ListAsync();
                todos = todos.Where(p => p.Id == id);

            }
            else
            {
                todos = await _todoService.ListAsync();
            }
            var resources = _mapper.Map<IEnumerable<TodoItem>, IEnumerable<TodoResource>>(todos);

            return resources;
        }




        /// <summary>
        /// * Get Specific Todo
        /// </summary>
        /// <returns></returns>
        /*[Route("api/[controller]/{id}")]
        [HttpGet("id")]
        public async Task<IEnumerable<TodoResource>> GetMe(int id)
        {
            var todos = await _todoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<TodoItem>, IEnumerable<TodoResource>>(todos);

            return resources;
        }*/

        /// <summary>
        /// Create New Todo
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTodoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var todo = _mapper.Map<SaveTodoResource, TodoItem>(resource);
            var result = await _todoService.SaveAsync(todo);

            if (!result.Success)
                return BadRequest(result.Message);

            var todoResource = _mapper.Map<TodoItem, TodoResource>(result.TodoItem);
            return Ok(todoResource);
        }

        /// <summary>
        /// Update Todo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTodoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var todo = _mapper.Map<SaveTodoResource, TodoItem>(resource);
            var result = await _todoService.UpdateAsync(id, todo);

            if (!result.Success)
                return BadRequest(result.Message);

            var todoResource = _mapper.Map<TodoItem, TodoResource>(result.TodoItem);
            return Ok(todoResource);
        }


        /// <summary>
        /// Delete Existing Todo Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _todoService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<TodoItem, TodoResource>(result.TodoItem);
            return Ok(categoryResource);
        }



    }
}