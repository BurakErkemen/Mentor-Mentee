using ToDoAPI.Model;

namespace ToDoAPI.Interfaces
{
    public interface IItemsService
    {
        Task<IEnumerable<ToDoItemDTO>> GettAllAsyncService();
        Task<ToDoItemDTO>? GetToDoItemAsyncService(long id);
        Task<ToDoItemDTO>? PostToDoItemAsyncService(ToDoItemDTO toDoItemDTO);
        Task<ToDoItemDTO>? PutToDoItemAsyncService(long id, ToDoItemDTO toDoItemDTO);
        Task<ToDoItemDTO>? DeleteToDoItemAsyncService(long id);
    }
}
