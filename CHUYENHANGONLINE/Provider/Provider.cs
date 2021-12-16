using System;

namespace CHUYENHANGONLINE.Provider
{
    public class Provider : IUser
    {
        public int Id { get; set; }
        public int LoginId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public string TaxCode { get; set; }
        public string Represent { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public DateTime ContractDate { get; set; }
        public int OrderAmount { get; set; }
        public string ProductType { get; set; }
        public int BranchAmount { get; set; }
        public float Commission { get; set; }

    }
}
