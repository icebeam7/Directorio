using Directorio.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Directorio.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaListaContactos : ContentPage
	{
		public PaginaListaContactos ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ListViewContactos.ItemsSource = ServicioBD.ObtenerContactos();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaDetalleContacto());
        }
    }
}