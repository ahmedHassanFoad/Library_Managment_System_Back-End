using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_1.Entity
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsAvilable { get; set; }
        public int catagoryId { get; set; }
        public Catagory Catagory { get; set; }
        
    }
}
