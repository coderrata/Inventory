using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory.DTOs
{
    public record CreateItemDto
    {
        // we only include the two that will change or are not auto-generated, i.e. Guid or CreatedAt date
        [Required]
        public string Name {get;init;} 
        [Required]
        [Range(1, 10000)]
        public decimal Price {get;init;}
    }
}