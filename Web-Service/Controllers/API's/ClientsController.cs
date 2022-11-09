using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Web_Service.Models;

namespace Web_Service.Controllers.API_s
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        #region Context injection
        private ContentDbContext context;


        public ClientsController(ContentDbContext Context)
        {
            context = Context;
        }

        #endregion

        #region Get Methods

        // GET: api/<ClientsController>
        [HttpGet]
        public List<Client>? Get()
        {
            if (context.Clients != null)
                return context.Clients.ToList();
            else
                return null;
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public Client? Get(int id)
        {
            if (context.Clients != null)
            {
                var client = context.Clients.Where(c => c.Id == id).FirstOrDefault();
                return client;
            }
            else
                return null;
        }

        #endregion

        #region Post Method

        // POST api/<ClientsController>
        [HttpPost]
        public void Post(Client client)
        {
            if (context.Clients != null)
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }

        #endregion

        #region Put Method

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public void Put(int id, Client client)
        {
            if(context.Clients != null)
            {
               var neededClient = context.Clients.Where(c => c.Id == id).FirstOrDefault();

               context.Clients.Remove(neededClient);
               context.Clients.Add(client);
               context.SaveChanges();
            }

        }

        #endregion

        #region Delete Method
        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if(context.Clients != null)
            {
              var client = context.Clients.Where(c => c.Id == id).ToList().FirstOrDefault();
                context.Clients.Remove(client);
                context.SaveChanges();
            }
        }

        #endregion
    }
}
