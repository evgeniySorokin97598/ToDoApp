using Entities;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Repositories.Interfaces;
using ToDoList.Repositories.Repositories;

namespace ToDoList.Controllers
{
    [Route("ToDo")]
    public class ToDoController : Controller
    {
        private IToDoListRepository _repository;
        public ToDoController(IToDoListRepository repository)
        {
            _repository = repository;


        }

        [HttpGet("GetToDoList")]
        public async Task<IActionResult> GetToDoListAsync()
        {
            try
            {
                var result = await _repository.GetToDoListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetTaskById/{Id}")]
        public async Task<IActionResult> GetTaskById(long Id) {
            try
            {
                var result = await _repository.GetTaskById(Id);
                return Ok(result);
            }
            catch (Exception ex) { 
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddTask")]
        public async Task<IActionResult> AddToDoAsync([FromBody] ToDo toDo)
        {
            try
            {
                var result = await _repository.AddToDoAsync(toDo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("RemoveTask/{id}")]
        public async Task<IActionResult> RemoveToDo(long id)
        {
            try
            {
                await _repository.RemoveToDo(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPut("Edit")]
        public async Task<IActionResult> EditToDo([FromBody] ToDo toDo)
        {
            try
            {
                await _repository.Edit(toDo);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
