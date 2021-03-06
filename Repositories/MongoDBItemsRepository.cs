using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Inventory.Models;

namespace Inventory.Repositories
{
    public class MongoDBItemsRepository : IItemsRepository
    {   
        
        private const string databaseName = "InventoryMongo";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemsCollection;
        public MongoDBItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Item>(collectionName);
        }
        
        public void CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);
        }
        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }
        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }
        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
 
    }   
}