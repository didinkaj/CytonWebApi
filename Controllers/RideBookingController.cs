using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CytonInterview.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CytonInterview.Controllers
{
    [Produces("application/json")]
    [Route("api/RideBooking")]
    [Authorize(AuthenticationSchemes =
    JwtBearerDefaults.AuthenticationScheme)]
    public class RideBookingController : Controller
    {
        CytonDbContext _dbContext;
        public RideBookingController(CytonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/RideBooking
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

       // GET: api/RideBooking/5
        [HttpGet("bookedRide", Name = "GetUpcomingTrips")]
        public async Task<IActionResult> Get([FromRoute] String userId)
        {
             userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value?.ToString()??userId;
            var usertrips = (from rides in _dbContext.Rides join bookedrides in _dbContext.BookedRides on rides.RideId equals bookedrides.RideId where bookedrides.UserId == userId  && rides.StartTime>DateTime.Now select new {
                RideId=rides.RideId,
                Space= bookedrides.Space,
                BookingDate=bookedrides.RequestTime,
                Origin=rides.Origin,
                Capacity= rides.Capacity,
                Destination = rides.Destination,
                StartDate=rides.StartTime,
            }).ToList();
            return new OkObjectResult(usertrips);
        }

        [HttpGet("pastRides", Name = "GetpastRidesTrips")]
        public async Task<IActionResult> GetPastRides([FromRoute] String userId)
        {
            userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value?.ToString() ?? userId;
            var usertrips = (from rides in _dbContext.Rides
                             join bookedrides in _dbContext.BookedRides on rides.RideId equals bookedrides.RideId
                             where bookedrides.UserId == userId && rides.StartTime < DateTime.Now
                             select new
                             {
                                 RideId = rides.RideId,
                                 Space = bookedrides.Space,
                                 BookingDate = bookedrides.RequestTime,
                                 Origin = rides.Origin,
                                 Capacity = rides.Capacity,
                                 Destination = rides.Destination,
                                 StartDate = rides.StartTime,
                             }).ToList();
            return new OkObjectResult(usertrips);
        }
        // POST: api/RideBooking
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BookedRide newBookedRide)
        {
            try {
                var riderId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                newBookedRide.UserId = riderId;
                this._dbContext.BookedRides.Add(newBookedRide);
                this._dbContext.SaveChanges();
                return new OkObjectResult("ride successfully booked");

            } catch (Exception ex) {
                return new  BadRequestObjectResult("server error");
            }
            
        }
        
        // PUT: api/RideBooking/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
