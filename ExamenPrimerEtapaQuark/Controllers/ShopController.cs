using ExamenPrimerEtapaQuark.Models;
using ExamenPrimerEtapaQuark.Models.Enum;
using System.Collections.Generic;

namespace ExamenPrimerEtapaQuark.Controllers
{
    public class ShopController
    {
        private readonly Shop shop;
        private Product product;
        public ShopController()
        {
            shop = new Shop
            {
                Products = InitializeProducts()
            };
        }

        public Shop GetShop()
        {
            return shop;
        }

        public Product GetProduct()
        {
            return product;
        }

        public string GetStock()
        {
            return product.GetStock().ToString();
        }

        public void SetProductsSelected(bool isShirt, PantType? pantType, NeckType? neckType, SleeveType? sleeveType, Quality quality)
        {
            if (isShirt)
            {
                foreach (var product in shop.Products)
                {
                    if (product is Shirt shirt)
                    {
                        if (shirt.NeckType == neckType && shirt.SleeveType == sleeveType && product.Quality == quality)
                        {
                            this.product = product;
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (var product in shop.Products)
                {
                    if(product is Pant pant)
                    {
                        if (pant.Type == pantType && product.Quality == quality)
                        {
                            this.product = product;
                            break;
                        }
                    }
                }
            }
        }

        private List<Product> InitializeProducts()
        {
            var products = new List<Product>
            {
                new Shirt(SleeveType.Corto, NeckType.Mao, 100, Quality.Premium),
                new Shirt(SleeveType.Corto, NeckType.Mao, 100, Quality.Estándar),
                new Shirt(SleeveType.Corto, NeckType.Común, 150, Quality.Premium),
                new Shirt(SleeveType.Corto, NeckType.Común, 150, Quality.Estándar),
                new Shirt(SleeveType.Largo, NeckType.Mao, 75, Quality.Premium),
                new Shirt(SleeveType.Largo, NeckType.Mao, 75, Quality.Estándar),
                new Shirt(SleeveType.Largo, NeckType.Común, 175, Quality.Premium),
                new Shirt(SleeveType.Largo, NeckType.Común, 175, Quality.Estándar),
                new Pant(PantType.Chupín, 750, Quality.Premium),
                new Pant(PantType.Chupín, 750, Quality.Estándar),
                new Pant(PantType.Común, 250, Quality.Premium),
                new Pant(PantType.Común, 250, Quality.Estándar)
            };

            return products;
        }
    }
}
