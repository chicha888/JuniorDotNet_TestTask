namespace JuniorDotNet_TestTask.DTOs
{
    public class CreateContractDto
    {
        public string ProductionFacilityCode { get; set; } = string.Empty;
        public string EquipmentTypeCode { get; set; } = string.Empty;
        public int EquipmentQuantity { get; set; }
    }
}
