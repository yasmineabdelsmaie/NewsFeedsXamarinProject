using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewFeedsApp.ViewModels
{
    public class ExploreOnlineNewsViewModel : ViewModelBase
    {
        public ExploreOnlineNewsViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters != null && parameters.ContainsKey("PageTitle"))
                Title = parameters.GetValue<string>("PageTitle");
        }
    }
}
