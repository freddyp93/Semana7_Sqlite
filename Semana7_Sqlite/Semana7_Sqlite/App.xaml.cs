using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana7_Sqlite
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //pantalla con la que inicia la app
            MainPage = new NavigationPage(new Vistas.Login());
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
