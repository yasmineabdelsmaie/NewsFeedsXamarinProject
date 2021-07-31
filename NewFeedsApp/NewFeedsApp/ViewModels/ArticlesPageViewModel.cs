using NewFeedsApp.Business;
using NewFeedsApp.Config;
using NewFeedsApp.Models;
using NewFeedsApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewFeedsApp.ViewModels
{
    public class ArticlesPageViewModel : ViewModelBase
    {
        INavigationService navigationService;
        INewsFeedsAPIsCaller newsFeedsAPIsCaller;

        public DelegateCommand<object> ArticleClickedCommand { get; set; }
        private List<Article> articlesList;
        public List<Article> ArticlesList
        {
            get
            {
                return articlesList;
            }
            set
            {
                SetProperty(ref articlesList, value);
            }
        }

        public ArticlesPageViewModel(INavigationService navigationService, INewsFeedsAPIsCaller newsFeedsAPIsCaller) : base(navigationService)
        {
            this.navigationService = navigationService;
            this.newsFeedsAPIsCaller = newsFeedsAPIsCaller;
            ArticleClickedCommand = new DelegateCommand<object>(ArticleClickedCommandExecute);
        }

        private void ArticleClickedCommandExecute(object obj)
        {
            Article SelectedArticle = obj as Article;
            NavigationParameters pairs = new NavigationParameters() { {"SelectedArticle", SelectedArticle } };
            NavigationService.NavigateAsync(nameof(ArticlesDetails), pairs);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters != null && parameters.ContainsKey("PageTitle"))
                Title = parameters.GetValue<string>("PageTitle");
            GetArticles();

        }
        private async Task<List<Article>> GetArticles()
        {
            IsLoading = true;
            bool IsInernetAvailable = CheckInternetConnectivity();
            if (!IsInernetAvailable)
            {
                IsLoading = false;
                await App.Current.MainPage.DisplayAlert("No Available Internet", "Please make sure that you are connected to the internet", "OK");
                return null;
            }
            ArticlesList = await newsFeedsAPIsCaller.GetArticles(new List<string>() {ApiConfigrations.associated_press_source, ApiConfigrations.the_next_web_source }, ApiConfigrations.ApiKey);
            IsLoading = false;
            return ArticlesList;
        }

    }
}
