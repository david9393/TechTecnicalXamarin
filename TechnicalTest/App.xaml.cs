using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SimpleInjector;
using Infrastructure.TechnicalTest.Repository;
using Domain.TechnicalTest.Tips;
using TechnicalTest.ViewModels;
using TechnicalTest.Services;
using TechnicalTest.Views;

namespace TechnicalTest
{
    public partial class App : Application
    {
        private static Container ioCContainer = new SimpleInjector.Container();
        public static Container IoCContainer
        {
            get => ioCContainer;
            set => ioCContainer = value;
        }
        public App()
        {
            Xamarin.Forms.Device.SetFlags(new string[] { "Shapes_Experimental"});
            InitializeComponent();
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            navigationService.InitializeAsync();
            //MainPage = new MainPage();

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
    }
}
