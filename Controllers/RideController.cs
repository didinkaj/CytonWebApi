using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
    [Route("api/Ride")]
    [Authorize(AuthenticationSchemes =
    JwtBearerDefaults.AuthenticationScheme)]
    public class RideController : Controller
    {
        // GET: api/Ride
        CytonDbContext _cytonDbContext;
        public RideController(CytonDbContext cytonDbContext)
        {
            _cytonDbContext = cytonDbContext;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(IEnumerable<Ride>), 200)]
        public async Task<IActionResult> Get()

       {
           var rides= this._cytonDbContext.Rides.Where(x=>x.StartTime.Date>DateTime.Now.Date).ToList();
            return new OkObjectResult(rides);
        }

        // GET: api/Ride/5
        //[HttpGet("{id}", Name = "Get")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    return Ok();
        //}

        // POST: api/Ride
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Ride newRide)
        {
           var riderId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
           newRide.RiderId = riderId;
           newRide.StartTime = newRide.StartTime.Date;
           await _cytonDbContext.Rides.AddAsync(newRide);
           await _cytonDbContext.SaveChangesAsync();
           return Ok();
        }
        
        // PUT: api/Ride/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]string value)
        {
            return Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
