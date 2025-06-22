using System;
namespace RailUFV
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many platforms do you want to have in the station?");
            int np = int.Parse(Console.ReadLine());
            Station station = new Station(np);
            bool exit = false;
             while (!exit)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Load trains from file");
                Console.WriteLine("2. Start simulation");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter the CSV filename  (trains.csv): ");
                        string filename = Console.ReadLine();
                        station.LoadTrainsFromFile(filename);
                        break;

                    case "2":
                        Console.WriteLine("\nStarting simulation...");
                        while (!station.AllTrainsDocked())
                        {
                            station.DisplayStatus();
                            station.AdvanceTick();
                            Console.WriteLine("\nPress ENTER to continue...");
                            Console.ReadLine();
                        }
                        Console.WriteLine("\nAll trains have docked. Simulation complete.");
                        break;

                    case "3":
                        exit = true;
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}