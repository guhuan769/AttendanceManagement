using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AttendanceRESTful.Models;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using AttendanceRESTful.Interface.Realization;

namespace AttendanceRESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;
        private IDistributedCache Cache;

        public TodoItemsController(IDistributedCache cache)
        {
            Cache = cache;
            //RedisCacheManager redisCacheManager = new RedisCacheManager();
        }

        [Route("TestCount")]
        [HttpGet]
        public int TestCount(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Cache.SetAsync("test" + i, Encoding.UTF8.GetBytes(DateTime.Now.ToString()));
                var a = Cache.GetStringAsync("test" + i).Result;
            }
            return count;
        }

        //// GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    string currentTime = Cache.GetStringAsync("test").Result;
        //    if (null == currentTime)
        //    {
        //        currentTime = "va1" + DateTime.Now;
        //        Cache.SetAsync("test", Encoding.UTF8.GetBytes(currentTime));
        //    }
        //    return new string[] { currentTime, "value2" };
        //}

       // GET: api/TodoItems
       [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
            //string currentTime = Cache.GetStringAsync("test").Result;
            //if (null == currentTime)
            //{
            //    currentTime = "va1" + DateTime.Now;
            //    await Cache.SetAsync("test", Encoding.UTF8.GetBytes(currentTime));
            //}
            //return new string[] { currentTime, "value2" };
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetTodoItem),new { 
                id = todoItem.Id 
            },todoItem);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }

        private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
