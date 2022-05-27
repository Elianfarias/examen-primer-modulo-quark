using ExamenPrimerEtapaQuark.Models.Enum;

namespace ExamenPrimerEtapaQuark.Models
{
    public abstract class Product
    {
        public double Price { get; set; }
        private int Stock { get; set; }
        public Quality Quality { get; set; }

        public Product(int stock, Quality quality)
        {
            Stock = stock;
            Price = 0;
            Quality = quality;
        }

        public int GetStock()
        {
            return Stock;
        }

        public abstract double GetFinalPrice();
    }
}
