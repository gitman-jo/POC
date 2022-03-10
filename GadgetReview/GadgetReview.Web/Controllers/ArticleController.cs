using GadgetReview.Models.Article;
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
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IPhotoRepository _photoRepository;

        public ArticleController(IArticleRepository articleRepository, IPhotoRepository photoRepository)
        {
            _articleRepository = articleRepository;
            _photoRepository = photoRepository;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Article>> Create(ArticleCreate articleCreate)
        {
            int applicationUserId = int.Parse(User.Claims.First(i => i.Type == JwtRegisteredClaimNames.NameId).Value);

            if (articleCreate.PhotoId.HasValue)
            {
                var photo = await _photoRepository.GetAsync(articleCreate.PhotoId.Value);

                if (photo.ApplicationUserId != applicationUserId)
                {
                    return BadRequest("You did not upload the photo.");
                }
            }

            var article = await _articleRepository.UpsertAsync(articleCreate, applicationUserId);

            return Ok(article);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResults<Article>>> GetAll([FromQuery] ArticlePaging articlePaging)
        {
            var articles = await _articleRepository.GetAllAsync(articlePaging);

            return Ok(articles);
        }

        [HttpGet("{articleId}")]
        public async Task<ActionResult<Article>> Get(int articleId)
        {
            var article = await _articleRepository.GetAsync(articleId);

            return Ok(article);
        }

        [HttpGet("user/{applicationUserId}")]
        public async Task<ActionResult<List<Article>>> GetByApplicationUserId(int applicationUserId)
        {
            var articles = await _articleRepository.GetAllByUserIdAsync(applicationUserId);

            return Ok(articles);
        }

        [HttpGet("famous")]
        public async Task<ActionResult<List<Article>>> GetAllFamous()
        {
            var articles = await _articleRepository.GetAllFamousAsync();

            return Ok(articles);
        }

        [Authorize]
        [HttpDelete("{articleId}")]
        public async Task<ActionResult<int>> Delete(int articleId)
        {
            int applicationUserId = int.Parse(User.Claims.First(i => i.Type == JwtRegisteredClaimNames.NameId).Value);

            var foundarticle = await _articleRepository.GetAsync(articleId);

            if (foundarticle == null) return BadRequest("Article does not exist.");

            if (foundarticle.ApplicationUserId == applicationUserId)
            {
                var affectedRows = await _articleRepository.DeleteAsync(articleId);

                return Ok(affectedRows);
            }
            else
            {
                return BadRequest("You didn't create this blog.");
            }
        }
    }
}
