/*
 * Program Name: The Food Truck
 * How to use: User can add or take away items with the coresponse button under the image.
 *             When user is finish adding item, user can either press on the order button to get a total price for all the items
 *             or to clear all the added item with the clear button
 *             or to exit the application with the exit button
 */
using System;
using System.Windows.Forms;

namespace Food_Truck
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Disallowing resize
            this.MaximizeBox = false; // Disallowing maximize
        }

        // Method to add quantity of an item
        private void AddItem(TextBox textBox)
        {
            int quantity = int.Parse(textBox.Text);
            quantity += 1;
            textBox.Text = quantity.ToString();
        }

        // Method to minus quantity of an item
        private void MinusItem(TextBox textBox)
        {
            int quantity = int.Parse(textBox.Text);
            quantity -= 1;
            quantity = quantity < 0 ? 0 : quantity;
            textBox.Text = quantity.ToString();
        }

        // Exit button handlers
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HotdogAddButton_Click(object sender, EventArgs e)
        {
            AddItem(HotDogTextBox);
        }

        private void HotdogMinusButton_Click(object sender, EventArgs e)
        {
            MinusItem(HotDogTextBox);
        }

        private void PizzaAddButton_Click(object sender, EventArgs e)
        {
            AddItem(PizzaTextBox);
        }

        private void PizzaMinusButton_Click(object sender, EventArgs e)
        {
            MinusItem(PizzaTextBox);
        }

        private void HamburgerAddButton_Click(object sender, EventArgs e)
        {
            AddItem(HamburgerTextBox);
        }

        private void HamburgerMinusButton_Click(object sender, EventArgs e)
        {
            MinusItem(HamburgerTextBox);
        }

        private void FriesAddButton_Click(object sender, EventArgs e)
        {
            AddItem(FriesTextBox);
        }

        private void FriesMinusButton_Click(object sender, EventArgs e)
        {
            MinusItem(FriesTextBox);
        }

        private void SodaAddButton_Click(object sender, EventArgs e)
        {
            AddItem(SodaTextBox);
        }

        private void SodaMinusButton_Click(object sender, EventArgs e)
        {
            MinusItem(SodaTextBox);
        }

        private void WaterAddButton_Click(object sender, EventArgs e)
        {
            AddItem(WaterTextBox);
        }

        private void WaterMinusButton_Click(object sender, EventArgs e)
        {
            MinusItem(WaterTextBox);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            HotDogTextBox.Text = "0";
            PizzaTextBox.Text = "0";
            HamburgerTextBox.Text = "0";
            FriesTextBox.Text = "0";
            SodaTextBox.Text = "0";
            WaterTextBox.Text = "0";
            TotalPriceLAbel.Text = "";
        }

        // This blocks all input that is not digits and set max value to 99
        private void DigitOnlyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (e.KeyChar != '\b') // Allows backspace
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text + e.KeyChar;

                int value;
                if (!int.TryParse(text, out value) || value < 0 || value > 99)
                {
                    e.Handled = true;
                }
            }
        }

        // This sets default value to 0 if the textbox string is empty
        private void DefaultTextBoxValue_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
            }
        }

        // Prices
        double HotDogPrice = 2.50;
        double PizzaPrice = 3.50;
        double HamburgerPrice = 5.00;
        double FriesPrice = 2.00;
        double SodaPrice = 2.00;
        double WaterPrice = 2.00;

        // Order Button Handler
        private void OrderButton_Click(object sender, EventArgs e)
        {
            int Hotdog      = int.Parse(HotDogTextBox.Text);
            int Pizza       = int.Parse(PizzaTextBox.Text);
            int Hamburger   = int.Parse(HamburgerTextBox.Text);
            int Fries       = int.Parse(FriesTextBox.Text);
            int Soda        = int.Parse(SodaTextBox.Text);
            int Water       = int.Parse(WaterTextBox.Text);

            // item * quantity
            double total = (Hotdog * HotDogPrice) 
                         + (Pizza * PizzaPrice) 
                         + (Hamburger * HamburgerPrice)
                         + (Fries * FriesPrice)
                         + (Soda * SodaPrice)
                         + (Water * WaterPrice);

            TotalPriceLAbel.Text = "Total Bill: $" + total.ToString("0.00");

        }
    }
}
