using System.Collections.Generic;

namespace ExamenPrimerEtapaQuark.Models
{
    public class Shop
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Product> Products { get; set; }

        public Shop()
        {
            ID = 0;
            Name = "Lanús Shop";
            Address = "9 de julio 123";
        }
    }
}
