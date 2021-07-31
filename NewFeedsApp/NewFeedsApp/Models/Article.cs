using System;
using System.Collections.Generic;
using System.Text;

namespace NewFeedsApp.Models
{
    public class Article
    {
        public string author { get; set; }
        public string DisplayingAuthor
        {
            get
            {
                return string.IsNullOrEmpty(author) ? "Unknown Author" : author;
            }
            
        }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public DateTime publishedAt { get; set; }
        public string DisplayingDate
        {
            get
            {
                return publishedAt != null ? publishedAt.ToString("MMMM dd,yyyy") : null;
            }
        }
    }
}
