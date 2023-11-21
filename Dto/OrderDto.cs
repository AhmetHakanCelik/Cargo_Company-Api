
namespace CargoCompany.Dto
{
    public class OrderDto<T>
    {
        public int OrderDesi { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderCarrierCost { get; set; }
    }
}