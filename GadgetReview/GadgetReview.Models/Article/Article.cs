using System;
using System.Collections.Generic;
using System.Text;

namespace GadgetReview.Models.Article
{
    public class Article: ArticleCreate
    {
        public string Username { get; set; }
        public int ApplicationUserId { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
