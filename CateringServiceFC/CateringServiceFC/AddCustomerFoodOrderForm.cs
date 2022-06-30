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
    public partial class AddCustomerFoodOrderForm : Form
    {
        DatabaseUtil databaseUtil;
        public AddCustomerFoodOrderForm()
        {
            InitializeComponent();
            databaseUtil = new DatabaseUtil();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool added = false;
            try
            {
                 added = databaseUtil.addCustomerFoodOrder(int.Parse(this.textBox1.Text), int.Parse(this.textBox2.Text), this.dateTimePicker1.Value, this.dateTimePicker2.Value,
                   int.Parse(this.textBox3.Text), int.Parse(this.textBox4.Text), int.Parse(this.textBox5.Text), this.dateTimePicker3.Value);
            } catch (Exception ex)
            {
                MessageBox.Show("Exception caught\n" + ex.Message);
            }
            if (added)
                MessageBox.Show("Customer Food Order added.");
        }

        private void AddCustomerFoodOrderForm_Load(object sender, EventArgs e)
        {

        }
    }
}
