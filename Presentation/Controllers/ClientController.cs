using Domain.Dtos.Client;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IEntityFrameworkClientRepository _client;

        public ClientController(IEntityFrameworkClientRepository clientRepository)
        {
            _client = clientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            var clients = await _client.GetAllAsync(pageSize, pageNumber);
            var clientDTOs = MapClientsToDTOs(clients.ToList());
            return Ok(clientDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(Guid id)
        {
            var client = await _client.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            var clientDTO = MapClientToDTO(client);
            return Ok(clientDTO);
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientDto clientDTO)
        {
            if (clientDTO == null)
            {
                return BadRequest();
            }

            var client = MapDTOToClient(clientDTO);
            _client.Create(client);
            _client.SaveChanges();

            return CreatedAtAction("GetClient", new { id = client.Id }, clientDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, [FromBody] ClientDto clientDTO)
        {
            if (clientDTO == null)
            {
                return BadRequest();
            }

            var existingClient = await _client.GetByIdAsync(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            existingClient.Name = clientDTO.Name;
            _client.Update(existingClient);

            _client.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            var client = await _client.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _client.Delete(client);

            _client.SaveChanges();
            return NoContent();
        }

        private ClientDto MapClientToDTO(Client client)
        {
            // Implementa la lógica para mapear Client a ClientDTO
            return new ClientDto();
        }

        private Client MapDTOToClient(ClientDto clientDTO)
        {
            // Implementa la lógica para mapear ClientDTO a Client
            return new Client();
        }

        private List<ClientDto> MapClientsToDTOs(IEnumerable<Client> clients)
        {
            // Implementa la lógica para mapear una lista de Client a una lista de ClientDTO
            return new List<ClientDto>();
        }
    }
}
