using _11902_WAD_CW_backend.Data;
using _11902_WAD_CW_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace _11902_WAD_CW_backend.Repository
{
    public class PostRepository : IBlogRepository<Post>
    {
        private readonly BlogContext _context;

        public PostRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task Add(Post post)
        {
            post.Tag = await _context.Tags.FindAsync(post.TagID.Value);

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Post>> GetAll() => await _context.Posts.Include(t => t.Tag).ToArrayAsync();

        public async Task<Post> GetByID(int id) => await _context.Posts.Include(t => t.Tag).FirstOrDefaultAsync(t => t.ID == id);

        public async Task Update(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
