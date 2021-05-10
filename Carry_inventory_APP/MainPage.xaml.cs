using Carry_inventory_APP.Paginas.Articulos_Inventario;
using Carry_inventory_APP.repositorios;
using Carry_inventory_APP.servicios;
using Carry_inventory_APP;
using System;
using System.Collections.Generic;                        
using Xamarin.Forms;

namespace Carry_inventory_APP
{
    public partial class MainPage : ContentPage
    {
      

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnConsulta_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaArticulos());
        }
    }
}
