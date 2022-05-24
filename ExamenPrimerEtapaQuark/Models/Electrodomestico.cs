using ExamenPrimerEtapaQuark.Models.Enum;

namespace ExamenPrimerEtapaQuark.Models
{
    public class Electrodomestico
    {
        protected float PrecioBase { get; }
        protected Color Color { get; }
        protected bool ConsumoEnergetico { get; }
        protected float Peso { get; }

        public Electrodomestico()
        {
            this.PrecioBase = 100;
            this.Color = Color.blanco;
            this.ConsumoEnergetico = false;
            this.Peso = 5;
        }

        public Electrodomestico(float precio, float peso)
        {
            this.PrecioBase = precio;
            this.Peso = peso;
        }

        public Electrodomestico(float precio, Color color, bool consumoEnergetico, float peso)
        {
            this.PrecioBase = precio;
            this.Color = color;
            this.ConsumoEnergetico = consumoEnergetico;
            this.Peso = peso;
        }
    }
}
