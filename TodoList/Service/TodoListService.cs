using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Data;
using TodoList.Data.Entities;
using TodoList.Repository;

namespace TodoList.Service
{
    public class TodoListService : ITodoListRepo
    {
        private readonly TodoListDBContext _toDoListContext;

        public TodoListService(TodoListDBContext toDoListDBContext)
        {
            _toDoListContext = toDoListDBContext;
        }
        public void CreateItem(TodoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _toDoListContext.TodoItems.Add(item);
            _toDoListContext.SaveChanges();
        }

        public void DeleteItem(TodoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _toDoListContext.TodoItems.Remove(item);
            _toDoListContext.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAllItems()
        {
            return _toDoListContext.TodoItems.ToList();
        }

        public TodoItem GetItem(int id)
        {
            return _toDoListContext.TodoItems.FirstOrDefault(item => item.Id == id);
        }

        public bool SaveChanges()
        {
            return (_toDoListContext.SaveChanges() >= 0);
        }

        public void UpdateItem(TodoItem item)
        {
            //Nothing because automaper will be handled in this case.
        }
    }
}
