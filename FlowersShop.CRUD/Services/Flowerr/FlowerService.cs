using FlowersShop.CRUD.Brokers.Logging;
using FlowersShop.CRUD.Brokers.Storage;
using FlowersShop.CRUD.Models;

namespace FlowersShop.CRUD.Services.Flowerr
{
    internal class FlowerService : IFlowerService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public FlowerService()
        {
            this.storageBroker = new ArrayStorageBroker();
            this.loggingBroker = new LoggingBroker();
        }

        public Flower CreateFlower(Flower flower) => 
            this.storageBroker.AddFlower(flower);

        public Flower GetFlower(int id) =>
            this.storageBroker.ReadFlower(id);

        public Flower ModifyFlower(Flower flower)=>
            this.storageBroker.Update(flower);

        public Flower[] ReadAllFlowers()=>
            this.storageBroker.GetAllFlowers();

        public bool RemoveFlower(int id)=>
            this.storageBroker.Delete(id);
    }
}
