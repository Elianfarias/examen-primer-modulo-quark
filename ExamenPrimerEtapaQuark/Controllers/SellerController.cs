using ExamenPrimerEtapaQuark.Models;

namespace ExamenPrimerEtapaQuark.Controllers
{
    public class SellerController
    {
        private readonly Seller seller;

        public SellerController()
        {
            seller = new Seller("QuarkModuloA", "Elian", "Farias");
        }

        public Seller GetSeller()
        {
            return seller;
        }
    }
}
