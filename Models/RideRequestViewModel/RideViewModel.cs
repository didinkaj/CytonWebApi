using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CytonInterview.Models.RideRequestViewModel
{
    public class RideViewModel
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public int Capacity { get; set; }
        public decimal Amount { get; set; }
    }
}
