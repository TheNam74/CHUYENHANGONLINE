using System;

namespace CHUYENHANGONLINE
{
    public class Order
    {
        public int OrdID { get; set; }
        public string Payments { get; set; }
        public int ShipCost { get; set; }
        public int TotalBill { get; set; }
        public string ShipAddress { get; set; }
        public string Status { get; set; }
        public int? ShipID { get; set; }
        public int CusID { get; set; }
        public DateTime? CreDate { get; set; }
        public DateTime? ShipDate { get; set; }
    }
}
