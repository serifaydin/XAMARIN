using WebView_Samples.Droid.Renderers;
using WebView_Samples.Helpers;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidDevice))]
namespace WebView_Samples.Droid.Renderers
{
    public class AndroidDevice : IDevice
    {
        public string GetIdentifier()
        {
            return Android.Provider.Settings.Secure.GetString(Forms.Context.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
        }
    }
}