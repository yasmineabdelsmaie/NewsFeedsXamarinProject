using Microsoft.AppCenter.Crashes;
using NewFeedsApp.Config;
using NewFeedsApp.Interfaces;
using NewFeedsApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewFeedsApp.Business
{
    public class NewsFeedsAPIsCaller : INewsFeedsAPIsCaller
    {
        public async Task<List<Article>> GetArticles(List<string> Sources, string ApiKey)
        {
            try
            {
                List <Article> AllArticles = new List<Article>();
                var ApiResponse = RestService.For<INewsFeedsAPI>(RefitHandler.BaseURL);
               
                foreach (var Source in Sources)
                {
                     ResponseModel ArticlesResponseModel = await ApiResponse.GetNewsFeed(Source, ApiKey);
                    if (ArticlesResponseModel != null && ArticlesResponseModel.status == ApiConfigrations.OK && ArticlesResponseModel.articles != null)
                    {
                       var ArticlesListPerSource = ArticlesResponseModel.articles;
                       AllArticles.AddRange(ArticlesListPerSource);
                    }
                }
                return AllArticles;   
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Sorry, something went wrong", "OK");
                return null;
            }
        }
    }
}
