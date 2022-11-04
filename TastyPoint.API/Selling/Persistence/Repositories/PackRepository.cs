using Microsoft.EntityFrameworkCore;
using TastyPoint.API.Selling.Domain.Models;
using TastyPoint.API.Selling.Domain.Repositories;
using TastyPoint.API.Shared.Persistence.Contexts;
using TastyPoint.API.Shared.Persistence.Repositories;

namespace TastyPoint.API.Selling.Persistence.Repositories;

public class PackRepository: BaseRepository, IPackRepository
{
    public PackRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Pack>> ListAsync()
    {
        return await _context.Packs.ToListAsync();
    }

    public async Task AddAsync(Pack pack)
    {
        await _context.Packs.AddAsync(pack);
    }

    public async Task<Pack> FindByIdAsync(int id)
    {
        return await _context.Packs.FindAsync(id);
    }

    public void Update(Pack pack)
    {
        _context.Packs.Update(pack);
    }

    public void Remove(Pack pack)
    {
        _context.Packs.Remove(pack);
    }
}