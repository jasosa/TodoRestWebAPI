using System;
using System.Collections.Generic;
using TodoAppRestAPI.Models;

namespace TodoAppRestAPI.Interfaces
{
    public interface IToDoRepository
    {
        bool DoesItemExist(string id);
        IEnumerable<TodoItem> All { get; }
        TodoItem Find(string id);
        void Insert(TodoItem item);
        void Update(TodoItem item);
        void Delete(string id);
    }
}
