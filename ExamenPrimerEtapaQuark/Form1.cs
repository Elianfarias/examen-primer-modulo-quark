using ExamenPrimerEtapaQuark.Controllers;
using ExamenPrimerEtapaQuark.Models;
using ExamenPrimerEtapaQuark.Models.Enum;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace ExamenPrimerEtapaQuark
{
    public partial class Form1 : Form
    {
        private ShopController shopController;
        private SellerController sellerController;
        private QuotationController quotationController;
        private Shop shop;
        private Seller seller;
        private Quotation quotation;
        private NeckType neckType = NeckType.Común;
        private SleeveType sleeveType = SleeveType.Largo;
        private PantType pantType = PantType.Común;
        private Quality quality = Quality.Estándar;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            shopController = new ShopController();
            sellerController = new SellerController();
            quotationController = new QuotationController();

            shop = shopController.GetShop();
            seller = sellerController.GetSeller();
            shopController.SetProductsSelected(isShirt: shirtRadioBtn.Checked, neckType: neckType, sleeveType: sleeveType, pantType: pantType, quality: quality);

            shopNameLabel.Text = shop.Name;
            shopAdressLabel.Text = shop.Address;
            sellerNameLabel.Text = seller.Name + " " + seller.Surname;
            totalPriceLabel.Text = "";
            quotationBtn.Enabled = false;
            stockLabel.Text = shopController.GetStock();
        }

        private void quoteBtn_Click(object sender, EventArgs e)
        {
            double.TryParse(priceTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double finalPrice);

            if (int.Parse(quantityTextBox.Text) > int.Parse(stockLabel.Text))
                MessageBox.Show("No hay suficiente stock para realizar la cotizacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                quotationController.Quote(DateTime.Now, seller.GetSellerCode(), int.Parse(quantityTextBox.Text), ref finalPrice, shopController.GetProduct());
                totalPriceLabel.Text = finalPrice.ToString();
                MessageBox.Show("Producto cotizado con exito.", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void shirtRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
                shortSleeveCheckBox.Enabled = true;
                maoNeckCheckBox.Enabled = true;
                skinnyCheckBox.Enabled = false;
                skinnyCheckBox.Checked = false;
                neckType = maoNeckCheckBox.Checked ? NeckType.Mao : NeckType.Común;
                sleeveType = shortSleeveCheckBox.Checked ? SleeveType.Corto : SleeveType.Largo;

                shopController.SetProductsSelected(isShirt: shirtRadioBtn.Checked, neckType: neckType, sleeveType: sleeveType, pantType: pantType, quality: quality);
                stockLabel.Text = shopController.GetStock();
        }

        private void pantRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
                shortSleeveCheckBox.Enabled = false;
                maoNeckCheckBox.Enabled = false;
                shortSleeveCheckBox.Checked = false;
                maoNeckCheckBox.Checked = false;
                skinnyCheckBox.Enabled = true;
        }

        private void premiumRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            quality = premiumRadioBtn.Checked ? Quality.Premium : Quality.Estándar;

            shopController.SetProductsSelected(isShirt: shirtRadioBtn.Checked, pantType: pantType, neckType: neckType, sleeveType: sleeveType, quality: quality);
            stockLabel.Text = shopController.GetStock();
        }

        private void shortSleeveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            sleeveType = shortSleeveCheckBox.Checked ? SleeveType.Corto : SleeveType.Largo;

            shopController.SetProductsSelected(isShirt: true, neckType: neckType, sleeveType: sleeveType, pantType: null, quality: quality);
            stockLabel.Text = shopController.GetStock();
        }

        private void maoNeckCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            neckType = maoNeckCheckBox.Checked ? NeckType.Mao : NeckType.Común;

            shopController.SetProductsSelected(isShirt: true, neckType: neckType, sleeveType: sleeveType, pantType: null, quality: quality);
            stockLabel.Text = shopController.GetStock();
        }

        private void skinnyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pantType = skinnyCheckBox.Checked ? PantType.Chupín : PantType.Común;

            shopController.SetProductsSelected(isShirt: shirtRadioBtn.Checked, pantType: pantType, neckType: neckType, sleeveType: sleeveType, quality: quality);
            stockLabel.Text = shopController.GetStock();
        }

        private void historyLabel_Click(object sender, EventArgs e)
        {
            string quotationMessage = quotationController.GetHistorial();

            MessageBox.Show(quotationMessage);
        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
            else if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private void quantityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void priceTextBox_TextChanged(object sender, EventArgs e)
        {
            quotationBtn.Enabled = priceTextBox.Text != "" && quantityTextBox.Text != "";
        }

        private void quantityTextBox_TextChanged(object sender, EventArgs e)
        {
            quotationBtn.Enabled = priceTextBox.Text != "" && quantityTextBox.Text != "";
        }
    }
}
