using System;
using System.Collections.Generic;

namespace DealerShip.Models
{
    public partial class Vehicles
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public DateTime? Year { get; set; }
        public string Color { get; set; }
        public int? Price { get; set; }
        public bool? HasSunRoof { get; set; }
        public bool? IsFourWheelDrive { get; set; }
        public bool? HaslowMiles { get; set; }
        public bool? HasPowerWindows { get; set; }
        public bool? HasNavigation { get; set; }
        public bool? HasHeatedSeats { get; set; }
    }
}
