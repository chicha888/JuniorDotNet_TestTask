using JuniorDotNet_TestTask.DTOs;
using JuniorDotNet_TestTask.Interfaces;
using JuniorDotNet_TestTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JuniorDotNet_TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentContractController : ControllerBase
    {
        private readonly IEquipmentContractRepository _equipmentContractRepository;

        public EquipmentContractController(IEquipmentContractRepository equipmentContractRepository)
        {
            _equipmentContractRepository = equipmentContractRepository;
        }


        // Handles the creation of a new contract based on the data provided in the request body.
        // Validates the model state, checks if the production facility and equipment type exist,
        // and ensures there is enough available area in the facility to accommodate the equipment.
        // Returns appropriate responses based on the validation results.
        [HttpPost]
        public async Task<IActionResult> CreateContract([FromBody] CreateContractDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var facility = await _equipmentContractRepository.GetProductionFacilityByCodeAsync(dto.ProductionFacilityCode);
            if (facility == null)
            {
                return NotFound($"Production facility with code {dto.ProductionFacilityCode} not found.");
            }

            var equipmentType = await _equipmentContractRepository.GetProcessEquipmentTypeByCodeAsync(dto.EquipmentTypeCode);
            if (equipmentType == null)
            {
                return NotFound($"Equipment type with code {dto.EquipmentTypeCode} not found.");
            }

            double requiredArea = equipmentType.Area * dto.EquipmentQuantity;
            double usedArea = await _equipmentContractRepository.GetUsedAreaForFacilityAsync(facility.Id);

            if (requiredArea + usedArea > facility.StandardArea)
            {
                return BadRequest("Not enough available area in the production facility.");
            }

            var contract = new EquipmentPlacementContract
            {
                ProductionFacilityId = facility.Id,
                ProcessEquipmentTypeId = equipmentType.Id,
                EquipmentQuantity = dto.EquipmentQuantity
            };

            var res = await _equipmentContractRepository.CreateAsync(contract);
            return Ok(contract);
        }

        // Retrieves all contracts and returns a simplified view with facility names, equipment types, and quantities.
        [HttpGet]
        public async Task<IActionResult> GetContracts()
        {
            var contracts = await _equipmentContractRepository.GetAllContractsAsync();
            return Ok(contracts.Select(c => new
            {
                FacilityName = c.ProductionFacility.Name,
                EquipmentType = c.ProcessEquipmentType.Name,
                Quantity = c.EquipmentQuantity
            }));
        }
    }
}
