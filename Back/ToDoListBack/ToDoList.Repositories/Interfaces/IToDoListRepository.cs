using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Repositories.Interfaces
{
    public interface IToDoListRepository
    {
        public Task<IEnumerable<ToDo>> GetToDoListAsync();
        public Task<long> AddToDoAsync(ToDo toDo);
        public Task RemoveToDo(long Id);
        public Task Edit(ToDo toDo);
        public Task<ToDo> GetTaskById(long Id);
    }
}
