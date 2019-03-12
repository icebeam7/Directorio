using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Directorio
{
    public partial class App : Application
    {
        public static string RutaBD;

        public App(string rutaBD)
        {
            InitializeComponent();

            RutaBD = rutaBD;

            MainPage = new NavigationPage(new Paginas.PaginaListaContactos());
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
