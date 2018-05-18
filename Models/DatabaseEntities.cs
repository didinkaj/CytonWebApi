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
        //from users
        public string RiderId { get; set; }
        //from driver
        public Guid DriverId { get; set; }
        public DateTime MyProperty { get; set; }
        
        public string Origin { get; set; }
        public string  Destination { get; set; }
        public DateTime StartTime { get; set; }
        public int Occupants { get; set; }
        public DateTime EndTime { get; set; }
        public Decimal AmmountPaid { get; set; }
    }

    public class Driver {
        [Key]
        public Guid UserId { get; set; }
        public int VehicleCapacity { get; set; }
        public bool IsOccupied { get; set; }
        public float CurrentLongitude { get; set; }
        public float CurrentLatitude { get; set; }

    } 

    public class RideRequest {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RideRequestId { get; set; }
        public string UserId { get; set; }
        //this will
        public string PickUpLocation { get; set; }
        public DateTime RequestTime { get; set; }
        public Guid FullFilledBy { get; set; }
        public bool IsCancelled { get; set; }
    }

  

    public class Car {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string  Capacity { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public String RegNo { get; set; }
        public string Manafacturer { get; set; }
    }
}

