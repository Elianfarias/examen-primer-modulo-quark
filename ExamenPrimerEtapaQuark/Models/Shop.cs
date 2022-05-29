using System.Collections.Generic;

namespace ExamenPrimerEtapaQuark.Models
{
    public class Shop
    {
        private string Name { get; }
        private string Address { get; }
        private List<Product> Products { get; }

        public Shop(List<Product> products)
        {
            Name = "Lanús Shop";
            Address = "9 de julio 123";
            Products = products;
        }

        public List<Product> GetProducts() => this.Products;
        public string GetName() => this.Name;
        public string GetAddress() => this.Address;
    }
}
