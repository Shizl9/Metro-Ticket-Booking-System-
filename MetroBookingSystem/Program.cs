using MetroBookingSystem.Data;
using MetroBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MetroBookingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // إنشاء object من DbContextt:
            AppDbContext context = new AppDbContext();

            //==========اضافة stations==========
            Station station1 = new Station { Name = "Makkah Station", Location = "King Abdulaziz Road, Makkah." };
            Station station2 = new Station { Name = "Jeddah Central Station", Location = " Haramain Expressway, Jeddah." };
            Station station3 = new Station { Name = "KAEC Station", Location = "King Abdullah Economic City, Rabigh." };
            // إضافة المحطات إلى DB
            context.Stations.Add(station1);
            context.Stations.Add(station2);
            context.Stations.Add(station3);

            //==========اضافة trains==========
            Train train1 = new Train { Number = "HHR-035", Capacity = 417 };
            Train train2 = new Train { Number = "NT-006", Capacity = 444 };
            Train train3 = new Train { Number = "ET-008", Capacity = 280 };
            // إضافة القطارات إلى DB
            context.Trains.Add(train1);
            context.Trains.Add(train2);
            context.Trains.Add(train3);
            // حفظ التغييرات في DB
            context.SaveChanges();

            Console.WriteLine("Stations and Trains Added!");

            //==========اضافة Tickets==========
            Ticket ticket1 = new Ticket { PassengerName = "Ahmed Al-Farsi", Price = 25,
                TravelDate = DateTime.Now, TrainId = train1.Id, StationId = station1.Id };
            Ticket ticket2 = new Ticket { PassengerName = "Sara Al-Harbi", Price = 30,
                TravelDate = new DateTime(2026,6,12), TrainId = train2.Id, StationId = station2.Id };
            Ticket ticket3 = new Ticket { PassengerName = "Omar Al-Mutairi", Price = 20,
                TravelDate = new DateTime(2026,7,5), TrainId = train3.Id, StationId = station3.Id };

            context.Tickets.Add(ticket1);
            context.Tickets.Add(ticket2);
            context.Tickets.Add(ticket3);
            context.SaveChanges();

            Console.WriteLine("Tickets Added!");

            //include to load related data
            var tickets = context.Tickets.Include(t => t.Train).Include(t => t.Station).ToList();

            foreach (var t in tickets)
            {
                // عرض بيانات التذكرة مع العلاقات
                Console.WriteLine($"Passenger: {t.PassengerName}");
                Console.WriteLine($"Train: {t.Train?.Number}");
                Console.WriteLine($"Station: {t.Station?.Name}");
                Console.WriteLine($"Price: {t.Price}");

            }

            //tickets price >20
            var expensiveTickets = context.Tickets.Where(t => t.Price > 20).ToList();

            foreach (var t in expensiveTickets)
            {
                Console.WriteLine($"{t.PassengerName} - {t.Price}");
            }
            //first ticket fo specific passenger
            var specificTicket = context.Tickets.FirstOrDefault(t => t.PassengerName == "Sara Al-Harbi");
            Console.WriteLine(specificTicket?.PassengerName);
            //number of all tickets
            var totalTickets = context.Tickets.Count();
            Console.WriteLine($"Total Tickets: {totalTickets}");

            //order tickets by price descending
            var ordered = context.Tickets.OrderByDescending(t => t.Price).ToList();

            foreach (var t in ordered)
            {
                Console.WriteLine($"{t.PassengerName} - {t.Price}");
            }

        }
    }
}
