using System;

namespace Inventory.Models
{
     public record Item
    {   
        /*----------------------------------------------------
        //  Use init to allow for an initial value but not after,
        // Can use {get; private set;} although to be able to modify,
        // it takes much more code(usually by adding a constructor)
        
        // To modify this you would need  to do:
        // item item = new()
        {
            Id = Guid.New.Guid()
        }; */

        // the method when using set;
        /* 
        item.id = Guid.NewGuid(); 
        ----------------------------------------------------------------*/
        
        public Guid ID { get; init; } 
        public string Name {get;init;}
        public decimal Price {get;init;}
        public DateTimeOffset CreatedAt {get;init;}
        public DateTime UpdatedAt {get;set;}

    }
}