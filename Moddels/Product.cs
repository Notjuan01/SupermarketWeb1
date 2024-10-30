using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketWeb.Moddels
{
    public class Product
    {
    public int Id { get; set; }

    public string Name { get; set; }

    [Column(TypeName = "decimal(6,2")]

    public decimal Price { get; set; }

    public int Stock {  get; set; }

    public int CategoriesId { get; set; }

    public Category Category {  get; set; } 
    }
}
