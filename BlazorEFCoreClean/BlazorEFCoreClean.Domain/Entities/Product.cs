using System.ComponentModel.DataAnnotations;

namespace BlazorEFCoreClean.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Navigation properties
        public Order Order { get; set; }
    }
}
