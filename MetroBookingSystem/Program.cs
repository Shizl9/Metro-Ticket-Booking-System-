using MetroBookingSystem.Data;
using MetroBookingSystem.Models;

namespace MetroBookingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // إنشاء object من DbContext
            AppDbContext context = new AppDbContext();

            //==========اضافة stations==========
            Station station1 = new Station { Name = "Makkah Station", Location= "King Abdulaziz Road, Makkah." };
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
        }
    }
}
