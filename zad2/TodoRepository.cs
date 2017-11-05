using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace zad2
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
        }
        public TodoItem Get(Guid todoId)
        {
            if (Contains(todoId)) return _inMemoryTodoDatabase.First(i => i.Id == todoId);
            else return null;
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (!_inMemoryTodoDatabase.Contains(todoItem)) _inMemoryTodoDatabase.Add(todoItem);
            else throw new DuplicateTodoItemException("duplicate id: " + todoItem.Id);

            return todoItem;
        }

        public bool Remove(Guid todoId)
        {
            return _inMemoryTodoDatabase.Remove(Get(todoId));
        }


        public bool MarkAsCompleted(Guid todoId)
        {
            return _inMemoryTodoDatabase.First(i => i.Id == todoId).MarkAsCompleted();
        }

        public TodoItem Update(TodoItem todoItem)
        {
            int index = _inMemoryTodoDatabase.IndexOf(todoItem);
            TodoItem a = _inMemoryTodoDatabase.GetElement(index);
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                a = todoItem;
                _inMemoryTodoDatabase.RemoveAt(index);
            }
            _inMemoryTodoDatabase.Add(a);
            return todoItem;
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderBy(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(i => i.DateCompleted == null).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(i => i.DateCompleted != null).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(i => filterFunction(i)).ToList();
        }
        public int Count()
        {
            return GetAll().Count;
        }
        public bool Contains(Guid todoId)
        {
            return (_inMemoryTodoDatabase.Where(i => i.Id == todoId).Count() == 0) ? false : true;
        }
    }
}
