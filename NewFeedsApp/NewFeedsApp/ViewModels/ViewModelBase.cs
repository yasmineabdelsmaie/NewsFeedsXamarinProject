using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace NewFeedsApp.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                SetProperty(ref isLoading, value);
            }
        }
        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        public bool CheckInternetConnectivity()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                return true;
            }
            else if (current == NetworkAccess.ConstrainedInternet)
            {
                /*Limited internet access. Indicates captive portal connectivity,
                where local access to a web portal is provided,
                but access to the Internet requires that specific credentials are provided via a portal.*/
                return false;
            }
            else if (current == NetworkAccess.Local)
            {
                //Local network access only.
                return false;
            }
            else if (current == NetworkAccess.None)
            {
                //No connectivity is available.
                return false;
            }
            else if (current == NetworkAccess.Unknown)
            {
                //Unable to determine internet connectivity.
                return false;
            }
            else
                return false;
        }
    }
}
