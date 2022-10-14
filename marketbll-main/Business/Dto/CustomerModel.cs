using System;
using System.Collections.Generic;
using System.Globalization;
using Data.Entities;

namespace Business.Dto
{
    public class CustomerModel : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int DiscountValue { get; set; }
        private ICollection<int> ReceiptsId { get; set; }
    }
}