using System.ComponentModel.DataAnnotations;

namespace BlazorEFCoreClean.Domain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int ProductId { get; set; }

        // Foreign key relationship
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
