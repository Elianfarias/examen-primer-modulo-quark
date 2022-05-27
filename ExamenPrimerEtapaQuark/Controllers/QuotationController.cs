using ExamenPrimerEtapaQuark.Models;
using System;
using System.Collections.Generic;

namespace ExamenPrimerEtapaQuark.Controllers
{
    public class QuotationController
    {
        private static List<Quotation> quotations;

        public QuotationController()
        {
            quotations = new List<Quotation>();
        }

        public void Quote(DateTime quotationDate, string sellerCode, int productQuantity, ref double price, Product product)
        {
            product.Price = price;
            price = product.GetFinalPrice() * productQuantity;
            var quotation = new Quotation(quotationDate, sellerCode, productQuantity, price, product);

            quotations.Add(quotation);
        }

        public string GetHistorial()
        {
            var message = "Historial de cotizaciones \n";

            foreach (var quotation in quotations)
            {
                message += quotation.Print();
            }

            return message;
        }
    }
}
