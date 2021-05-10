using Newtonsoft.Json;
using Carry_inventory_APP.repositorios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Carry_inventory_APP.servicios
{
    public class ServicioAPIInventario
    {
        HttpClient _cliente;

        public ServicioAPIInventario()
        {
            _cliente = new HttpClient();
        }
        public async Task<List<RepositorioAPIInventario>> ConsultarInventarioAsyc(string ruta)
        {
            List<RepositorioAPIInventario> repositorios = null;

            try
            {
                HttpResponseMessage respuesta = await _cliente.GetAsync(ruta);

                if (respuesta.IsSuccessStatusCode)
                {
                    string contenido = await respuesta.Content.ReadAsStringAsync();
                    repositorios = JsonConvert.DeserializeObject<List<RepositorioAPIInventario>>(contenido);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("\tError {0}", ex.Message);          
            }

            return repositorios;
    }
    }

   
}
