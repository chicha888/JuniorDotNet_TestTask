using System.ComponentModel.DataAnnotations.Schema;

namespace JuniorDotNet_TestTask.Models
{
    public class EquipmentPlacementContract
    {
        public int Id { get; set; }

        [ForeignKey("ProductionFacility")]
        public int ProductionFacilityId { get; set; }
        public ProductionFacility ProductionFacility { get; set; } = null!;

        [ForeignKey("ProcessEquipmentType")]
        public int ProcessEquipmentTypeId { get; set; }
        public ProcessEquipmentType ProcessEquipmentType { get; set; } = null!;
        public int EquipmentQuantity { get; set; }
    }
}
