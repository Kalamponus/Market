using Market.API.ContractsMapping;
using Market.Application.Models;
using Market.Contracts.Requests;
using Market.Contracts.Responses.Lots;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers;

[ApiController]
public class LotsController : ControllerBase
{
    [HttpPost(ApiEndpoints.Lots.Create)]
    public async Task<IActionResult> Create([FromBody]CreateLotRequest request)
    {
        Lot lot = request.MapToLot();
        
        LotResponse response = lot.MapToResponse();
        
        return CreatedAtAction(nameof(Get), new { id  = lot.Id }, response); 
    }
    
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        Lot lot = new()
        {
            Id = Guid.Parse(id),
            Description = string.Empty,
            CreatorId = Guid.NewGuid(),
            CreationDate = DateTime.Now,
            Price = 0,
            Title = string.Empty,
            TagsIds = []
        };
        
        if (lot is null)
            return NotFound();
        
        LotResponse response = lot.MapToResponse();
        
        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.Lots.Get)]
    public async Task<IActionResult> GetAll()
    {
        Lot[] lots = [];
        
        LotsResponse response = lots.MapToResponse();
        
        return Ok(response);
    }

    public async Task<IActionResult> Update(string id)
    {
        Lot lot = new()
        {
            Id = Guid.Parse(id),
            Description = string.Empty,
            CreatorId = Guid.NewGuid(),
            CreationDate = DateTime.Now,
            Price = 0,
            Title = string.Empty,
            TagsIds = []
        };
        
        LotResponse response = lot.MapToResponse();

        return Ok(response);
    }
    
    public async Task<IActionResult> Delete(string id)
    {
        Lot lot = new()
        {
            Id = Guid.Parse(id),
            Description = string.Empty,
            CreatorId = Guid.NewGuid(),
            CreationDate = DateTime.Now,
            Price = 0,
            Title = string.Empty,
            TagsIds = []
        };
        
        LotResponse response = lot.MapToResponse();
        
        return Ok(response);
    }
}