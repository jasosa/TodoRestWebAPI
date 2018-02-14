using System;
using System.Collections.Generic;
using System.Linq;
using TodoAppRestAPI.Interfaces;
using TodoAppRestAPI.Models;

namespace TodoAppRestAPI.Services
{
    public class ToDoRepository : IToDoRepository
    {
        private List<TodoItem> _todoList;

        public ToDoRepository()
        {
            InitializeData();
        }

        public IEnumerable<TodoItem> All
        {
            get { return _todoList; }
        }

        public void Delete(string id)
        {
            _todoList.Remove(this.Find(id));
        }

        public bool DoesItemExist(string id)
        {
            return _todoList.Any(item => item.ID == id);
        }

        public TodoItem Find(string id)
        {
            return _todoList.FirstOrDefault(item => item.ID == id);
        }

        public void Insert(TodoItem item)
        {
            _todoList.Add(item);
        }

        public void Update(TodoItem item)
        {
            var toDoitem = this.Find(item.ID);
            var index = _todoList.IndexOf((toDoitem));
            _todoList.RemoveAt(index);
            _todoList.Insert(index, item);
        }

        private void InitializeData()
        {
            _todoList = new List<TodoItem>();

            _todoList.Add(TodoItemBuilder.BuildItemLearnAppDevelopment());
            _todoList.Add(TodoItemBuilder.BuildItemDevelopApps());
            _todoList.Add(TodoItemBuilder.BuildItemPublishApps());
        }
    }
}
