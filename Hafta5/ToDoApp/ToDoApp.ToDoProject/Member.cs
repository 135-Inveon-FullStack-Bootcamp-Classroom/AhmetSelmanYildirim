namespace ToDoApp.ToDoProject
{
    public class Member : Human
    {
        public Member(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
    }
}
