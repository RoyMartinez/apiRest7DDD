using Domain.Dtos.Client;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            var clients = await _clientRepository.GetAllAsync(pageSize, pageNumber);
            var clientDTOs = MapClientsToDTOs(clients.ToList());
            return Ok(clientDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(Guid id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
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
            _clientRepository.Create(client);
            _clientRepository.SaveChanges();

            return CreatedAtAction("GetClient", new { id = client.Id }, clientDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, [FromBody] ClientDto clientDTO)
        {
            if (clientDTO == null)
            {
                return BadRequest();
            }

            var existingClient = await _clientRepository.GetByIdAsync(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            existingClient.Name = clientDTO.Name;
            _clientRepository.Update(existingClient);

            _clientRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _clientRepository.Delete(client);

            _clientRepository.SaveChanges();
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
