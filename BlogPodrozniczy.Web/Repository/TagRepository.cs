using BlogPodrozniczy.Web.Data;
using BlogPodrozniczy.Web.Models.Domena;
using Microsoft.EntityFrameworkCore;

namespace BlogPodrozniczy.Web.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogDB blogDB;

        public TagRepository(BlogDB blogDB)
        {
            this.blogDB = blogDB;
        }

        public async Task<Tag> AddAsync(Tag tag)
        {
            await blogDB.Tagi.AddAsync(tag);
            await blogDB.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await blogDB.Tagi.FindAsync(id);

            if (existingTag != null)
            {
                blogDB.Tagi.Remove(existingTag);
                await blogDB.SaveChangesAsync();
                return existingTag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await blogDB.Tagi.ToListAsync();
        }

        public Task<Tag?> GetAsync(Guid id)
        {
            return blogDB.Tagi.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await blogDB.Tagi.FindAsync(tag.Id);

            if (existingTag != null)
            {
                existingTag.Nazwa = tag.Nazwa;
                existingTag.WyświetlanaNazwa = tag.WyświetlanaNazwa;

                await blogDB.SaveChangesAsync();

                return existingTag;
            }
            return null;
        }
    }
}
