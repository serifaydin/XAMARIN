using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WebView_Samples.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebView_Samples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewPage1 : ContentPage
    {

        WebViewViewModels viewModel = new WebViewViewModels();

        public WebViewPage1()
        {
            InitializeComponent();

            this.BindingContext = viewModel;
            viewModel.IsBusy = true;

            string DeviceUniqeID = DependencyService.Get<IDevice>().GetIdentifier();
            lblUniqID.Text = DeviceUniqeID;

            webView.Source = "https://www.xamarin.com/";
        }

        void backButtonClicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
            else
            {
                this.Navigation.PopModalAsync();

            }
        }

        void forwardButtonClicked(object sender, EventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
            }
        }

        /// <summary>
        /// Her sayfa açılırken tetiklenir -- Navigating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void webOnNavigating(object sender, WebNavigatingEventArgs e)
        {
            this.labelLoading.IsVisible = true; //display the label when navigating starts
            DisplayAlert("Gidilmeye çalışılan sayfanın adı -- Navigating ", e.Url, "OK");
            viewModel.IsBusy = true;
        }

        /// <summary>
        /// Her sayfa açıldığında tetiklenir --Navigated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void webOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            this.labelLoading.IsVisible = false; //remove the loading indicator when navigating is finished
            DisplayAlert("Girilen sayfanın adı -- Navigated", e.Url, "OK");
            viewModel.IsBusy = false;
        }
    }

    public class WebViewViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void onPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public WebViewViewModels()
        {
            IsBusy = false;
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                onPropertyChanged();
            }
        }
    }
}