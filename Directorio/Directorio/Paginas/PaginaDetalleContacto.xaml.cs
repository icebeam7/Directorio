using Directorio.Modelos;
using Directorio.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.Media.Abstractions;

namespace Directorio.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaDetalleContacto : ContentPage
	{
        MediaFile foto;

        public PaginaDetalleContacto ()
		{
			InitializeComponent ();
		}

        private async void ButtonGuardar_Clicked(object sender, EventArgs e)
        {
            var contacto = new Contacto()
            {
                Nombre = EntryNombre.Text,
                Numero = EntryNumero.Text
            };

            var insert = ServicioBD.Guardar(contacto);

            if (insert)
                await DisplayAlert("¡Bien!", "¡Contacto registrado!", "OK");
            else
                await DisplayAlert("¡Aww!", "¡Contacto NO registrado!", "OK");
        }

        private async void ButtonCamara_Clicked(object sender, EventArgs e)
        {
            foto = await ServicioImagen.TomarFoto();

            if (foto != null)
                Fotografia.Source = ImageSource.FromStream(foto.GetStream);
        }

        private async void ButtonAnalizar_Clicked(object sender, EventArgs e)
        {
            var mensaje = await ServicioFace.AnalizarFoto(foto);
            await DisplayAlert("Analisis", mensaje, "OK");
        }
    }
}