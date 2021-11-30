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
    public class AdoptarRepo
    {
        public static async Task<IEnumerable<AdoptarVM>> GetAdoptarAsync()
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:1030/api/Customer/GetCustomers");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var Adoptar = JsonConvert.DeserializeObject<IEnumerable<AdoptarVM>>(apiResponse);
            return Adoptar;

        }

        public static async Task<AdoptarVM> GetAdoptar(int id)
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:1030/api/Customer/GetCustomerById/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var Adoptar = JsonConvert.DeserializeObject<AdoptarVM>(apiResponse);
            return Adoptar;

        }

        public static async Task<bool> Insert(AdoptarVM Adoptar)
        {


            var json = JsonConvert.SerializeObject(Adoptar);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:1030/api/Customer/PostCustomer", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var AdoptarResponse = JsonConvert.DeserializeObject<int>(apiResponse);
            return (AdoptarResponse == 0 ? false : true);

        }


        public static async Task<bool> Update(AdoptarVM Administrador)
        {


            var json = JsonConvert.SerializeObject(Administrador);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PutAsync("http://localhost:1030/api/Customer/PutCustomer", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var AdministradorResponse = JsonConvert.DeserializeObject<int>(apiResponse);
            return (AdministradorResponse == 0 ? false : true);

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
