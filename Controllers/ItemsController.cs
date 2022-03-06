using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Inventory.Models;
using Inventory.Repositories;

namespace Inventory.Controllers
{
    [ApiController] // This bring in a whole bunch of API default behaviors\
    [Route("items")] // Just putting controller sets the current controller, otherwise you would specify the route just like any other. i.e. [Route("API/home")]
    public class ItemsController : ControllerBase
    {
        // Using private because it will not be modified after creation
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }
        // get Items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            // This receives the model from Extensions and adds the function call to it to retrieve what we want
            var items = repository.GetItems().Select( item => item.AsDTO());
            
            return items;
        }
        
        
        //  Routes to /items/{id}
        [HttpGet("{id}")]
        // Using ActionResult allows us to return more than one type
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            
            if(item is null)
            {
                return NotFound();
            }
            // Returns the AsDTO function/method
            return item.AsDTO();
        }
        // Post /items
        [HttpPost]
        // Determine if you need a response object or just the DTO after ActionResult
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                ID = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedAt = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.ID}, item.AsDTO());
        }
        // Put /items/
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);
            if ( existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with 
            { 
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repository.UpdateItem(updatedItem);

            return NoContent();
        }
        //  at items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            repository.DeleteItem(id);

            return NoContent();
        }
    }
}