using System.Globalization;
using GeekShopping.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Model
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        
        [Column("price")]
        [Required]
        [Range(1,10000)]
        public decimal Price { get; set; }

        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Column("category_name")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Column("image_url")]
        [StringLength(300)]
        public string ImageUrl { get; set; }

        public Product(string name, decimal price, string description, string category_name, string image_url)
        {
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.CategoryName = category_name;
            this.ImageUrl = image_url;
        }
    }
}
