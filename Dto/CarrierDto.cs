namespace CargoCompany.Dto
{
    public class CarrierDto<T>
    {
        public string? CarrierName { get; set; }
        public int CarrierPlusDesiCost { get; set; }
        public int CarrierConfigurationId { get; set; }

    }
}