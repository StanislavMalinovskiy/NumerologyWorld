using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using DevExpress.Core.Native;
using Numerology.Common;
using NavigationHelper = Numerology.Common.NavigationHelper;

// Документацию по шаблону элемента "Основная страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=234237

namespace Numerology.View
{
    /// <summary>
    /// Основная страница, которая обеспечивает характеристики, являющимися общими для большинства приложений.
    /// </summary>
    public sealed partial class CustomersPage : Page
    {

        private void gridCustomers_SelectionChanged(object sender, DevExpress.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            if (gridCustomers != null && gridCustomers.SelectedItems != null && gridCustomers.SelectedItems.Count > 2)
            {
                gridCustomers.SelectedItems.RemoveAt(0);
            }


            if (btnCompare != null && btnCompare.Command != null)
            {
                if (gridCustomers.SelectedItems.Count == 2)
                {
                    btnCompare.IsEnabled = true;
                }
                else
                {
                    btnCompare.IsEnabled = false;
                }
            }


            if (gridCustomers != null && btnCompare != null && gridCustomers.SelectedItems != null)
            {
                if (gridCustomers.SelectedItems.Count == 1 )
                {
                    btnOpenNumMap.IsEnabled = true;
                    btnDelete.IsEnabled = true;
                }
                else
                {
                    btnOpenNumMap.IsEnabled = false;
                    btnDelete.IsEnabled = false;
                }
            }
        }

        private void btnCompare_Click(object sender, RoutedEventArgs e)
        {
            ScrollIntoView();
        }
        private void btnCompare_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            ScrollIntoView();
        }

        private void btnOpenNumMap_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            NavigateToNumMap();
        }
        private void btnOpenNumMap_Click(object sender, RoutedEventArgs e)
        {
            NavigateToNumMap();
        }
        private void ScrollIntoView()
        {
            ScrollViewer scrollHost = ((IScrollableControl) SlideViewP).ScrollViewer;
            double horizontalOffset;
            horizontalOffset = 1200;
            scrollHost.ChangeView(horizontalOffset, null, null, false);
        }
        private void NavigateToNumMap()
        {
            navigationHelper.NavigateToNumMap(gridCustomers.SelectedItem);
       }

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

        public CustomersPage()
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

    }
}
