using BlogPodrozniczy.Web.Data;
using BlogPodrozniczy.Web.Models.Domena;
using Microsoft.EntityFrameworkCore;

namespace BlogPodrozniczy.Web.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogDB blogDB;

        public BlogPostRepository(BlogDB blogDB)
        {
            this.blogDB = blogDB;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await blogDB.AddAsync(blogPost);
            await blogDB.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var existingBlog = await blogDB.Posty.FindAsync(id);

            if (existingBlog != null)
            {
                blogDB.Posty.Remove(existingBlog);
                await blogDB.SaveChangesAsync();
                return existingBlog;
            }
            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await blogDB.Posty.Include(x => x.Tagi).ToListAsync();
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await blogDB.Posty.Include(x => x.Tagi).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            return await blogDB.Posty.Include(x => x.Tagi)
                .FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            var existingBlog = await blogDB.Posty.Include(x => x.Tagi).FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            if (existingBlog != null)
            {
                existingBlog.Id = blogPost.Id;
                existingBlog.Nagłówek = blogPost.Nagłówek;
                existingBlog.TytułStrony = blogPost.TytułStrony;
                existingBlog.Treść = blogPost.Treść;
                existingBlog.KrótkiOpis = blogPost.KrótkiOpis;
                existingBlog.Autor = blogPost.Autor;
                existingBlog.UrlZdjęcia = blogPost.UrlZdjęcia;
                existingBlog.UrlHandle = blogPost.UrlHandle;
                existingBlog.Widoczność = blogPost.Widoczność;
                existingBlog.DataPublikacji = blogPost.DataPublikacji;
                existingBlog.Tagi = blogPost.Tagi;

                await blogDB.SaveChangesAsync();
                return existingBlog;
            }
            return null;
        }
    }
}
