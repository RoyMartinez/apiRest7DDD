using Domain.Dtos.Client;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendorController : Controller
    {
        private readonly IDapperVendorRepository _vendor;
        public VendorController(IDapperVendorRepository vendor)
        {
            _vendor = vendor;
        }

        [HttpGet]
        public async Task<IActionResult> Getvendors([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            string query = string.Empty;
            var vendors = await _vendor.query(query);
            var vendorDTOs = MapvendorsToDTOs(vendors);
            return Ok(vendorDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(Guid id)
        {
            string query = string.Empty;
            Vendor vendor = ((List<Vendor>)await _vendor.query(query)).First();
            var vendorDTO = MapVendorToDTO(vendor);
            return Ok(vendorDTO);
        }

        [HttpPost]
        public async  Task<IActionResult> CreateClient([FromBody] VendorDto vendorDTO)
        {
            string command = string.Empty;
            string query = string.Empty;
            Vendor vendor = ((List<Vendor>)await _vendor.query(query)).First();
            _ = _vendor.command(command);
            return CreatedAtAction("GetClient", new { id = vendorDTO.Id }, vendorDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, [FromBody] VendorDto vendorDTO)
        {
            string command = string.Empty;
            string query = string.Empty;
            Vendor vendor = ((List<Vendor>)await _vendor.query(query)).First();
            _ = _vendor.command(command);
            return Ok("Vendor was sucesfully updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            string command = string.Empty;
            string query = string.Empty;
            Vendor vendor = ((List<Vendor>)await _vendor.query(query)).First();
            _ = _vendor.command(command);
            return NoContent();
        }

        private VendorDto MapVendorToDTO(Vendor client)
        {
            // Implementa la lógica para mapear Client a vendorDTO
            return new VendorDto();
        }

        private Vendor MapDTOToVendor(VendorDto vendorDTO)
        {
            // Implementa la lógica para mapear vendorDTO a Client
            return new Vendor() { EmployeeSerial =string.Empty, Name = string.Empty};
        }

        private List<VendorDto> MapvendorsToDTOs(IEnumerable<Vendor> vendors)
        {
            // Implementa la lógica para mapear una lista de Client a una lista de vendorDTO
            return new List<VendorDto>();
        }

    }
}
