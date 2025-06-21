using System;
using System.Collections.Generic;
namespace RailUFV

{
    public class Station
    {
        private List<Train> trains;
        private List<Platform> platforms;
        public void AddPlatform(string platformId)
        {
            Platform newPlatform = new Platform("Platform" + platformId);
            platforms.Add(newPlatform);
        }
        public void AddTrain(Train train)
        {
            trains.Add(train);
        }
        public Station(int nplatforms)
        {
            trains = new List<Train>();
            platforms = new List<Platform>();
            for (int i = 1; i <= nplatforms; i++)
            {
                AddPlatform("" + i);
            }
        }
        public void DisplayStatus()
        {
            Console.WriteLine("|----------------------------|");
            Console.WriteLine("|======== PLATFORMS =========|");
            Console.WriteLine("|----------------------------|");
            foreach (Platform platform in platforms)
            {
                Console.Write($"[{platform.GetId()}] - ");
                if (platform.GetStatus() == PlatformStatus.Free)
                {
                    Console.WriteLine("Free");
                }
                else
                {
                    Console.WriteLine($"Occupied by {platform.GetCurrentTrain().GetId()} ({platform.GetDockingTime()} ticks remaining)");
                }
            }
            Console.WriteLine("|----------------------------|");
            Console.WriteLine("|========== TRAINS ==========|");
            Console.WriteLine("|----------------------------|");
            foreach (Train train in trains)
            {
                Console.WriteLine($"{train.GetId()} | {train.GetStatus()} | Type: {train.GetType()}");
            }
        }
        public void AdvanceTick()
        {
            Console.WriteLine("|----------------------------|");
            Console.WriteLine("| ADVANCING SIMULATION TICK! |");
            Console.WriteLine("|----------------------------|");

            foreach (Platform platform in platforms)
            {
                platform.AdvanceTick();
            }
            foreach (Train train in trains)
            {
                if (train.GetStatus() == Train.TrainStatus.EnRoute) //This is for EnRoute state where we only reduce arrival time
                {
                    int newArrivalTime = train.GetArrivalTime() - 15;
                    if (newArrivalTime < 0)
                    {
                        newArrivalTime = 0;
                    }
                    else
                    {
                        train.SetArrivalTime(newArrivalTime);
                        bool flag = false;
                        foreach (Platform platform in platforms) //this serves if the train has arrived it doesn have to go trough Waiting if there are free platforms it will go directly to docking
                        {
                            if (newArrivalTime == 0 && platform.IsFree())
                            {
                                bool success = platform.RequestPlatform(train);
                                if (success)
                                {
                                    train.SetStatus(Train.TrainStatus.Docking);
                                    flag = true;
                                }
                            }
                        }
                        if (newArrivalTime == 0 && !flag)
                        {
                            train.SetStatus(Train.TrainStatus.Waiting);
                        }
                    }
                }
                else if (train.GetStatus() == Train.TrainStatus.Waiting) //When train is waiting for free platforms 
                {
                    bool flag = false;
                    foreach (Platform platform in platforms)
                    {
                        if (!flag && platform.IsFree())
                        {
                            bool success = platform.RequestPlatform(train);
                            if (success)
                            {
                                train.SetStatus(Train.TrainStatus.Docking);
                                flag = true;
                            }

                        }
                    }
                    if (!flag)
                    {
                        Console.WriteLine($"No platform available for train {train.GetId()}");
                    }
                }
                else if (train.GetStatus() == Train.TrainStatus.Docking) //when train is in process of docking
                {
                    bool stillLanding = false;
                    foreach (Platform platform in platforms)
                    {
                        if (platform.GetCurrentTrain() == train) //this wil only be false when the docking time has got to zero and the platform is released so our train wont be the current train in the platform
                        {
                            stillLanding = true;
                        }
                    }

                    if (!stillLanding)
                    {
                        train.SetStatus(Train.TrainStatus.Docked);
                        Console.WriteLine($"Train {train.GetId()} has landed successfully");
                    }
                }
            }
        }
        public bool AllTrainsDocked() //method made to know if every train is docked so the simulation can end.
        {
            foreach (Train train in trains)
            {
                if (train.GetStatus() != Train.TrainStatus.Docked)
                {
                     return false; 
                }
            }
            return true; 
        }
        public void LoadTrainsFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                try
                {
                    string id = parts[0];
                    int arrivalTime = int.Parse(parts[1]);
                    string type = parts[2].ToLower();

                    Train.TrainStatus status = Train.TrainStatus.EnRoute;

                    if (type == "passenger")
                    {
                        int numberOfCarriages = int.Parse(parts[3]);
                        int capacity = int.Parse(parts[4]);

                        PassengerTrain pt = new PassengerTrain(id, status, arrivalTime, "Passenger", numberOfCarriages, capacity);
                        trains.Add(pt);
                    }
                    else if (type == "freight")
                    {
                        int maxWeight = int.Parse(parts[3]);
                        string freightType = parts[4];

                        FreightTrain ft = new FreightTrain(id, status, arrivalTime, "Freight", maxWeight, freightType);
                        trains.Add(ft);
                    }
                    else
                    {
                        Console.WriteLine($"Unknown train type: {type}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error processing line: {line}");
                    Console.WriteLine($"Details: {e.Message}");
                }
            }

        }
    }
}