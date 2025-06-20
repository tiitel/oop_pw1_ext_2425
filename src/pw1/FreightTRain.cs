using System;

namespace RailUFV
{
    public class FreightTrain : Train
    {
        private int maxWeight;
        private string freightType;

        public FreightTrain(string id, TrainStatus status, int arrivalTime, string type, int maxWeight, string freightType)
            : base(id, status, arrivalTime, "Freight")
        {
            this.maxWeight = maxWeight;
            this.freightType = freightType;
        }

        public int GetMaxWeight()
        {
            return this.maxWeight;
        }

        public string GetFreightType()
        {
            return this.freightType;
        }
    }
}