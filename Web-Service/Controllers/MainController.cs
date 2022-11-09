using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web_Service.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Web_Service.Controllers
{
    public class MainController : Controller
    {
        
        
        public IActionResult Index()
        {
            Client client = new Client();
            return View(client);
        }

        public async Task<IActionResult> AddClient(Client client)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                var newClientJson = JsonConvert.SerializeObject(client);
                var payload = new StringContent(newClientJson, Encoding.UTF8,
                                                               "application/json");
                await httpClient.PostAsync("https://localhost:7245/api/Clients", payload);
            }

            return RedirectToAction("Index");
        }
    }
}
