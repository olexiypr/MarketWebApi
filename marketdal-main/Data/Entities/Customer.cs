using System.Collections.Generic;

namespace Data.Entities
{
    public class Customer : BaseEntity
    {
        public int PersonId { get; set; }
        public int DiscountValue { get; set; }
        public Person Person { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
    }
}