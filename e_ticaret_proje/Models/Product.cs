namespace e_ticaret_proje.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<Order> Orders { get; set; }
    }
}
