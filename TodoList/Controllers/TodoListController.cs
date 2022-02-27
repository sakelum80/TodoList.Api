using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Data.Entities;
using TodoList.Dtos;
using TodoList.Repository;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : Controller
    {
        private readonly ITodoListRepo _todoListRepo;
        private readonly IMapper _mapper;

        public TodoListController(ITodoListRepo todoListRepo, IMapper mapper)
        {
            _todoListRepo = todoListRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<TodoItemReadDto> CreateItem(TodoItemCreateDto todoItemCreateDto)
        {
            var todoItem = _mapper.Map<TodoItem>(todoItemCreateDto);

            _todoListRepo.CreateItem(todoItem);
            _todoListRepo.SaveChanges();

            var todoItemReadDto = _mapper.Map<TodoItemReadDto>(todoItem);

            return CreatedAtRoute(nameof(GetItem), new { id = todoItemReadDto.Id }, todoItemReadDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoItemReadDto>> GetAllItems()
        {
            var todoListItems = _todoListRepo.GetAllItems();

            if (todoListItems == null)
                return BadRequest();

            return Ok(_mapper.Map<IEnumerable<TodoItemReadDto>>(todoListItems));
        }

        [HttpGet("{id}", Name = "GetItem")]
        public ActionResult<TodoItemReadDto> GetItem(int id)
        {
            var todoItem = _todoListRepo.GetItem(id);

            if (todoItem != null)
            {
                return Ok(_mapper.Map<TodoItemReadDto>(todoItem));
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, TodoItemUpdateDto todoItemUpdateDto)
        {
            var todoItem = _todoListRepo.GetItem(id);

            if (todoItem == null)
                return NotFound();

            _mapper.Map(todoItemUpdateDto, todoItem);

            //In this case UpdateItem service is not implemented since automapper map the entity and save changes.
            //_todoListRepo.UpdateItem(todoItem);
            _todoListRepo.SaveChanges();

            return NoContent();           
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            var item = _todoListRepo.GetItem(id);

            if(item == null)
            {
                return NotFound();
            }
            _todoListRepo.DeleteItem(item);
            _todoListRepo.SaveChanges();

            return NotFound();
        }
    }
}
