using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CateringServiceFC
{
    public partial class AddCustomerForm : Form
    {
        DatabaseUtil databaseUtil;
        public AddCustomerForm()
        {
            InitializeComponent();
            databaseUtil = new DatabaseUtil();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool added = false;
            try
            {
                added = databaseUtil.addCustomer(int.Parse(this.textBox1.Text), this.textBox2.Text, this.dateTimePicker1.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception caught\n" + ex.Message);
            }
            if (added)
                MessageBox.Show("Customer added.");
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
