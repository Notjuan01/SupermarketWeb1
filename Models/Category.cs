using SupermarketWEB.Models;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Authorization;


namespace SupermarketWEB.Models
{
    [Authorize]
	public class Category
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string? Description { get; set; }
		public ICollection<product>? Products { get; set; } = default!;


	}
}