namespace Group_7_Mission_8.Models
{
    public interface IToDoRepository
    {
        List<ToDo> ToDos { get; }

        public void AddToDo(ToDo toDo);
        public void EditToDo(ToDo updateInfo);
        public void DeleteToDo(ToDo deleteInfo);

        List<Category> Categories { get; }
        public void AddCategory(Category category);




    }
}
