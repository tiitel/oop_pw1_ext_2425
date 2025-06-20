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
            this.dockingTime = 0;
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

        public bool IsFree() 
        {
            return this.status == PlatformStatus.Free;
        }

        public bool RequestPlatform(Train train)
        {
            if (this.status == PlatformStatus.Free)
            {
                this.currentTrain = train;
                this.status = PlatformStatus.Occupied;
                this.dockingTime = 2;
                return true;

            }
            return false;
        }
        public void AdvanceTick()
        {
            if(this.status == PlatformStatus.Occupied && dockingTime > 0)
            {
                this.dockingTime --;
                if(this.dockingTime == 0)
                {
                    ReleaseRunway();
                }
            }
        }
        public void ReleaseRunway()
        {
            this.currentTrain = null;
            this.status = PlatformStatus.Free;
            this.dockingTime  = 0;
        }
    
    }    
}