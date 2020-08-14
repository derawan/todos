/*
        * Get All Todo’s - DONE
        * Get Specific Todo
        * Get Incoming ToDo (for today/next day/current week)
        * Create Todo - DONE
        * Update Todo - DONE
        * Set Todo percent complete
        * Delete Todo - DONE
        * Mark Todo as Done
        */
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Domain.Models;
using Todo.Domain.Services;
using Todo.Resources;
using Todo.Utilities;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoProgressController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public TodoProgressController(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }


        /// <summary>
        /// Update Progress Completion
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public async Task<IActionResult> PostAsync(int id, [FromBody] ProgressResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _todoService.UpdateCompletionAsync(id, resource.Progress);

            if (!result.Success)
                return BadRequest(result.Message);

            var todoResource = _mapper.Map<TodoItem, TodoResource>(result.TodoItem);
            return Ok(todoResource);
        }

        /// <summary>
        /// Mark Todo As Completed
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _todoService.MarkComplete(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var todoResource = _mapper.Map<TodoItem, TodoResource>(result.TodoItem);
            return Ok(todoResource);
        }





    }
}