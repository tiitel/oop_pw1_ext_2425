using System;
namespace RailUFV
{
    public enum PlatformStatus
    {
        Free, Occupied
    }
    public class Platform
    {
        private string id;
        private PlatformStatus status;
        private Train currentTrain;
        private int dockingTime;

        public Platform(string id)
        {
            this.id = id;
            this.status = PlatformStatus.Free;
            this.currentTrain = null;
            this.dockingTime = 2;
        }

        public string GetId()
        {
            return id;
        }

        public PlatformStatus GetStatus()
        {
            return status;
        }

        public Train GetCurrentTrain()
        {
            return currentTrain;
        }

        public int GetDockingTime()
        {
            return dockingTime;
        }

        public bool RequestPlatform(Train train)
        {
            if (this.status == PlatformStatus.Free)
            {
                this.currentTrain = train;
                this.status = PlatformStatus.Occupied;
                return true;

            }
            return false;
        }
    
    }    
}