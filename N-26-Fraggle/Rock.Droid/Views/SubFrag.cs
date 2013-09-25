using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.Plugins.Messenger;
using Rock.Core.ViewModels;

namespace Rock.Droid.Views
{
    public class SubFrag : MvxFragment
    {
        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.SubFrag, null);
        }

        public override void OnDestroy()
        {
            Mvx.Resolve<IMvxMessenger>().Publish(new JustAMessage(this) { Message = "Destroyed SubFrag for viewmodel " + ((SubViewModel)ViewModel).Id });
            base.OnDestroy();
        }

    }
    public class DubFrag : MvxFragment
    {
        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.DubFrag, null);
        }

        public override void OnDestroy()
        {
            Mvx.Resolve<IMvxMessenger>().Publish(new JustAMessage(this) { Message = "Destroyed DubFrag for viewmodel " + ((SubViewModel)ViewModel).Id });
            base.OnDestroy();
        }
    }
}