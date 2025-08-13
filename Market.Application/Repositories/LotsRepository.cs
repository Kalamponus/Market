using Market.Application.Database;
using Market.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Repositories;

public class LotsRepository : ILotsRepository
{
    private readonly MarketContext _context;

    public LotsRepository(MarketContext context)
    {
        _context = context;
    }

    public async Task<int> CreateLotAsync(Lot lot)
    {
        _context.Lots.Add(lot);
        int changesCount = await _context.SaveChangesAsync();
        return changesCount;
    }

    public async Task<Lot?> GetLotAsync(Guid id)
    {
        Lot? lot = await _context.Lots.FindAsync(id);
        return lot;
    }

    public async Task<IEnumerable<Lot?>> GetLotsAsync(IEnumerable<Guid> ids)
    {
        IEnumerable<Lot?> lots = await _context.Lots.Where(lot => ids.Contains(lot.Id)).ToListAsync();
        return lots;
    }

    public async Task<int> UpdateLotAsync(Lot lot)
    {
        _context.Lots.Update(lot);
        int changesCount = await _context.SaveChangesAsync();
        return changesCount;
    }

    public async Task<int> DeleteLotAsync(Lot lot)
    {
        _context.Lots.Remove(lot);
        int changesCount = await _context.SaveChangesAsync();
        return changesCount;
    }

    public async Task<int> DeleteLotAsync(Guid id)
    {
        Lot? lot = await GetLotAsync(id);

        if (lot is null)
            return 0;

        _context.Lots.Remove(lot);
        int changesCount = await _context.SaveChangesAsync();
        
        return changesCount;
    }

    public async Task<int> DeleteLotsAsync(IEnumerable<Lot> lots)
    {
        _context.Lots.RemoveRange(lots);
        int changesCount = await _context.SaveChangesAsync();
        return changesCount;
    }

    public async Task<int> DeleteLotsAsync(IEnumerable<Guid> ids)
    {
        IEnumerable<Lot?> lots = await GetLotsAsync(ids);
        
        if (lots is null)
            return 0;

        int changesCount = await DeleteLotsAsync(lots);
        return changesCount;
    }
}