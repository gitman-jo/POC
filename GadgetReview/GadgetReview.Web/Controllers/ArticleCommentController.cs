using GadgetReview.Models.ArticleComment;
using GadgetReview.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadgetReview.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleCommentController : ControllerBase
    {
        private readonly IArticleCommentRepository _articleCommentRepository;

        public ArticleCommentController(IArticleCommentRepository articleCommentRepository)
        {
            _articleCommentRepository = articleCommentRepository;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ArticleComment>> Create(ArticleCommentCreate articleCommentCreate)
        {
            int applicationUserId = int.Parse(User.Claims.First(i => i.Type == JwtRegisteredClaimNames.NameId).Value);

            var createdArticleComment = await _articleCommentRepository.UpsertAsync(articleCommentCreate, applicationUserId);

            return Ok(createdArticleComment);
        }
        [HttpGet("{articleId}")]
        public async Task<ActionResult<List<ArticleComment>>> GetAll(int articleId)
        {
            var articleComments = await _articleCommentRepository.GetAllAsync(articleId);

            return articleComments;
        }
        [Authorize]
        [HttpDelete("{articleCommentId}")]
        public async Task<ActionResult<int>> Delete(int articleCommentId)
        {
            int applicationUserId = int.Parse(User.Claims.First(i => i.Type == JwtRegisteredClaimNames.NameId).Value);

            var foundarticleComment = await _articleCommentRepository.GetAsync(articleCommentId);

            if (foundarticleComment == null) return BadRequest("Comment does not exist.");

            if (foundarticleComment.ApplicationUserId == applicationUserId)
            {
                var affectedRows = await _articleCommentRepository.DeleteAsync(articleCommentId);

                return Ok(affectedRows);
            }
            else
            {
                return BadRequest("This comment was not created by the current user.");
            }
        }
    }
}
