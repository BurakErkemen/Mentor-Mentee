using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using ToDoAPI.Interfaces;
using ToDoAPI.Model;


namespace ToDoAPI.Repository
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly ToDoContext _context;
        public ItemsRepository(ToDoContext context)
        {
            _context = context;
        }


        private static ToDoItemDTO ItemToDoDTO(ToDoItem item) =>
            new ToDoItemDTO
            {
                Name = item.Name,
                IsComplete = item.IsComplete,
            };



        // Database İşlemler

        // GET işlemlerş
        public async Task<List<ToDoItemDTO>> GetAllAsync() // GET - Tüm Veriler
        {
            var todoItems = await _context.ToDoItems.ToListAsync();
            return todoItems.Select(item => ItemToDoDTO(item)).ToList();
        }


        public async Task<ActionResult<ToDoItemDTO>?> GetAsync(long id) // GET - Seçili Veri
        {
            var todoItem = await _context.ToDoItems.FindAsync(id);
            if (todoItem == null)
            {
                return null;
            }

            return ItemToDoDTO(todoItem);
        }


        public async Task<ActionResult<ToDoItemDTO>?> PostToDoItem(ToDoItemDTO toDoItemDTO)
        {
            var todoıtem = new ToDoItem
            {
                Name = toDoItemDTO.Name,
                IsComplete = toDoItemDTO.IsComplete
            };
            _context.Add(todoıtem);
            await _context.SaveChangesAsync();
            return ItemToDoDTO(todoıtem);
        }


        public async Task<ActionResult<ToDoItemDTO>?> DeleteToDoItem(long id)
        {
            var item = await _context.ToDoItems.FindAsync(id);
            if (item == null)
            {
                return null;
            }

            _context.Remove(item);
            await _context.SaveChangesAsync();

            // Silinen ToDoItem'ı ToDoItemDTO olarak dönüştürerek geri döndürün.
            return ItemToDoDTO(item);
        }

        public async Task<ActionResult<ToDoItemDTO>?> PutToDoItem(long id, 
            ToDoItemDTO toDoItemDTO)
        {
            /*
            var item = await _context.ToDoItems.FindAsync();
            if (item == null) { return null; }
            var Todoıtem = new ToDoItem()
            {
                Id = item.Id
                Name = toDoItemDTO.Name,
                IsComplete = toDoItemDTO.IsComplete
            };
            await _context.Update(toDoItemDTO);
            _context.SaveChangesAsync();
            return ItemToDoDTO(toDoItemDTO);*/

            //Tekrar Bak Controllerdan!!

            var todoID = await _context.ToDoItems.FindAsync(id); 
            if (todoID == null) { return null; }
            todoID.Name = toDoItemDTO.Name;
            todoID.IsComplete = toDoItemDTO.IsComplete;
            _context.SaveChanges();
            _context.Entry(todoID).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred.", ex);
            }
            return ItemToDoDTO(todoID);
        }
    }
}
