using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using DevExpress.Core.Native;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace Numerology
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NavButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            
            if (b != null && b.Tag != null)
            {
                Type pageType = Type.GetType(b.Tag.ToString());

                // Make sure the page type exists, but don't navigate to it if it's already the current page.
                if (pageType != null && rootFrame.CurrentSourcePageType != pageType)
                {
                    (App.Current as App).Navigate(pageType);
                }
                else if (pageType == null)
                {
                    // TODO: Optional - Do something if page not found.
                }
            }   
        }

        //private void HelpButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Settings.HelpSettings helpSettingsFlyout = new Settings.HelpSettings();
        //    // When the settings flyout is opened from the app bar instead of from
        //    // the setting charm, use the ShowIndependent() method.
        //    helpSettingsFlyout.ShowIndependent();
        //    topAppBar.IsOpen = false;
        //    bottomAppBar.IsOpen = false;
        //}
    }
}