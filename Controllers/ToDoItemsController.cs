using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAppRestAPI.Interfaces;
using TodoAppRestAPI.Models;

namespace TodoAppRestAPI.Models
{
    [Route("api/[controller]")]
    public class ToDoItemsController : Controller
    {
        private readonly IToDoRepository repository;

        public ToDoItemsController(IToDoRepository todoRepository)
        {
            this.repository = todoRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(repository.All);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesrequired.ToString());
                }

                if (itemAlreadyExists(item))
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TodoItemAlreadyExists.ToString());                    
                }

                this.repository.Insert(item);
                return Ok(item);
            }
            catch(Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] TodoItem item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesrequired.ToString());
                }

                if (!itemAlreadyExists(item))
                {
                    return NotFound(ErrorCode.ItemNotFound.ToString());
                }

                this.repository.Update(item);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
            }
        }

        public IActionResult Delete (string id)
        {
            try
            {
                var item = repository.Find(id);
                if(item == null)
                {
                    return NotFound(ErrorCode.ItemNotFound.ToString());
                }

                this.repository.Delete(id);
            }
            catch(Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }

            return NoContent();

        }

        private bool itemAlreadyExists(TodoItem item)
        {
            return this.repository.DoesItemExist(item.ID);
        }
    }
}
