using FlowersShop.CRUD.Brokers.Logging;
using FlowersShop.CRUD.Brokers.Storage;
using FlowersShop.CRUD.Models;
using System.ComponentModel.DataAnnotations;

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

        public bool RemoveFlower(int id)
        {
            return id is 0
                    ? InvalidRemoveFlowerById()
                    : ValidationAndRemoveFlower(id);
        }

        private bool ValidationAndRemoveFlower(int id)
        {
            bool isDelete = this.storageBroker.Delete(id);

            if (isDelete is true)
            {
                this.loggingBroker.LogInformation("The information in the id has been deleted.");
                return true;
            }
            else
            {
                this.loggingBroker.LogError("Id is Not Found.");
                return false;
            }
        }

        private bool InvalidRemoveFlowerById()
        {
            this.loggingBroker.LogError("Invlid id.");
            return false;
        }
    }
}
