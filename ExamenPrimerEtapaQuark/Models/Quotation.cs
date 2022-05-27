
using ExamenPrimerEtapaQuark.Controllers.Interfaces;
using System;
using System.Threading;

namespace ExamenPrimerEtapaQuark.Models
{
    public class Quotation : IPrintable
    {
        static int NextId;
        private int Id { get; set; }
        private DateTime QuotationDate { get; set; }
        private string SellerCode { get; set; }
        private int ProductQuantity { get; set; }
        private double TotalPrice { get; set; }
        private Product Product { get; set; }

        public Quotation(DateTime quotationDate, string sellerCode, int productQuantity, double totalPrice, Product product)
        {
            Id = Interlocked.Increment(ref NextId);
            QuotationDate = quotationDate;
            SellerCode = sellerCode;
            ProductQuantity = productQuantity;
            TotalPrice = totalPrice;
            Product = product;
        }
         
        public string Print()
        {
            string quoteMessage = "";

            if (this.Product is Shirt shirt)
            {
                quoteMessage = ("***************************************\n"
                                  + "Id: " + this.Id + "\n"
                                  + "Fecha: " + this.QuotationDate + "\n"
                                  + "Codigo de vendedor: " + this.SellerCode + "\n"
                                  + "Producto: Camisa\n"
                                  + "Calidad de producto: " + shirt.Quality.ToString() + "\n"
                                  + "Tipo de manga: " + shirt.SleeveType.ToString() + "\n"
                                  + "Tipo de cuello: " + shirt.NeckType.ToString() + "\n"
                                  + "Cantidad: " + this.ProductQuantity + "\n"
                                  + "Precio cotizado: " + this.TotalPrice + "\n");
            }
            else if (this.Product is Pant pant)
            {
                quoteMessage = ("***************************************\n"
                                  + "Id: " + this.Id + "\n"
                                  + "Fecha: " + this.QuotationDate + "\n"
                                  + "Codigo de vendedor: " + this.SellerCode + "\n"
                                  + "Producto: Pantalón\n"
                                  + "Calidad de producto: " + pant.Quality.ToString() + "\n"
                                  + "Tipo de pantalón: " + pant.Type.ToString() + "\n"
                                  + "Cantidad: " + this.ProductQuantity + "\n"
                                  + "Precio cotizado: " + this.TotalPrice + "\n");
            }

            return quoteMessage;
        }
    }
}
