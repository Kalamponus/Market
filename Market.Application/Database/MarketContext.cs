using Market.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Database;

public class MarketContext : DbContext
{
    public DbSet<Lot> Lots => null!;
    public DbSet<User> Users => null!;

    public MarketContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=market.db");
    }
}