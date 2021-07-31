using NewFeedsApp.Business;
using NewFeedsApp.ViewModels;
using NewFeedsApp.Views;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using System;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using static NewFeedsApp.Enums.Enums;

namespace NewFeedsApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            
            await NavigationService.NavigateAsync($"SideMenuPage/NavigationPage/{nameof(ArticlesPage)}", new NavigationParameters() { { "PageTitle",  SideMenuItemsEnum.Articles.ToString()} });

            
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterInstance<INewsFeedsAPIsCaller>(new NewsFeedsAPIsCaller());
            containerRegistry.RegisterForNavigation<SideMenuPage, SideMenuPageViewModel>();
            containerRegistry.RegisterForNavigation<ArticlesPage, ArticlesPageViewModel>();
            containerRegistry.RegisterForNavigation<ArticlesDetails, ArticlesDetailsViewModel>();
            containerRegistry.RegisterForNavigation<LiveChat, LiveChatViewModel>();
            containerRegistry.RegisterForNavigation<Gallery, GalleryViewModel>();
            containerRegistry.RegisterForNavigation<WishList, WishListViewModel>();
            containerRegistry.RegisterForNavigation<ExploreOnlineNews, ExploreOnlineNewsViewModel>();
        }
    }
}
