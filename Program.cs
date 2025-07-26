using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Lab2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<(string EventName, DateTime EventDate)> events = new List<(string, DateTime)>();

                Console.WriteLine("=== Calendar Event Organizer ===");
                Console.WriteLine("Enter 5 events with their dates (MM/DD/YYYY):");

                int count = 0;
                while (count < 5)
                {
                    Console.Write($"\nEnter name of event #{count + 1}: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter date of the event (MM/DD/YYYY): ");
                    string dateInput = Console.ReadLine();

                    if (DateTime.TryParseExact(dateInput, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime eventDate))
                    {
                        if (events.Any(e => e.EventDate == eventDate))
                        {
                            Console.WriteLine("Error: An event is already scheduled on this date. Please choose another date.");
                        }
                        else
                        {
                            events.Add((name, eventDate));
                            count++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please enter the date in MM/DD/YYYY format.");
                    }
                }

                var sortedEvents = events.OrderBy(e => e.EventDate).ToList();

                Console.WriteLine("\n=== Sorted Events ===");
                foreach (var ev in sortedEvents)
                {
                    Console.WriteLine($"{ev.EventDate.ToString("MM/dd/yyyy")} - {ev.EventName}");
                }
            
        }
    }

}


