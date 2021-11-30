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
    public class PublicacionRepo
    {
        public static async Task<IEnumerable<PublicacionVM>> GetPublicacioAsync()
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:1030/api/Customer/GetCustomers");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var publicacion = JsonConvert.DeserializeObject<IEnumerable<PublicacionVM>>(apiResponse);
            return publicacion;

        }

        public static async Task<PublicacionVM> GetPublicacion(int id)
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:1030/api/Customer/GetCustomerById/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var publicacion = JsonConvert.DeserializeObject<PublicacionVM>(apiResponse);
            return publicacion;

        }

        public static async Task<bool> Insert(PublicacionVM publicacion)
        {


            var json = JsonConvert.SerializeObject(publicacion);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:1030/api/Customer/PostCustomer", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var publicacionResponse = JsonConvert.DeserializeObject<int>(apiResponse);
            return (publicacionResponse == 0 ? false : true);

        }


        public static async Task<bool> Update(PublicacionVM publicacion)
        {


            var json = JsonConvert.SerializeObject(publicacion);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PutAsync("http://localhost:1030/api/Customer/PutCustomer", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var publicacionResponse = JsonConvert.DeserializeObject<int>(apiResponse);
            return (publicacionResponse == 0 ? false : true);

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
