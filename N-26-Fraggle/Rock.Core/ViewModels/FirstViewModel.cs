using System;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Converters;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;

namespace Rock.Core.ViewModels
{
    public class JustAMessage : MvxMessage
    {
        public JustAMessage(object sender)
            : base(sender)
        {
        }

        public string Message { get; set; }
    }

    public class LengthValueConverter
        : MvxValueConverter<string, int>
    {
        protected override int Convert(string value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Length;
        }
    }

    public class HomeViewModel
        : MvxViewModel
    {
        public static int IdCounter = 0;
        public int Id = IdCounter++;
        public HomeViewModel()
        {

            var messenger = Mvx.Resolve<IMvxMessenger>();
            messenger.Subscribe<JustAMessage>(OnMessage);
            messenger.Publish(new JustAMessage(this) { Message = "Created HomeViewModel" + Id });
        }

        private void OnMessage(JustAMessage message)
        {
            var trace = Mvx.Resolve<IMvxTrace>();
            trace.Trace(MvxTraceLevel.Warning, "HomeViewModel", "HomeViewModel {1} received: {0}", message.Message, Id);
        }

        public ICommand First { get { return new MvxCommand(() => ShowViewModel<FirstViewModel>()); } }
        public ICommand Second { get { return new MvxCommand(() => ShowViewModel<SecondViewModel>()); } }
    }
    public class FirstViewModel
        : MvxViewModel
    {
        public static int IdCounter = 0;
        public int Id = IdCounter++;
        public FirstViewModel()
        {
            var messenger = Mvx.Resolve<IMvxMessenger>();
            messenger.Subscribe<JustAMessage>(OnMessage);
            messenger.Publish(new JustAMessage(this) { Message = "Created FirstViewModel" + Id });
        }

        private void OnMessage(JustAMessage message)
        {
            var trace = Mvx.Resolve<IMvxTrace>();
            trace.Trace(MvxTraceLevel.Warning, "FirstViewModel", "FirstViewModel {1} received: {0}", message.Message, Id);
        }

        private SubViewModel _sub = new SubViewModel();
        public SubViewModel Sub
        {
            get { return _sub; }
            set
            {
                _sub = value;
                RaisePropertyChanged(() => Sub);
            }
        }
    }

    public class SecondViewModel
        : MvxViewModel
    {
        public static int IdCounter = 0;
        public int Id = IdCounter++;
        public SecondViewModel()
        {
            var messenger = Mvx.Resolve<IMvxMessenger>();
            messenger.Subscribe<JustAMessage>(OnMessage);
            messenger.Publish(new JustAMessage(this) { Message = "Created SecondViewModel" + Id });
        }

        private void OnMessage(JustAMessage message)
        {
            var trace = Mvx.Resolve<IMvxTrace>();
            trace.Trace(MvxTraceLevel.Warning, "SecondViewModel", "SecondViewModel {1} received: {0}", message.Message, Id);
        }

        private SubViewModel _sub = new SubViewModel();
        public SubViewModel Sub
        {
            get { return _sub; }
            set
            {
                _sub = value;
                RaisePropertyChanged(() => Sub);
            }
        }
    }

    public class SubViewModel
        : MvxViewModel
    {
        public static int IdCounter = 0;
        public int Id = IdCounter++;
        public SubViewModel()
        {
            var messenger = Mvx.Resolve<IMvxMessenger>();
            messenger.Subscribe<JustAMessage>(OnMessage);
            messenger.Publish(new JustAMessage(this) { Message = "Created SubViewModel" + Id });
        }

        private void OnMessage(JustAMessage message)
        {
            var trace = Mvx.Resolve<IMvxTrace>();
            trace.Trace(MvxTraceLevel.Warning, "SubViewModel", "SubViewModel {1} received: {0}", message.Message, Id);
        }

        private string _hello = "Hello MvvmCross";
        public string Hello
        {
            get { return _hello; }
            set
            {
                _hello = value;
                RaisePropertyChanged(() => Hello);
            }
        }
    }
}
