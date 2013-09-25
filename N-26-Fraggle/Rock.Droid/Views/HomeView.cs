using Android.App;
using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.Plugins.Messenger;
using Rock.Core.ViewModels;

namespace Rock.Droid.Views
{
    [Activity(Label = "View for HomeViewModel")]
    public class HomeView : MvxFragmentActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeView);

        }

        protected override void OnDestroy()
        {
            Mvx.Resolve<IMvxMessenger>().Publish(new JustAMessage(this) { Message = "Destroyed HomeView for viewmodel " + ((HomeViewModel)ViewModel).Id });
            base.OnDestroy();
        }

    }
}