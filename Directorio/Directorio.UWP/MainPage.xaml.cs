using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Directorio.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            string archivo = "ContactosBD.db3";
            string carpeta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string ruta = System.IO.Path.Combine(carpeta, archivo);

            LoadApplication(new Directorio.App(ruta));
        }
    }
}
