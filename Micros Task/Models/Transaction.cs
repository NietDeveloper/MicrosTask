using System.ComponentModel.DataAnnotations.Schema;

namespace Micros_Task.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public int Sum { get; set; }
        public string? Comment { get; set; }

        [NotMapped]
        public List<Category> Categories { get; set; } = new();

        [NotMapped]
        public Category Category { get; set; } = null!;
    }
}
