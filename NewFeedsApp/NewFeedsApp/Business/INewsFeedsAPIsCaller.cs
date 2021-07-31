using NewFeedsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewFeedsApp.Business
{
    public interface INewsFeedsAPIsCaller
    {
        Task<List<Article>> GetArticles(List<string> Sources, string ApiKey);
    }
}
