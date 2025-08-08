using Market.Contracts.Responses.Lots;

namespace Market.Contracts.Responses.Lots;

public class LotsResponse
{
    public required IEnumerable<LotResponse> Lots { get; init; }
}