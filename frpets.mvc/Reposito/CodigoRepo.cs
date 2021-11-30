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
    public class CodigoRepo
    {
        public static async Task<IEnumerable<CodigoVM>> GetCodigAsync()
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:1030/api/Customer/GetCustomers");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var codigo = JsonConvert.DeserializeObject<IEnumerable<CodigoVM>>(apiResponse);
            return codigo;

        }

        public static async Task<CodigoVM> GetCodigo(int id)
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:1030/api/Customer/GetCustomerById/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var codigo = JsonConvert.DeserializeObject<CodigoVM>(apiResponse);
            return codigo;

        }

        public static async Task<bool> Insert(CodigoVM codigo)
        {


            var json = JsonConvert.SerializeObject(codigo);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:1030/api/Customer/PostCustomer", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var codigoResponse = JsonConvert.DeserializeObject<int>(apiResponse);
            return (codigoResponse == 0 ? false : true);

        }


        public static async Task<bool> Update(CodigoVM codigo)
        {
            var json = JsonConvert.SerializeObject(codigo);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PutAsync("http://localhost:1030/api/Customer/PutCustomer", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var codigoResponse = JsonConvert.DeserializeObject<int>(apiResponse);
            return (codigoResponse == 0 ? false : true);

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
