using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Group_7_Mission_8.Models
{
    public class EFToDoRepository : IToDoRepository
    {
        private ToDosContext _context;

        

        public EFToDoRepository(ToDosContext temp)
        {
            _context = temp;
        }

        public List<ToDo> ToDos =>_context.ToDos.ToList();

       

        public void AddToDo(ToDo toDo)
        {
            _context.Add(toDo);
            _context.SaveChanges();
        }

        public List<Category> Categories => _context.Categories.ToList();
        public void AddCategories(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }


    }
    
    
}
