using AppLitePosition.Models;
using AppLitePosition.Services;
using AppLitePosition.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppLitePosition
{
    public partial class App : Application
    {
        static PositionController objPositionDatabase;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static PositionController PositionDatabase
        {
            get
            {
                if (objPositionDatabase == null) {
                    objPositionDatabase = new PositionController();
                }
                return objPositionDatabase;
            }
        }
    }
}
