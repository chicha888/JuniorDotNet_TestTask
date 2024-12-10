using JuniorDotNet_TestTask.Models;

namespace JuniorDotNet_TestTask.Interfaces
{
    public interface IEquipmentContractRepository
    {
        Task<List<EquipmentPlacementContract>> GetAllContractsAsync();
        Task<EquipmentPlacementContract> CreateAsync(EquipmentPlacementContract contract);
        Task<ProductionFacility?> GetProductionFacilityByCodeAsync(string code);
        Task<ProcessEquipmentType?> GetProcessEquipmentTypeByCodeAsync(string code);
        Task<double> GetUsedAreaForFacilityAsync(int facilityId);
    }
}
