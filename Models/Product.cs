namespace ProductShop.Models;

using System.ComponentModel.DataAnnotations;

public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(256)]
    public string Description { get; set; } = null!;

    [Required]
    [Range(0, 9999)]
    public uint Price { get; set; } = 1;

    [Required]
    public Category? Category { get; set; } = null!;

    public bool IsGlutenFree { get; set; } = false;

    [Required]
    [Url]
    public string Picture { get; set; } = "https://www.towleroad.com/wp-content/uploads/2021/02/astley-1024x736.jpeg";
    
    public Dictionary<string, string> Additional { get; } = new Dictionary<string, string>();
}