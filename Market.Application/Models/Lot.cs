namespace Market.Application.Models;

public class Lot
{
    public Guid Id { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required Guid CreatorId { get; init; }
    public required IEnumerable<int> TagsIds { get; set; } = [];
    public required DateTime CreationDate { get; init; }
}