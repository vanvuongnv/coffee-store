using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeShop.WebUI.Shared.Commands
{
	public class CategoryCommand
	{
        [Required]
        [StringLength(255)]
        public string CategoryName { get; set; } = default!;
    }
}

