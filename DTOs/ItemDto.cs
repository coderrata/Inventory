using System;


// This DTO is used to modify the DB without breaking the contract
// Set up next in the controller
namespace Inventory.DTOs
{
    public record ItemDto
    {   

        public Guid ID { get; init; } 
        public string ItemName {get;init;}
        public decimal ItemPrice {get;init;}
        public DateTimeOffset CreatedDate {get;init;}
        public DateTime UpdatedAt {get;set;}

    }    
}