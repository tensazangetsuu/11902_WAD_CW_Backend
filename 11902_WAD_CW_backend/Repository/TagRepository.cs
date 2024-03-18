using _11902_WAD_CW_backend.Data;
using _11902_WAD_CW_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace _11902_WAD_CW_backend.Repository
{
    public class TagRepository : IBlogRepository<Tag>
    {
        private readonly BlogContext _context;

        public TagRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task Add(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Tag>> GetAll() => await _context.Tags.ToArrayAsync();

        public async Task<Tag> GetByID(int id) => await _context.Tags.FindAsync(id);

        public async Task Update(Tag tag)
        {
            _context.Entry(tag).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
