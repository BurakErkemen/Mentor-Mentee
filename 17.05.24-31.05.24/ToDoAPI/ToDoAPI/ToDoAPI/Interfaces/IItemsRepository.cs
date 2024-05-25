using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Model;

namespace ToDoAPI.Interfaces
{
    public interface IItemsRepository
    {
        Task<List<ToDoItemDTO>> GetAllAsync();
        Task<ActionResult<ToDoItemDTO>?> GetAsync(long id);
        Task<ActionResult<ToDoItemDTO>?> PostToDoItem(ToDoItemDTO toDoItemDTO);
        Task<ActionResult<ToDoItemDTO>?> DeleteToDoItem(long id);
        Task<ActionResult<ToDoItemDTO>?> PutToDoItem(long id, ToDoItemDTO toDoItemDTO);
    }
}
