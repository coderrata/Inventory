using Inventory.DTOs;
using Inventory.Models;
namespace Inventory
{
    public static class Extensions{
        //  States that this Item is item of AsDTO from the class ItemDTO that returns its identity/version to the controller fundtion
        public static ItemDto AsDTO(this Item item)
        {
            return new ItemDto
            {
                ID = item.ID,
                ItemName = item.ItemName,
                ItemPrice = item.ItemPrice,
                CreatedDate = item.CreatedAt,
                UpdatedAt = item.UpdatedAt
            };
        }
    }
}