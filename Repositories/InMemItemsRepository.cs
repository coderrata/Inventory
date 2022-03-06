using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Models;

namespace Inventory.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new() // This is a target-typed expression before we would write new List<Item>
        {
            new Item { ID = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedAt = System.DateTimeOffset.UtcNow },
            new Item { ID = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedAt = System.DateTimeOffset.UtcNow },
            new Item { ID = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedAt = System.DateTimeOffset.UtcNow }
        };
        public IEnumerable<Item> GetItems() // Returns a collection of items
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(item => item.ID == id).SingleOrDefault();
        }
        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.ID == item.ID);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.ID == id);
            items.RemoveAt(index);
        }
    }
}