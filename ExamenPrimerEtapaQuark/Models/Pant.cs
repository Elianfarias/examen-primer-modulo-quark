using ExamenPrimerEtapaQuark.Models.Enum;

namespace ExamenPrimerEtapaQuark.Models
{
    public class Pant : Product
    {
        public PantType Type { get; }

        public Pant(PantType type, int stock, Quality quality) : base(stock, quality)
        {
            Type = type;
        }

        public override double GetFinalPrice()
        {
            var finalPrice = GetPrice();

            if (Type == PantType.Chupín)
                finalPrice -= finalPrice * 0.12;

            if (Quality == Quality.Premium)
                finalPrice += finalPrice * 0.3;

            return finalPrice;
        }
    }
}
