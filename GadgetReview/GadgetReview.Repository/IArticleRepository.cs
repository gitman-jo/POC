using GadgetReview.Models.Article;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GadgetReview.Repository
{
    public interface IArticleRepository
    {
        public Task<Article> UpsertAsync(ArticleCreate articleCreate, int applicationUserId);

        public Task<PagedResults<Article>> GetAllAsync(ArticlePaging articlePaging);

        public Task<Article> GetAsync(int articleId);

        public Task<List<Article>> GetAllByUserIdAsync(int applicationUserId);

        public Task<List<Article>> GetAllFamousAsync();

        public Task<int> DeleteAsync(int articleId);
    }
}
