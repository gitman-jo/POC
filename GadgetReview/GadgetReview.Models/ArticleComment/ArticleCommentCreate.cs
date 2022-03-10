using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;

namespace GadgetReview.Models.ArticleComment
{
    public class ArticleCommentCreate
    {
        public int ArticleCommentId { get; set; }
        public int? ParentArticleCommentId { get; set; }
        public int ArticleId { get; set; }

        [Required(ErrorMessage = "Content is required")]
        [MinLength(10, ErrorMessage = "Must be atleast 10-300 characters")]
        [MaxLength(300, ErrorMessage = "Must be atleast 10-300 characters")]
        public string Content { get; set; }



    }
}
