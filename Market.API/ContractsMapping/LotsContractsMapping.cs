using Market.Application.Models;
using Market.Contracts.Requests;
using Market.Contracts.Responses.Lots;

namespace Market.API.ContractsMapping;

public static class LotsContractsMapping
{
    public static Lot MapToLot(this CreateLotRequest request)
    {
        return new Lot
        {
            Id = Guid.NewGuid(),
            CreatorId = request.CreatorId,
            CreationDate = DateTime.Now,
            Title = request.Title,
            Description = request.Description,
            Price = request.Price,
            TagsIds = request.TagsIds
        };
    }
    
    public static Lot MapToLot(this UpdateLotRequest request, Guid id)
    {
        return new Lot
        {
            Id = id,
            Title = request.Title,
            Description = request.Description,
            Price = request.Price,
            TagsIds = request.TagsIds,
            CreationDate = request.CreationDate,
            CreatorId = request.CreatorId
        };
    }

    public static LotResponse MapToResponse(this Lot lot)
    {
        return new LotResponse
        {
            Id = lot.Id,
            CreatorId = lot.CreatorId,
            CreationDate = lot.CreationDate,
            Title = lot.Title,
            Description = lot.Description,
            Price = lot.Price,
            TagsIds = lot.TagsIds
        };
    }

    public static LotsResponse MapToResponse(this IEnumerable<Lot> lots)
    {
        return new LotsResponse
        {
            Lots = lots.Select(MapToResponse)
        };
    }
}