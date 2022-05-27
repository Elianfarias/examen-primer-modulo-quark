namespace ExamenPrimerEtapaQuark.Models
{
    public class Seller
    {
        private string SellerCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Seller(string sellerCode, string name, string surname)
        {
            SellerCode = sellerCode;
            Name = name;
            Surname = surname; 
        }

        public string GetSellerCode() => SellerCode;
    }
}
