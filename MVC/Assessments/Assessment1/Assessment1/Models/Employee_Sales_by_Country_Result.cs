
namespace Assessment1.Models
{
    using System;

    public partial class Employee_Sales_by_Country_Result
    {
        public string Country { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public int OrderID { get; set; }
        public Nullable<decimal> SaleAmount { get; set; }
    }
}