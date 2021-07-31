using NewFeedsApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewFeedsApp.Interfaces
{
    interface INewsFeedsAPI
    {
        [Get("/v1/articles?source={Source}&&apiKey={ApiKey}")]
        Task<ResponseModel> GetNewsFeed(string Source, string ApiKey);
    }
}
