using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Models
{

    public class Crud
    {
        private readonly TodoContext _context;
        
        public Crud(TodoContext context)
        {
            _context = context;

        }
        
        public List<TodoItem> GetAllElements()
        {
            return _context.TodoItems.ToList();
        }

        public TodoItem GetElement(long id)
        {
            var item = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            return item;
        }

        public bool AddElement(TodoItem item)
        {
            if (item == null)
            {
                return false;
            }
           
            Utils _utils = new Utils();
            item.TimestampUpdate = _utils.GetTimestamp(System.DateTime.Now);
            item.Content = _utils.DataToJson(item);

            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return true;
        }

        public int UpdateElement(long id,TodoItem item)
        {
            if (item == null || item.Id != id)
            {
                return GlobalConstants.NOT_FOUND;
            }
            var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return GlobalConstants.BAD_REQUEST;
            }


            Utils _utils = new Utils();
            todo.TimestampUpdate = _utils.GetTimestamp(System.DateTime.Now);
            todo.Name = item.Name;

            todo.Content = _utils.DataToJson(todo);
            _context.TodoItems.Update(todo);
            _context.SaveChanges();

            return GlobalConstants.REQUEST_OK;
        }

        public int DeleteElement(long id)
        {
            var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return GlobalConstants.NOT_FOUND;
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return GlobalConstants.REQUEST_OK;
        }
    }


}
