using ExamenPrimerEtapaQuark.Models.Enum;

namespace ExamenPrimerEtapaQuark.Models
{
    public abstract class Product
    {
        private double Price { get; set; }
        private int Stock { get; }
        public Quality Quality { get; }

        public Product(int stock, Quality quality)
        {
            Stock = stock;
            Price = 0;
            Quality = quality;
        }

        public int GetStock() => Stock;
        public double GetPrice() => Price;
        public void SetPrice(double price) => Price = price;
        public abstract double GetFinalPrice();
    }
}
