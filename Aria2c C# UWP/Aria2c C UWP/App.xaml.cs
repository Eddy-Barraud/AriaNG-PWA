using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

using Aria2c_C_UWP.Services;

using Microsoft.Practices.Unity;

using Prism.Mvvm;
using Prism.Unity.Windows;
using Prism.Windows.AppModel;

using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;



namespace Aria2c_C_UWP
{
    public sealed partial class App : PrismUnityApplication
    {
        public App()
        {
            InitializeComponent();
           
        }

        protected override void ConfigureContainer()
        {
            // register a singleton using Container.RegisterType<IInterface, Type>(new ContainerControlledLifetimeManager());
            base.ConfigureContainer();
            Container.RegisterInstance<IResourceLoader>(new ResourceLoaderAdapter(new ResourceLoader()));
            Container.RegisterType<IWebViewService, WebViewService>();
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            IPropertySet roamingProperties = ApplicationData.Current.RoamingSettings.Values;
            if (roamingProperties.ContainsKey("HasBeenHereBefore"))
            {
                // The normal case
                return LaunchApplicationAsync(PageTokens.WebViewPage, null);
            }
            else
            {
                // The first-time case -- Go to the aria2c-rpc service download page                
                // The URI to launch
                string uriToLaunch = @"http://www.trevalim.fr/download/aria2c-rpc-service-installer/";

                // Create a Uri object from a URI string 
                var uri = new Uri(uriToLaunch);

                // Launch the URI
                async void LaunchDownload()
                {
                    // Launch the URI
                    var success = await Windows.System.Launcher.LaunchUriAsync(uri);
                }
                LaunchDownload();
                roamingProperties["HasBeenHereBefore"] = bool.TrueString; // Doesn't really matter what
                return LaunchApplicationAsync(PageTokens.WebViewPage, null);
            }

        }

        private async Task LaunchApplicationAsync(string page, object launchParam)
        {
            NavigationService.Navigate(page, launchParam);
            Window.Current.Activate();
            await Task.CompletedTask;
        }

        protected override Task OnActivateApplicationAsync(IActivatedEventArgs args)
        {
            return Task.CompletedTask;
        }

        protected override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            // We are remapping the default ViewNamePage and ViewNamePageViewModel naming to ViewNamePage and ViewNameViewModel to
            // gain better code reuse with other frameworks and pages within Windows Template Studio
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewModelTypeName = string.Format(CultureInfo.InvariantCulture, "Aria2c_C_UWP.ViewModels.{0}ViewModel, Aria2c_C_UWP", viewType.Name.Substring(0, viewType.Name.Length - 4));
                return Type.GetType(viewModelTypeName);
            });
            await base.OnInitializeAsync(args);
        }
    }
}
