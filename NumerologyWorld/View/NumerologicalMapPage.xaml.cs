using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using DevExpress.Core.Native;
using Numerology.Common;
using Numerology.Model;
using NavigationHelper = Numerology.Common.NavigationHelper;

// Документацию по шаблону элемента "Основная страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=234237

namespace Numerology.View
{
    /// <summary>
    /// Основная страница, которая обеспечивает характеристики, являющимися общими для большинства приложений.
    /// </summary>
    public sealed partial class NumerologicalMapPage : Page
    {
        private NavigationHelper navigationHelper;
 
        private void txtLastName_Loaded(object sender, RoutedEventArgs e)
        {
            txtLastName.Focus(FocusState.Keyboard);
        }

        private void Enter_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (btnCalc.Command != null) btnCalc.Command.Execute("CalcCommand");
                ScrollIntoView(AnaliseSlideViewItem);
            }
        }


        //private void dtBirthDate_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        //{
        //    if (e.Key == Windows.System.VirtualKey.Enter)
        //    {

        //        txtLastName.Focus(FocusState.Keyboard);
        //        //txtLastName.Select(0,0);
               
        //        //dtBirthDate.EditValue = dtBirthDate.Text;

        //        if (btnCalc.Command != null) btnCalc.Command.Execute("CalcCommand");
        //        ScrollIntoView(AnaliseSlideViewItem);
        //    }
        //}

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //double remainingWidth = Windows.UI.Xaml.Window.Current.Bounds.Width - 362;
            //myWebView.Width = remainingWidth;
            //myWebView.Height = e.NewSize.Height;
            WebWiewDayDescription.Height = e.NewSize.Height - 513;
            WebWiewDayDescription2.Height = e.NewSize.Height - 513;
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (HasValidationErrors() == false)
            {
                ScrollIntoView(AnaliseSlideViewItem);
            }
        }
        private void btnCalc_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (HasValidationErrors() == false)
            {
                ScrollIntoView(AnaliseSlideViewItem);
            }
        }

        private void DateEditPopupSettings_PopupClosed(object sender, DevExpress.UI.Xaml.Editors.ClosePopupEventArgs e)
        {
            Debug.WriteLine("Closed");
        }

        private void ScrollIntoView(FrameworkElement element)
        {
            ScrollViewer scrollHost = ((IScrollableControl)SlideView).ScrollViewer;
            double horizontalOffset;
            horizontalOffset = 632;
            scrollHost.ChangeView(horizontalOffset, null, null, false);
        }

        bool HasValidationErrors()
        {
            if (txtMobile.HasValidationError || txtHome.HasValidationError || txtEmail.HasValidationError)
            {
                return true;
            }
            return false;
        }

        public NumerologicalMapPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }



        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// NavigationHelper используется на каждой странице для облегчения навигации и 
        /// управление жизненным циклом процесса
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Заполняет страницу содержимым, передаваемым в процессе навигации. Любое сохраненное состояние также является
        /// при повторном создании страницы из предыдущего сеанса.
        /// </summary>
        /// <param name="sender">
        /// Источник события; как правило, <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Данные события, предоставляющие параметр навигации, который передается
        /// <see cref="Frame.Navigate(Type, Object)"/> при первоначальном запросе этой страницы, и
        /// словарь состояния, сохраненного этой страницей в ходе предыдущего
        /// сеансом. Состояние будет равно значению NULL при первом посещении страницы.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {

            if (e.NavigationParameter != null)
            {
                Customer Cust = e.NavigationParameter as Customer;

                if (Cust != null)
                {
                    txtLastName.Text = Cust.LastName;
                    txtFirstName.Text = Cust.FirstName;
                    txtSecondName.Text = Cust.SecondName;
                    dtBirthDate.Date = Cust.BirthDate;
                    txtEmail.Text = Cust.Email;
                    txtHome.Text = Cust.HomePhone;
                    txtMobile.Text = Cust.MobilePhone;
                }

                if (btnCalc.Command != null) btnCalc.Command.Execute("CalcCommand");
                ScrollIntoView(AnaliseSlideViewItem);

            }
            else
            {
                txtLastName.Text ="";
                txtFirstName.Text ="";
                txtSecondName.Text ="";
                dtBirthDate.Date = Convert.ToDateTime("01/01/1980");
                txtEmail.Text = "";
                txtHome.Text ="";
                txtMobile.Text = "";
            }
        }

        /// <summary>
        /// Сохраняет состояние, связанное с данной страницей, в случае приостановки приложения или
        /// удаления страницы из кэша навигации.  Значения должны соответствовать требованиям сериализации
        /// <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">Источник события; как правило, <see cref="NavigationHelper"/></param>
        /// <param name="e">Данные события, которые предоставляют пустой словарь для заполнения
        /// сериализуемым состоянием.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region Регистрация NavigationHelper

        /// Методы, предоставленные в этом разделе, используются исключительно для того, чтобы
        /// NavigationHelper для отклика на методы навигации страницы.
        /// 
        /// Логика страницы должна быть размещена в обработчиках событий для 
        /// Параметр навигации доступен в методе LoadState 
        /// в дополнение к состоянию страницы, сохраненному в ходе предыдущего сеанса.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
      navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }
}
