using System;
using Inventory.Models;
using System.Collections.Generic;

namespace Inventory.Repositories
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        // This CreateItem it just receives the item that needs to be created and puts it in the respository
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}