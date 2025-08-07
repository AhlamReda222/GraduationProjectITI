using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectITI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category category { get; set; }


    }
}
