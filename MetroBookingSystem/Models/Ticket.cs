using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroBookingSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        //
        public string? PassengerName { get; set; }
        public decimal Price { get; set; }
        public DateTime TravelDate { get; set; }
        public Train? Train { get; set; }
        public Station? Station { get; set; }
    }
}
