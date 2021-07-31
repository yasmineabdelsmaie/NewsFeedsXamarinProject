using NewFeedsApp.Models;
using NewFeedsApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NewFeedsApp.Enums.Enums;

namespace NewFeedsApp.ViewModels
{
    public class SideMenuPageViewModel : ViewModelBase
    {
        public DelegateCommand<object> MenuItemSelectedCommand { get; set; }
        private List<MenuItemUIModel> menuItems;
        public List<MenuItemUIModel> MenuItems
        {
            get
            {
                return menuItems;
            }
            set
            {
                SetProperty(ref menuItems, value);
            }
        }
        
        public SideMenuPageViewModel(INavigationService navigationService) : base(navigationService)
        {
           MenuItemSelectedCommand = new DelegateCommand<object>(async (object obj) => await MenuItemSelectedCommandExecute(obj));
        }

        private async Task MenuItemSelectedCommandExecute(object obj)
        {
           
            MenuItemUIModel SelectedItem = obj as MenuItemUIModel;
            if (SelectedItem != null)
            {
              
            try
            {
                    NavigationParameters parms = new NavigationParameters() { { "PageTitle", SelectedItem.Title } };
                switch ((int)SelectedItem.Id)
                {
                    case (int)SideMenuItemsEnum.Articles:
                        await NavigationService.NavigateAsync($"NavigationPage/{nameof(ArticlesPage)}",parms);
                        break;
                    case (int)SideMenuItemsEnum.LiveChat:
                        await NavigationService.NavigateAsync($"NavigationPage/{nameof(LiveChat)}",parms);
                        break;
                    case (int)SideMenuItemsEnum.Gallery:
                        await NavigationService.NavigateAsync($"NavigationPage/{nameof(Gallery)}",parms);
                        break;
                    case (int)SideMenuItemsEnum.WishList:
                        await NavigationService.NavigateAsync($"NavigationPage/{nameof(WishList)}",parms);
                        break;
                    case (int)SideMenuItemsEnum.ExploreOnlineNews:
                        await NavigationService.NavigateAsync($"NavigationPage/{nameof(ExploreOnlineNews)}",parms);
                        break;
                    default:
                        break;

                }

            }

            catch (Exception ex)
            {
                    await App.Current.MainPage.DisplayAlert("Error", "Sorry, something went wrong", "OK");
                }
            }
        }



        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            MenuItems = new List<MenuItemUIModel>() {
                { new MenuItemUIModel() {Id = 1, Title= "Articles", ImageSource ="articleIcon.png" } },
                { new MenuItemUIModel() {Id = 2 , Title= "Live Chat", ImageSource ="live.png" } },
                { new MenuItemUIModel() {Id = 3 , Title= "Gallery", ImageSource ="gallery.png" } },
                { new MenuItemUIModel() {Id = 4 , Title= "Wish List", ImageSource ="wishlist.png" } },
                { new MenuItemUIModel() {Id = 5 , Title= "Explore Online News", ImageSource ="exploreIcon.png" } },
                };


        }
    }
}
