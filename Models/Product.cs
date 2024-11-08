
using Microsoft.AspNetCore.Authorization;
using SupermarketWEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketWEB.Models;

public class product
{

	public int Id { get; set; }

	public string Name { get; set; }

	[Column(TypeName = "decimal(6,2)")]

	public decimal Price { get; set; }

	public int Stock { get; set; }

	public int CategoryId { get; set; }

	public Category? Category { get; set; }

}