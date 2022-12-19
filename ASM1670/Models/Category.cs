using System.ComponentModel.DataAnnotations;
namespace ASM1670.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
