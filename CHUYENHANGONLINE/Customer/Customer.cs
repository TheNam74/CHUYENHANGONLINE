namespace CHUYENHANGONLINE.Customer
{
    public class Customer : IUser
    {
        public int Id { get; set; }
        public int LoginId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
    }
}
