using JuniorDotNet_TestTask.Data;
using JuniorDotNet_TestTask.Interfaces;
using JuniorDotNet_TestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace JuniorDotNet_TestTask.Repositories
{
    public class EquipmentContractRepository : IEquipmentContractRepository
    {
        private readonly AppDbContext _context;

        public EquipmentContractRepository(AppDbContext context)
        {
            _context = context;   
        }


        // Creates a new EquipmentPlacementContract record in the database
        // and saves the changes asynchronously.
        public async Task<EquipmentPlacementContract> CreateAsync(EquipmentPlacementContract contract)
        {
            await _context.EquipmentPlacementContracts.AddAsync(contract);
            await _context.SaveChangesAsync();
            return contract;
        }

        // Retrieves all EquipmentPlacementContract records from the database,
        // including related ProductionFacility and ProcessEquipmentType data, 
        // and returns them as a list.
        public async Task<List<EquipmentPlacementContract>> GetAllContractsAsync()
        {
            var contracts = await _context.EquipmentPlacementContracts
            .Include(c => c.ProductionFacility)
            .Include(c => c.ProcessEquipmentType)
            .ToListAsync();

            return contracts;
        }


        // Retrieves a ProductionFacility record based on the provided code.
        // Returns null if no matching facility is found.
        public async Task<ProductionFacility?> GetProductionFacilityByCodeAsync(string code)
        {
            return await _context.ProductionFacilities.FirstOrDefaultAsync(f => f.Code == code);
        }

        // Retrieves a ProcessEquipmentType record based on the provided code.
        // Returns null if no matching equipment type is found.
        public async Task<ProcessEquipmentType?> GetProcessEquipmentTypeByCodeAsync(string code)
        {
            return await _context.ProcessEquipmentTypes.FirstOrDefaultAsync(e => e.Code == code);
        }

        // Calculates and returns the total used area for a specific facility,
        // based on the EquipmentPlacementContracts associated with the facility.
        public async Task<double> GetUsedAreaForFacilityAsync(int facilityId)
        {
            return await _context.EquipmentPlacementContracts
                .Where(c => c.ProductionFacilityId == facilityId)
                .SumAsync(c => c.ProcessEquipmentType.Area * c.EquipmentQuantity);
        }

    }
}
