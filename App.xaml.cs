

namespace OhmsLaws
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

/*            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(MCEntry), (handler, view) =>
            {
                if (view is MCEntry)
                {
                    #if ANDROID
                        handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                    #elif IOS
                        handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                        handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
                    #endif
                }
            });*/
        }
    }
}