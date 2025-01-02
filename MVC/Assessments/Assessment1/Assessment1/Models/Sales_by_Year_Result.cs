namespace Assessment1.Models
{
    using System;

    public partial class Sales_by_Year_Result
    {
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public int OrderID { get; set; }
        public Nullable<decimal> Subtotal { get; set; }
        public string Year { get; set; }
    }
}