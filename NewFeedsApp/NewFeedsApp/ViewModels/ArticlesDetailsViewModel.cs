using NewFeedsApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NewFeedsApp.ViewModels
{
    public class ArticlesDetailsViewModel : ViewModelBase
    {
        public DelegateCommand OpenWebsiteCommand { get; set; }
        private Article selectedArticle;
        public Article SelectedArticle
        {
            get
            {
                return selectedArticle;
            }
            set
            {
                SetProperty(ref selectedArticle, value);
            }
        }
        public ArticlesDetailsViewModel(INavigationService navigationService) : base(navigationService)
        {
            OpenWebsiteCommand = new DelegateCommand(async () => await OpenWebsiteCommandExecute());
        }

        private async Task OpenWebsiteCommandExecute()
        {
            try
            {
                await Browser.OpenAsync(SelectedArticle.url, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Sorry, something went wrong", "OK");
            }

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters != null)
            {
                if (parameters.ContainsKey("PageTitle"))
                    Title = parameters.GetValue<string>("PageTitle");
                if (parameters.ContainsKey("SelectedArticle"))
                    SelectedArticle = parameters.GetValue<Article>("SelectedArticle");
            }

        }
    }
}
