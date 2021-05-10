using Carry_inventory_APP.repositorios;
using Carry_inventory_APP.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carry_inventory_APP.Paginas.AñadirAInventario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AñadirAInventario : ContentPage
    {
        ServicioAPIInventario restServicios;

        public AñadirAInventario()
        {
            InitializeComponent();

            restServicios = new ServicioAPIInventario();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            RepositorioAPIInventario Articulo = new RepositorioAPIInventario
            {
                Descripcion_P = EntName.Text,
                Cantidad_S = int.Parse(EntCantidad.Text),
                Precio_V = int.Parse(EntPrecio.Text),
                Fecha_C = FechaCompra.Date,
                Fecha_E = FechaExpiraccion.Date
            };

            await restServicios.GuardarEnInventario(Articulo, constantes.APIInventarioURL, true);
            await Navigation.PopModalAsync();   

        }
    }
}