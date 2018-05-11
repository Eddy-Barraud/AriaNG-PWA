﻿using Aria2c_C_UWP.Services;
using Aria2c_C_UWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Aria2c_C_UWP.Views
{
    public sealed partial class DownServicePage : Page
    {
        private DownServiceViewModel ViewModel => DataContext as DownServiceViewModel;

        public DownServicePage()
        {
            InitializeComponent();

            // This is an unusual way to initialize a service to a ViewModel, but since this service
            // requires a reference to the WebView this is one way to provide the required reference.
            // In this case teh WebViewService isn't a traditional Service but more of a shim to provide to better
            // separation of View and ViewModel and unit testing of a ViewModel that uses the WebViewService since the
            // WebViewService implements the IWebViewService interface that allows for mocking of the service.
            ViewModel.WebViewService = new WebViewService(webView);
        }
    }
}
