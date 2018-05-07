using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Linq;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

        }

        // /api/todo - GET - All elements
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            Crud _crud = new Crud(_context);
            return _crud.GetAllElements();
        }

        // /api/todo/{id} - GET - All info about one element
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            Crud _crud = new Crud(_context);
            TodoItem _item = _crud.GetElement(id);

            if (_item == null)
            {
                return NotFound();
            }
            return new ObjectResult(_item);
        }

        // /api/todo - POST - create a new element
        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            Crud _crud = new Crud(_context);
            if (_crud.AddElement(item))
            {
                return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
            }
            else
            {
                return BadRequest();
            }
        }

        // /api/todo/{id} - PUT - Update one element
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TodoItem item)
        {
            Crud _crud = new Crud(_context);
            int _result = _crud.UpdateElement(id, item);

            switch (_result)
            {
                case GlobalConstants.NOT_FOUND:
                    return NotFound();
                case GlobalConstants.BAD_REQUEST:
                    return BadRequest();
                default:
                    return new NoContentResult();
            }
        }

        // /api/todo/{id} - DELETE - Delete a especific element
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Crud _crud = new Crud(_context);
            int _result = _crud.DeleteElement(id);

            switch (_result)
            {
                case GlobalConstants.NOT_FOUND:
                    return NotFound();
                default:
                    return new NoContentResult();
            }
        }
    }
}
