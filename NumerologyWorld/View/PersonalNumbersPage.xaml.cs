using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Numerology.Common;
using NavigationHelper = Numerology.Common.NavigationHelper;


// Документацию по шаблону элемента "Основная страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=234237

namespace Numerology.View
{
    /// <summary>
    /// Основная страница, которая обеспечивает характеристики, являющимися общими для большинства приложений.
    /// </summary>
    public sealed partial class PersonalNumbersPage : Page
    {

        private void Enter_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (btnCalcPersonalNumber.Command != null)
                {
                    ClearMonthesStyle();
                    btnCalcPersonalNumber.Command.Execute("CalcPersonalNumbersCommand");
                }

            }
        }

        //private void dtCalcDate_Loaded(object sender, RoutedEventArgs e)
        //{
        //    sender.Focus(FocusState.Keyboard);
        //}
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private NavigationHelper navigationHelper;

        /// <summary>
        /// NavigationHelper используется на каждой странице для облегчения навигации и 
        /// управление жизненным циклом процесса
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public PersonalNumbersPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
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
            //dtCalcDate.EditValue = Convert.ToDateTime("01/01/2012");
        }

        /// <summary>
        /// Сохраняет состояние, связанное с данной страницей, в случае приостановки приложения или
        /// удаления страницы из кэша навигации.  Значения должны соответствовать требованиям сериализации
        /// <see cref="Common.SuspensionManager.SessionState"/>.
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



        private void Button_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }


        private void Button_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearMonthesStyle();

            Button btn = (Button)sender;
            VisualStateManager.GoToState(btn, "Pressed", true);

            //btnMonth1.Foreground = new SolidColorBrush(Colors.White);
            //btnMonth2.Foreground = new SolidColorBrush(Colors.White);
            //btnMonth3.Foreground = new SolidColorBrush(Colors.White);
            //btnMonth4.Foreground = new SolidColorBrush(Colors.White);
            //btnMonth5.Foreground = new SolidColorBrush(Colors.White);
            //btnMonth6.Foreground = new SolidColorBrush(Colors.White);
        }

        private void btnCalcPersonalNumber_Click(object sender, RoutedEventArgs e)
        {
            ClearMonthesStyle();
        }

        private void ClearMonthesStyle() {
            VisualStateManager.GoToState(BtnMonth1, "Disabled", true);
            VisualStateManager.GoToState(btnMonth2, "Disabled", true);
            VisualStateManager.GoToState(btnMonth3, "Disabled", true);
            VisualStateManager.GoToState(btnMonth4, "Disabled", true);
            VisualStateManager.GoToState(btnMonth5, "Disabled", true);
            VisualStateManager.GoToState(btnMonth6, "Disabled", true);
            VisualStateManager.GoToState(btnMonth7, "Disabled", true);
            VisualStateManager.GoToState(btnMonth8, "Disabled", true);
            VisualStateManager.GoToState(btnMonth9, "Disabled", true);
            VisualStateManager.GoToState(btnMonth10, "Disabled", true);
            VisualStateManager.GoToState(btnMonth11, "Disabled", true);
            VisualStateManager.GoToState(btnMonth12, "Disabled", true);
        }
    }
}
