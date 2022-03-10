using GadgetReview.Models.ArticleComment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GadgetReview.Repository
{
    public interface IArticleCommentRepository
    {
        public Task<ArticleComment> UpsertAsync(ArticleCommentCreate articleCommentCreate, int applicationUserId);

        public Task<List<ArticleComment>> GetAllAsync(int articleId);

        public Task<ArticleComment> GetAsync(int articleCommentId);

        public Task<int> DeleteAsync(int articleCommentId);
    }
}
