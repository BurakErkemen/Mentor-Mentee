# ToDoAPI uygulamasına Repository - Service Katmanlarının eklenmesi 
- <a href="https://www.youtube.com/watch?v=6vsONJla1Fk&ab_channel=TeddySmith">"Repository Layer" ile ilgili YouTube</a>
- <a href="https://www.youtube.com/watch?v=C0IH93yKLyA&ab_channel=SingletonSean">"Servis Layer" ile ilgili YouTube</a>

# Sorulacak Soru 
- Repository Katmanında neden StatuCode() döndürülemiyor.
- Repository Katmanındaki Put() işlemindeki kod hatasının sebebi nedir? Kod aşağıdaki gibi:
```csharp
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

// Tekrar Bak Controllerdan!!

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
```
