using Prism.Mvvm;
using Prism.Regions;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using TwitterClient.Views;
using TwitterClient.Infrastructure;


namespace TwitterClient.ViewModels
{
    [Export(typeof(TwitterClient.ViewModels.MainViewModel))]
    public class MainViewModel: BindableBase
    {
        [ImportingConstructor]
        public MainViewModel(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion(RegionNames.FeedRegion, () => new FeedView());
            //regionManager.RegisterViewWithRegion(RegionNames.MainRegion, () => new LoginView());
        }

    }
}
