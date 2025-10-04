namespace e_ticaret_proje.Models
{
    public class OrderStatus
    {
        public int OrderStatusID { get; set; }
        public string StatusName { get; set; }

        public List<Order> Orders { get; set; }
    }
}
