using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CateringServiceFC.util;

namespace CateringServiceFC
{
    public partial class MainForm : Form
    {
        private QueryUtil queryUtil ;

        public MainForm()
        {
            InitializeComponent();
            queryUtil = new QueryUtil();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
            
            String customer = queryUtil.getCustomerWithHighestPurchase(this.dateTimePicker1.Value, this.dateTimePicker2.Value);
            String s =  (customer!= null && customer.Trim().Length > 0) ? customer : "No customer found.";
            this.richTextBox1.Text =  "Customer with highest turnover: " + s;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";

            double total = queryUtil.getTotalTurnOver(this.dateTimePicker1.Value, this.dateTimePicker2.Value);
            double days = (this.dateTimePicker2.Value.Date - this.dateTimePicker1.Value.Date).Days + 1;
            double average = total / days;
            this.richTextBox1.Text = "Average turnover: " + average;

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
            int total = queryUtil.getTotalTurnOver(this.dateTimePicker1.Value, this.dateTimePicker2.Value);
            this.richTextBox1.Text =  "Total turnover: " + total;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";

            List<String> customers = queryUtil.customersWithStarterButNoDessert();
            string result = "Here is list of customers which had starter but no desert:\r\n";
            String names = "";
            foreach(String name in customers)
            {
                names += name + "\r\n";
            }
            if(names.Trim().Length==0)
                names = "No customer(s) found.";
            this.richTextBox1.Text = result + names;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";
            List<String> customers = queryUtil.getCustomersWithMoreThanAveragePurchase(this.dateTimePicker1.Value, this.dateTimePicker2.Value);
            string result = "Here is list of customers with more than average turnover:\r\n";
            String names = "";
            foreach (String name in customers)
            {
                names += name + "\r\n";
            }
            if (names.Trim().Length == 0)
                names = "No customer(s) found.";
            this.richTextBox1.Text = result + names;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            AddCustomerForm f = new AddCustomerForm();
            f.ShowDialog();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            AddCustomerFoodOrderForm f = new AddCustomerFoodOrderForm();
            f.ShowDialog();
        }
    }
}
