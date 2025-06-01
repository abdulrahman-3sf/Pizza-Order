using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float getSelectedSizePrice()
        {
            if (rbSmall.Checked)
                return Convert.ToSingle(rbSmall.Tag);
            else if (rbMedium.Checked)
                return Convert.ToSingle(rbMedium.Tag);
            else
                return Convert.ToSingle(rbLarge.Tag);
        }
        float getSelectedCrustTypePrice()
        {
            if (rbThin.Checked)
                return Convert.ToSingle(rbThin.Tag);
            else
                return Convert.ToSingle(rbThick.Tag);
        }
        float getSelectedToppingsPrice()
        {
            float totalToppingsPrice = 0;

            if (cbExtraChees.Checked)
                totalToppingsPrice += Convert.ToSingle(cbExtraChees.Tag);
            
            if (cbMushrooms.Checked)
                totalToppingsPrice += Convert.ToSingle(cbMushrooms.Tag);
            
            if (cbTomatoes.Checked)
                totalToppingsPrice += Convert.ToSingle(cbTomatoes.Tag);
            
            if (cbOnion.Checked)
                totalToppingsPrice += Convert.ToSingle(cbOnion.Tag);
            
            if (cbOlives.Checked)
                totalToppingsPrice += Convert.ToSingle(cbOlives.Tag);
            
            if (cbGreenPeppers.Checked)
                totalToppingsPrice += Convert.ToSingle(cbGreenPeppers.Tag);

            return totalToppingsPrice;
        }
        float calculateTotalPrice()
        {
            return getSelectedSizePrice() + getSelectedCrustTypePrice() + getSelectedToppingsPrice();
        }
        void updateTotalPrice()
        {
            lbPrice.Text = "$" + calculateTotalPrice().ToString();
        }

        void updateToppings()
        {
            string toppings = "";

            if (cbExtraChees.Checked)
                toppings += "Extra Chees";

            if (cbMushrooms.Checked)
                toppings += ", Mushrooms";

            if (cbTomatoes.Checked)
                toppings += ", Tomatoes";

            if (cbOnion.Checked)
                toppings += ", Onion";

            if (cbOlives.Checked)
                toppings += ", Olives";

            if (cbGreenPeppers.Checked)
                toppings += ", Green Peppers";

            if (toppings.StartsWith(","))
                toppings = toppings.Substring(1, toppings.Length - 1).Trim();

            if (toppings == "")
                toppings = "No Toppings";

            lbToppings.Text = toppings;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            lbSize.Text = "Small";
            updateTotalPrice();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            lbSize.Text = "Medium";
            updateTotalPrice();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            lbSize.Text = "Large";
            updateTotalPrice();
        }

        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            lbCrustType.Text = "Thin";
            updateTotalPrice();
        }

        private void rbThick_CheckedChanged(object sender, EventArgs e)
        {
            lbCrustType.Text = "Thick";
            updateTotalPrice();
        }

        private void cbExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            updateToppings();
            updateTotalPrice();
        }

        private void cbMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            updateToppings();
            updateTotalPrice();
        }

        private void cbTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            updateToppings();
            updateTotalPrice();
        }

        private void cbOnion_CheckedChanged(object sender, EventArgs e)
        {
            updateToppings();
            updateTotalPrice();
        }

        private void cbOlives_CheckedChanged(object sender, EventArgs e)
        {
            updateToppings();
            updateTotalPrice();
        }

        private void cbGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            updateToppings();
            updateTotalPrice();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            lbWhereToEat.Text = "Eat In";
        }

        private void rbEatOut_CheckedChanged(object sender, EventArgs e)
        {
            lbWhereToEat.Text = "Eat Out";
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gbSize.Enabled = false;
                gbToppings.Enabled = false;
                gbCrustType.Enabled = false;
                gbWhereToEat.Enabled = false;

                btnOrder.Enabled = false;
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbCrustType.Enabled = true;
            gbWhereToEat.Enabled = true;

            rbMedium.Checked = true;
            
            rbThin.Checked = true;

            cbExtraChees.Checked = true;
            cbMushrooms.Checked = false;
            cbTomatoes.Checked = true;
            cbOnion.Checked = false;
            cbOlives.Checked = false;
            cbGreenPeppers.Checked = false;

            rbEatIn.Checked = true;

            btnOrder.Enabled = true;
        }

        private void lbPrice_Apper(object sender, PaintEventArgs e)
        {
            updateTotalPrice();
        }

    }
}
