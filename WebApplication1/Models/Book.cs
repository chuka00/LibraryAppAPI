using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

    }
}
