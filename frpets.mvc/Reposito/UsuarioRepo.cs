using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using frpets.mvc.ViewModels;
using Newtonsoft.Json;

namespace frpets.mvc.Reposito
{
    public class UsuarioRepo
    {
        public static async Task<IEnumerable<UsuarioVM>> GetUsuariAsync()
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:1030/api/Customer/GetCustomers");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var usuari = JsonConvert.DeserializeObject<IEnumerable<UsuarioVM>>(apiResponse);
            return usuari;

        }

        public static async Task<UsuarioVM> GetUsuario(int id)
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:1030/api/Customer/GetCustomerById/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<UsuarioVM>(apiResponse);
            return usuario;

        }

        public static async Task<bool> Insert(UsuarioVM usuario)
        {


            var json = JsonConvert.SerializeObject(usuario);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:1030/api/Customer/PostCustomer", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var usuarioResponse = JsonConvert.DeserializeObject<int>(apiResponse);
            return (usuarioResponse == 0 ? false : true);

        }


        public static async Task<bool> Update(UsuarioVM usuario)
        {


            var json = JsonConvert.SerializeObject(usuario);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PutAsync("http://localhost:1030/api/Customer/PutCustomer", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var usuarioResponse = JsonConvert.DeserializeObject<int>(apiResponse);
            return (usuarioResponse == 0 ? false : true);

        }

        public static async Task<bool> Delete(int id)
        {


            using var httpClient = new HttpClient();
            using var response = await httpClient
               .DeleteAsync("http://localhost:1030/api/Customer/DeleteCustomer?id=" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            if ((int)response.StatusCode == 404)
                return false;

            return true;
        }
    }
}
