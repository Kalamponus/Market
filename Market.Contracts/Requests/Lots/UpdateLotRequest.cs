namespace Market.Contracts.Requests;

public class UpdateLotRequest
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required decimal Price { get; init; }
    public required Guid CreatorId { get; init; }
    public required IEnumerable<int> TagsIds { get; init; } = [];
    public required DateTime CreationDate { get; init; }
}