namespace ExamenPrimerEtapaQuark.Models
{
    public class Seller
    {
        private string SellerCode { get; }
        private string Name { get; }
        private string Surname { get; }

        public Seller(string sellerCode, string name, string surname)
        {
            SellerCode = sellerCode;
            Name = name;
            Surname = surname; 
        }

        public string GetSellerCode() => SellerCode;
        public string GetName() => Name;
        public string GetSurname() => Surname;
    }
}
