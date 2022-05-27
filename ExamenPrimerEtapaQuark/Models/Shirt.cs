using ExamenPrimerEtapaQuark.Models.Enum;

namespace ExamenPrimerEtapaQuark.Models
{
    public class Shirt : Product
    {
        public SleeveType SleeveType { get; set; }
        public NeckType NeckType { get; set; }

        public Shirt(SleeveType sleeveType, NeckType neckType, int stock, Quality quality) : base(stock, quality)
        {
            NeckType = neckType;
            SleeveType = sleeveType;
        }

        public override double GetFinalPrice()
        {
            var finalPrice = Price;

            if (SleeveType == SleeveType.Corto)
                finalPrice -= finalPrice * 0.1;

            if (NeckType == NeckType.Mao)
                finalPrice += finalPrice * 0.03;

            if (Quality == Quality.Premium)
                finalPrice += finalPrice * 0.3;

            return finalPrice;
        }
    }
}
