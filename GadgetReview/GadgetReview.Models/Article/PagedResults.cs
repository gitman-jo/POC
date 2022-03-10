using System;
using System.Collections.Generic;
using System.Text;

namespace GadgetReview.Models.Article
{
    public class PagedResults<T>
    {
        public IEnumerable<T> Item { get; set; }
        public int TotalCount { get; set; }



    }
}
