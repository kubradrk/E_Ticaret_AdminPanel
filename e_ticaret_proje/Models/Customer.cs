namespace e_ticaret_proje.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public List<Order> Orders { get; set; }
    }
}
