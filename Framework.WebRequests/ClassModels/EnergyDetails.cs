namespace Framework.WebRequests.ClassModels
{
    public class EnergyDetails
    {
        public int energy_id { get; set; }
        public decimal price_per_unit { get; set; }
        public int quantity_of_units { get; set; }
        public string unit_type { get; set; }
    }
}
