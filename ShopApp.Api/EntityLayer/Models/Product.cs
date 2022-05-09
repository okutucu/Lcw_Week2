namespace ShopApp.Api.EntityLayer.Models
{
    public class Product :BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public int? CategoryID { get; set; }

        //Relational Properties
        public virtual Category Category { get; set; }
        
    }
}
