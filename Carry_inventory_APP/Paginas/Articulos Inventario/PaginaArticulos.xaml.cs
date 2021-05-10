using Carry_inventory_APP.repositorios;
using Carry_inventory_APP.servicios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carry_inventory_APP.Paginas.Articulos_Inventario
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaArticulos : ContentPage
	{
		ServicioAPIInventario restServicios;
		public PaginaArticulos ()
		{
			InitializeComponent ();

			restServicios = new ServicioAPIInventario();
		}

        private async void btnVer_Clicked(object sender, EventArgs e)
        {
			List<RepositorioAPIInventario> resultadoRepositorio = await restServicios.ConsultarInventarioAsyc(constantes.APIInventarioURL);
			vistaColeccion.ItemsSource = resultadoRepositorio;
		}

        private async void btnIIr_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new Paginas.AñadirAInventario.AñadirAInventario());
		}
    }
}