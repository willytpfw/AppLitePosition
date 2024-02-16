using AppLitePosition.Data;
using AppLitePosition.Models;
using AppLitePosition.ViewModels;
using AppLitePosition.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace AppLitePosition.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;
        ObservableCollection<Position> dataGPS = new ObservableCollection<Position>();
        PositionController objPositionDB = new PositionController();
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
            LoadData();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void LoadData()
        {
            dataGPS.Clear();
            List<Position> lstPositions = objPositionDB.GetLstPosition();
            if (lstPositions != null)
                foreach (var item in lstPositions)
                {
                    dataGPS.Add(item);
                }
            lstViewGPS.ItemsSource = dataGPS;
        }
        private void OnButtonSaveClicked(object sender, EventArgs e)
        {
            try
            {
                Location lLocation = new Location();
                //var plocation = Geolocation.GetLastKnownLocationAsync();


                Position objPosition = new Position();

                var plocation = new Location(22.1593, 100.9639);

                if (plocation != null)
                {
                    lLocation = plocation; //.Result;

                    //objPosition.Positiong = new GeographyPositiong();

                    objPosition.Longitude = lLocation.Longitude;
                    objPosition.Latitude = lLocation.Latitude;


                    // ADD new Point GPS
                    objPositionDB.SavePosition(objPosition);
                    dataGPS.Add(objPosition);
                    lstViewGPS.ItemsSource = dataGPS;

                }
                else
                {// ADD new Point GPS not work

                    lstViewGPS.ItemsSource = dataGPS;

                }
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }

        }

        private void OnButtonDeleteClicked(object sender, EventArgs e)
        {
            Position objPosition = new Position();

            var button = sender as Xamarin.Forms.Button;
            var stackLayout = button.Parent as StackLayout;
            stackLayout.Children.Remove(button);

            var lID = ((Label)stackLayout.Children[1]).Text;
            objPosition = objPositionDB.GetPosition(int.Parse(lID));
            objPositionDB.DeletePosition(objPosition);

            dataGPS.Remove(objPosition);
            lstViewGPS.ItemsSource = dataGPS;
        }
    }
}