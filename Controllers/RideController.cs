using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CytonInterview.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CytonInterview.Controllers
{
    [Produces("application/json")]
    [Route("api/Ride")]
    public class RideController : Controller
    {
        // GET: api/Ride
       // CytonDbContext _cytonDbContext;
        public RideController(CytonDbContext cytonDbContext)
        {
           // _cytonDbContext = cytonDbContext;

        } 

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    return Ok();
        //}

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
           //await _cytonDbContext.Rides.AddAsync(newRide);
           //await _cytonDbContext.SaveChangesAsync();
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
