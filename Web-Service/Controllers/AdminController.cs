using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Web_Service.Models;

namespace Web_Service.Controllers
{
    public class AdminController : Controller
    {
        //Main panel with clients info
        public async Task<IActionResult> Index()
        {
            using(HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://localhost:7245/api/Clients");
                response.EnsureSuccessStatusCode();

                var text = await response.Content.ReadAsStringAsync();
                var clients = JsonConvert.DeserializeObject<List<Client>>(text);

                return View(clients?.ToList());
            }
        }

        #region Delete client's info
        public async Task<IActionResult> DeleteClient(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                await httpClient.DeleteAsync("https://localhost:7245/api/Clients/" + id);
                return RedirectToAction("Index");
            }
        }

        #endregion


        #region Edit client's info

        public async Task<IActionResult> EditExactClient(Client client)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                var newClient = new Client(client.Name, client.Email, client.Message);

                var newClientJson = JsonConvert.SerializeObject(newClient);
                var payload = new StringContent(newClientJson,
                                  Encoding.UTF8, "application/json");

                await httpClient.PutAsync("https://localhost:7245/api/Clients/" +
                                          client.Id, payload);

                return RedirectToAction("Index");
            }
        }


        public async Task<IActionResult> EditPanel(int id)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync
                    ("https://localhost:7245/api/Clients/" + id);
                response.EnsureSuccessStatusCode();

                var text = await response.Content.ReadAsStringAsync();
                var client = JsonConvert.DeserializeObject<Client>(text);
                return View(client);
            }  
        }

        #endregion

    }
}
