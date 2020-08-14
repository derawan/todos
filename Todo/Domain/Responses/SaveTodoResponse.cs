using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Models;

namespace Todo.Domain.Responses
{
    public class SaveTodoResponse : BaseResponse
    {
        public TodoItem TodoItem { get; private set; }

        private SaveTodoResponse(bool success, string message, TodoItem todo) : base(success, message)
        {
            TodoItem = todo;
        }

        /// <summary>
        /// Create Response
        /// </summary>
        /// <param name="todo"></param>
        public SaveTodoResponse(TodoItem todo) : this(true, string.Empty, todo)
        { }

        public SaveTodoResponse(string message) : this(false, message, null)
        { }
    }
}
