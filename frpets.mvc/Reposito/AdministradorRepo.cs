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
    public class AdministradorRepo
    {
        public static async Task<IEnumerable<AdministradorVM>> GetAdministradorAsync()
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:33710/api/Administrador/GetAdministradores");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var Administrado = JsonConvert.DeserializeObject<IEnumerable<AdministradorVM>>(apiResponse);
            return Administrado;

        }

        public static async Task<AdministradorVM> GetAdministrador(int id)
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:33710/api/Administrador/GetAdministradoresById/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var Administrador = JsonConvert.DeserializeObject<AdministradorVM>(apiResponse);
            return Administrador;

        }

        public static async Task<bool> Insert(AdministradorVM Administrador)
        {


            var json = JsonConvert.SerializeObject(Administrador);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:1030/api/Customer/PostCustomer", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var AdministradorResponse = JsonConvert.DeserializeObject<int>(apiResponse);
            return (AdministradorResponse == 0 ? false : true);

        }


        public static async Task<bool> Update(AdministradorVM Administrador)
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
