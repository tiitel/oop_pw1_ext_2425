using System;
namespace RailUFV
{
    public class PassengerTrain : Train
    {
        private int numberOfCarriages;
        private int capacity;
        public PassengerTrain(string id, TrainStatus status, int arrivalTime, string type, int numberOfCarriages, int capacity) : base(id, status, arrivalTime, "Passenger")
        {
            this.numberOfCarriages = numberOfCarriages;
            this.capacity = capacity;
        }
        public int GetnumberOfCarriages()
        {
            return this.numberOfCarriages;
        }
        public int GetCapacity()
        {
            return this.capacity;
        }
    }
}