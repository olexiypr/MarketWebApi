namespace Business.Dto
{
    public class CustomerActivityModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal ReceiptSum { get; set; }
    }
}