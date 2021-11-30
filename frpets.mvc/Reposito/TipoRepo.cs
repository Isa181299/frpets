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
    public class TipoRepo
    {
        public static async Task<IEnumerable<TipoVM>> GetTipAsync()
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:1030/api/Customer/GetCustomers");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var tipo = JsonConvert.DeserializeObject<IEnumerable<TipoVM>>(apiResponse);
            return tipo;

        }

        public static async Task<TipoVM> GetTipo(int id)
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:1030/api/Customer/GetCustomerById/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var tipo = JsonConvert.DeserializeObject<TipoVM>(apiResponse);
            return tipo;

        }

        public static async Task<bool> Insert(TipoVM tipo)
        {


            var json = JsonConvert.SerializeObject(tipo);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:1030/api/Customer/PostCustomer", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var tipoResponse = JsonConvert.DeserializeObject<int>(apiResponse);
            return (tipoResponse == 0 ? false : true);

        }


        public static async Task<bool> Update(TipoVM tipo)
        {


            var json = JsonConvert.SerializeObject(tipo);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PutAsync("http://localhost:1030/api/Customer/PutCustomer", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var tipoResponse = JsonConvert.DeserializeObject<int>(apiResponse);
            return (tipoResponse == 0 ? false : true);

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
