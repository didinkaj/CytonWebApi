using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CytonInterview.Controllers.Services;
using CytonInterview.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CytonInterview.Controllers
{
    //[Produces("application/json")]
    //[Route("api/Location")]
    //public class LocationController : Controller
    //{
    //    IRepository<Location> _repository;
    //    public LocationController(IRepository<Location> repository)
    //    {
    //        _repository = repository;
    //    }
    //    // GET: api/Location
    //    [HttpGet]
    //    public async Task<IActionResult> Get()
    //    {
    //       var locations= await _repository.GetAll();
    //        return new OkObjectResult(locations);
    //    }

    //    // GET: api/Location/5
    //    [HttpGet("{id}", Name = "Get")]
    //    public async Task<IActionResult> Get(Guid id)
    //    {
    //        var location = await _repository.GetById(id);
    //        return new OkObjectResult(location);
    //    }
        
    //    // POST: api/Location
    //    [HttpPost]
    //    public async Task<IActionResult> Post([FromBody]Location location)
    //    {
    //      var result=  await _repository.Add(location);
    //        return new OkObjectResult(result);
    //    }
        
    //    // PUT: api/Location/5
    //    [HttpPut("{id}")]
        
    //    public async Task<IActionResult> Put(Guid id, [FromBody]Location location)
    //    {
    //       var result= await _repository.Update(id, location);
    //       return new OkObjectResult(result);
    //    }
        
    //    // DELETE: api/ApiWithActions/5
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> Delete(Guid id)
    //    {
    //        var result = await _repository.Delete(id);
    //        return new OkObjectResult(result);
    //    }
    //}
}
