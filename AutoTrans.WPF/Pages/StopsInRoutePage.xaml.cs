using AutoTrans.DB.Entities;
using AutoTrans.WPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoTrans.WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для StopsInRoutePage.xaml
    /// </summary>
    public partial class StopsInRoutePage : Page
    {
        List<StopsInRoute> stopsInRoutes;
        List<Stop> stopsInCb;
        Route currentRoute;

        /// <summary>
        /// Обработчик изменения остановок в маршрутах
        /// </summary>
        /// <param name="route"></param>
        public StopsInRoutePage(Route route)
        {
            InitializeComponent();

            Global.DB.ChangeTracker.Entries().ToList().ForEach(entry => entry.Reload());

            stopsInRoutes = Global.DB.StopsInRoutes.Where(s => s.Route.ID == route.ID).ToList();

            lblRouteName.Content += route.Number;
            currentRoute = route;

            cbStops_RemoveElements();
            dgStops_UploadDates();
        }

        /// <summary>
        /// Обработчик обновления данных.
        /// </summary>
        private void dgStops_UploadDates()
        {
            dgStops.ItemsSource = stopsInRoutes.OrderBy(s => s.Position).ToList();
        }

        /// <summary>
        /// Обработчик поднятия остановки на позицию вверх.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpStop_Click(object sender, RoutedEventArgs e)
        {
            var stopInRoute = (sender as Button).DataContext as StopsInRoute;
            if (stopInRoute == null) 
                return;

            stopsInRoutes.Remove(stopInRoute);

            var stopInRouteUp = stopsInRoutes.FirstOrDefault(s => s.Position == (stopInRoute.Position - 1));
            if (stopInRouteUp != null)
            {
                stopsInRoutes.Remove(stopInRouteUp);
                stopInRouteUp.Position = stopInRouteUp.Position + 1;
                stopsInRoutes.Add(stopInRouteUp);
            }

            stopInRoute.Position = stopInRoute.Position - 1;
            stopsInRoutes.Add(stopInRoute);

            RecountStopsInRoute();
        }

        /// <summary>
        /// Обработчик опускания остановки на позицию вниз.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownStop_Click(object sender, RoutedEventArgs e)
        {
            var stopInRoute = (sender as Button).DataContext as StopsInRoute;
            if (stopInRoute == null)
                return;

            stopsInRoutes.Remove(stopInRoute);

            var stopInRouteDown = stopsInRoutes.FirstOrDefault(s => s.Position == (stopInRoute.Position + 1));
            if (stopInRouteDown != null)
            {
                stopsInRoutes.Remove(stopInRouteDown);
                stopInRouteDown.Position = stopInRouteDown.Position - 1;
                stopsInRoutes.Add(stopInRouteDown);
            }

            stopInRoute.Position = stopInRoute.Position + 1;
            stopsInRoutes.Add(stopInRoute);
            RecountStopsInRoute();
        }

        /// <summary>
        /// Обработчик удаления остановки из остановок маршрута.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteStop_Click(object sender, RoutedEventArgs e)
        {
            var stopInRoute = (sender as Button).DataContext as StopsInRoute;
            if (stopInRoute == null)
                return;

            stopsInRoutes.Remove(stopInRoute);

            RecountStopsInRoute();
        }

        /// <summary>
        /// Обработчик добавления остановки на последнюю позицию.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddLastRoute_Click(object sender, RoutedEventArgs e)
        {
            if (cbStops.SelectedItem == null) return;
            StopsInRoute stopInRoute = new StopsInRoute();
            if (stopsInRoutes.Count == 0)
                stopInRoute.Position = 1;
            else
                stopInRoute.Position = stopsInRoutes.LastOrDefault().Position + 1;
            stopInRoute.Route = currentRoute;
            stopInRoute.Stop = cbStops.SelectedItem as Stop;

            stopsInRoutes.Add(stopInRoute);

            cbStops_RemoveElements();
            RecountStopsInRoute();
        }

        /// <summary>
        /// Обработчик добавления остановки на первую позицию.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFirstRoute_Click(object sender, RoutedEventArgs e)
        {
            if (cbStops.SelectedItem == null) return;
            StopsInRoute stopInRoute = new StopsInRoute();
            if (stopsInRoutes.Count == 0)
                stopInRoute.Position = 1;
            else
                stopInRoute.Position = stopsInRoutes.FirstOrDefault().Position - 1;
            stopInRoute.Route = currentRoute;
            stopInRoute.Stop = cbStops.SelectedItem as Stop;
            
            stopsInRoutes.Add(stopInRoute);

            cbStops_RemoveElements();
            RecountStopsInRoute();
        }

        /// <summary>
        /// Обработчик удаления остановок, которые имеются в остановках маршрута
        /// </summary>
        private void cbStops_RemoveElements()
        {
            stopsInCb = Global.DB.Stops.Where(s => s.City.ID == currentRoute.City.ID).ToList();
            foreach (StopsInRoute stopInRoute in stopsInRoutes)
            {
                if (stopsInCb.Contains(stopInRoute.Stop))
                    stopsInCb.Remove(stopInRoute.Stop);
            }

            cbStops.ItemsSource = stopsInCb;
        }

        /// <summary>
        /// Обработчик перерасчёта позиций остановок по порядку.
        /// </summary>
        private void RecountStopsInRoute()
        {
            for (int i = 0; i < stopsInRoutes.Count; i++)
            {
                stopsInRoutes.OrderBy(s => s.Position).ToList()[i].Position = i + 1;
            }

            dgStops_UploadDates();
        }

        /// <summary>
        /// Обработчик сохранения остановок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Global.DB.StopsInRoutes.RemoveRange(Global.DB.StopsInRoutes.Where(r => r.Route.ID == currentRoute.ID));
            Global.DB.SaveChanges();
            Global.DB.StopsInRoutes.AddRange(stopsInRoutes);

            Global.DB.SaveChanges();
        }
    }
}
