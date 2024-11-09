namespace LMS_1.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int catagoryId { get; set; }
        public bool IsAvilable { get; set; }

    }
}
