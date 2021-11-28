/* using Microsoft.AspNetCore.Mvc;
using crystalClean.Models;

namespace crystalClean.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    [HttpGet(Name = "GetClients")]
    public IEnumerable<Client> GetClients()
    {
        using (var db = new CrystalCleanContext())
        {
            List<Client> clients = db.Clients.ToList();
            return clients.ToArray();

        }
        // return Enumerable.Range(1, 5).Select(index => new Client
        // {
        //     guid = Guid.NewGuid(),
        //     name = "New Client",
        //     email = "client@gmail.com",
        //     phone = "91929392",
        //     notes = "Good Customer",
        //     rating = "5"

        // })
        // .ToArray();
    }

    [HttpGet("{clientGuid}", Name = "GetById")]
    public Client GetById(Guid clientGuid)
    {
        using (var db = new CrystalCleanContext())
        {
            var client = db.Clients
                    .First(client => client.Id == clientGuid);
            return client;
        }

    } 
}*/