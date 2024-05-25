using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using ToDoAPI.Interfaces;
using ToDoAPI.Model;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ToDoContext _context;
        private readonly IItemsRepository _ıtemrepo;
        private readonly IItemsService _ıtemservice;
        public ToDoItemsController(ToDoContext context, IItemsRepository ıtemsRepository, IItemsService ıtemservice)
        {
            _context = context; // Repo katmanı ile gerek kalmadı
            _ıtemrepo = ıtemsRepository; // Servis katmanı ile gerek kalmadı
            _ıtemservice = ıtemservice; 
        }

        private static ToDoItemDTO ItemToDoDTO(ToDoItem item) =>
            new ToDoItemDTO //Repository Katmanından sonra bu işleme gerek kalmadı.
            {
                Name = item.Name,
                IsComplete = item.IsComplete,
            };

        // Task asnc işlemi temsil eder ve veri döndüreceğini ifade eder.
        // Task'tan sonra gelen ifadeler döndürülecek değerin türünü şfade eder 
        // ActionResult HTTP isteğini belirtir.
        // IEnumerable Koleksiyonların sıralı bir şekilde alınması için kullanılır.
        [HttpGet]// GET: api/TodoItems
        public async Task<ActionResult<IEnumerable<ToDoItemDTO>>> GetToDoItems()
        {
            // Context nesnesine gidip bütün bütün verileri seç ve DTO olarak async olarak göster. 
            //return await _context.ToDoItems.Select(i => ItemToDoDTO(i)).ToListAsync();
            // Repository Layer ile tekrar düzenlendi
            // return await _ıtemrepo.GetAllAsync();

            //Service Layerdan sonra Son durum!!
            var item = await _ıtemservice.GettAllAsyncService();
            return Ok(item);
        }


        [HttpGet("{id}")]// GET: api/TodoItems/{id}
        public async Task<ActionResult<ToDoItemDTO>> GetToDoItem(long id)
        {
            //Before Repository Layer
            /*var ToDoItem = await _context.ToDoItems.FindAsync(id);
            if (ToDoItem == null)
            {
            return NotFound();
            }
            return ItemToDoDTO(ToDoItem);*/

            //After Repository Layer
            // Olası Null Başvurusu Uyarısı!!
            /*var ToDoItem = await _ıtemrepo.GetAsync(id);
            if (ToDoItem ==null)
            {
                return NotFound();
            }
            return ToDoItem; // Repository Layer içerisinde return olarak DTO dönüşümü yapılmakta!
            */
            // After Service Layer
            var item = await _ıtemservice.GetToDoItemAsyncService(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;

        }


        [HttpPost]
        public async Task<ActionResult<ToDoItemDTO>> PostToDoItem(ToDoItemDTO toDoItemDTO)
        {
            // Before Repository Layer
            /*var todoItem = new ToDoItem()
            {
                Name = toDoItemDTO.Name,
                IsComplete = toDoItemDTO.IsComplete
            };
            _context.ToDoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetToDoItem),
                new { id = todoItem.Id },
                ItemToDoDTO(todoItem));*/

            //After Repository Layer
            /*await _ıtemrepo.PostToDoItem(toDoItemDTO);
            return StatusCode(200);
            */
            // After Service Layer
            await _ıtemservice.PostToDoItemAsyncService(toDoItemDTO);
            return StatusCode(200);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ToDoItem>> PutToDoItem(long id, ToDoItemDTO toDoItemDTO)
        {
            /*
            var todoID = await _ıtemrepo.PutToDoItem(id,toDoItemDTO);
            if (todoID == null)
            {
                return NotFound();
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)// Database Güncelleme Eşzamanlılığı İstisnası
            {
                return StatusCode(500);
            }
            return NoContent();
            */

            // After Service Layer
            var item = await _ıtemservice.PutToDoItemAsyncService(id, toDoItemDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDoItem>> DeleteToDoItem(long id)
        {
            /*
            var item = await _ıtemrepo.DeleteToDoItem(id);
            if (item == null)
            {
                return NotFound();
            }
            try
            {

            }
            catch (DbUpdateException) // Database Güncelleme Hatası
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "An error occurred while deleting the item.");
            }
            return NoContent();
            */

            // After Service Layer
            var item = await _ıtemservice.DeleteToDoItemAsyncService(id);
            return NoContent();
        }
    }
}
