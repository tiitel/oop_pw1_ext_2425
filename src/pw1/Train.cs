using System;

namespace RailUFV
{
    public abstract class Train
    {
        protected string id;
        public enum TrainStatus
        {
            EnRoute, Waiting, Docking, Docked
        }
        protected TrainStatus status;
        protected int arrivalTime;
        protected string type;

        public Train(string id, TrainStatus status, int arrivalTime, string type)
        {
            this.id = id;
            this.status = status;
            this.arrivalTime = arrivalTime;
            this.type = type;
        }
        public string GetId()
        {
            return id;
        }
        public TrainStatus GetStatus()
        {
            return status;
        }
        public void SetStatus(TrainStatus status)
        {
            this.status = status;
        }
        public int GetArrivalTime()
        {
            return arrivalTime;
        }
        public void SetArrivalTime(int arrivalTime)
        {
            this.arrivalTime = arrivalTime;
        }
        public string GetType()
        {
            return type;
        }

    }
}