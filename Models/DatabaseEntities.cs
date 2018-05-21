using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CytonInterview.Models
{
    public class Ride
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RideId { get; set; }
        public string RiderId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime StartTime { get; set; }
        public int Capacity { get; set; }
        public Decimal Amount{ get; set; }
    }

    public class BookedRide {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RideRequestId { get; set; }
        public string UserId { get; set; }        
        public int Space { get; set; }
        public DateTime RequestTime { get; set; }       
        public bool IsCancelled { get; set; }
    }
    public class Car {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Capacity { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public String RegNo { get; set; }
        public string Manafacturer { get; set; }
    }
}

