namespace LMS_1.Entity
{
    public class BookIssuer
    {
        public int BookId {  get; set; }
        public int EventId { get; set; }
        public string Status { get; set; }
        public Book Book { get; set; }
        public Event Event { get; set; }
    }
}
