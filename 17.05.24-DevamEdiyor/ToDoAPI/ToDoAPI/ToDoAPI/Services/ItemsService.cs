using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Interfaces;
using ToDoAPI.Model;

namespace ToDoAPI.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsRepository _itemsRepository;
        public ItemsService(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        public async Task<IEnumerable<ToDoItemDTO>> GettAllAsyncService()
        {
            return await _itemsRepository.GetAllAsync();
        }

        public async Task<ToDoItemDTO>? GetToDoItemAsyncService(long id)
        {
            var ıtem = await _itemsRepository.GetAsync(id);
            if (ıtem == null)
            {
                return null;
            }

            return ıtem.Value;
        }

        public async Task<ToDoItemDTO> PostToDoItemAsyncService(ToDoItemDTO toDoItemDTO)
        {
            var item =await _itemsRepository.PostToDoItem(toDoItemDTO);
            return item.Value;
        }

        public async Task<ToDoItemDTO> PutToDoItemAsyncService(long id, ToDoItemDTO toDoItemDTO)
        {
            var item = await _itemsRepository.PutToDoItem(id, toDoItemDTO);
            return item.Value;

        }
        public async Task<ToDoItemDTO> DeleteToDoItemAsyncService(long id)
        {
            var item = await _itemsRepository.DeleteToDoItem(id);
            return item.Value;
        }
    }
}
