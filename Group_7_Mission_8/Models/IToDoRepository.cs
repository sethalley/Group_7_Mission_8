namespace Group_7_Mission_8.Models
{
    public interface IToDoRepository
    {
        List<ToDo> ToDos { get; }

        public void AddToDo(ToDo toDo);

        List<Category> Categories { get; }
        public void AddCategory(Category category);




    }
}
