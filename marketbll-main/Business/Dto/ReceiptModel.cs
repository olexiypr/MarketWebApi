using System;
using System.Collections.Generic;

namespace Business.Dto
{
    public class ReceiptModel : BaseModel
    {
        public int CustomerId { get; set; }
        public DateTime OperationDate { get; set; }
        public bool IsCheckedOut { get; set; }
        public ICollection<int> ReceiptDetailsId { get; set; }
    }
}