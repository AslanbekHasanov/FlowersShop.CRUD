
using FlowersShop.CRUD.Brokers.Storage;
using FlowersShop.CRUD.Models;

IStorageBroker storage = new ArrayStorageBroker();

storage.AddFlower(new Flower() { Id = 3, Name = "Gul", Color = "White", Cost = 15000, Discreption = "zur"});

Flower oneFlower = storage.ReadFlower(id: 2);
storage.Update(new Flower() { Name = "gul2", Color = "Purple", Cost = 10000, Discreption = "nothing"});

