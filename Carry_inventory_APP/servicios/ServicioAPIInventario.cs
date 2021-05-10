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

        public async Task GuardarEnInventario(RepositorioAPIInventario Articulos, string ruta, bool isNewItem = false)
        {
            Uri RutaFormateada = new Uri(string.Format(ruta, string.Empty));

            string json = JsonConvert.SerializeObject(Articulos, Formatting.Indented);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage responseMessage = null;
                if (isNewItem)
                {
                    responseMessage = await _cliente.PostAsync(RutaFormateada, content);
                }

                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tArticulo agregado correctamente.");
                }
            }
            catch
            {
                throw;
            }
        }
    }

   
}
