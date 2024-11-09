namespace LMS_1.Entity
{
    public class Catagory
    {
        public int Id { get; set; }
        public string Name { get; set; }
       public ICollection<Book> Books { get; set; }
    }
}
