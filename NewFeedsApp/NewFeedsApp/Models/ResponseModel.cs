using System;
using System.Collections.Generic;
using System.Text;

namespace NewFeedsApp.Models
{
    public class ResponseModel
    {
        public string status { get; set; }
        public string source { get; set; }
        public string sortBy { get; set; }
        public List<Article> articles { get; set; }
    }
}
