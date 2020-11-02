using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ShopSystem
{
    public partial class Form1 : Form
    {
        private readonly object txt_InvoiceID;

        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cmb_items.Items.Clear();
            cmb_items.Items.Clear();
            cmb_items.Items.Add("Gulab Jamun");
            cmb_items.Items.Add("Rasamalai");
            cmb_items.Items.Add("Kajju Kathli");

            radioButton3.ForeColor = System.Drawing.Color.Green;
            radioButton2.ForeColor = System.Drawing.Color.Red;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cmb_items.Items.Clear();
            cmb_items.Items.Add("Plum Cake");
            cmb_items.Items.Add("Ice Cake");
            cmb_items.Items.Add("Plain Cake");

            radioButton3.ForeColor = System.Drawing.Color.Red;
            radioButton2.ForeColor = System.Drawing.Color.Green;

        }

        private void txt__price_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(txt_qty.Text.Length > 0)
            {
                txt_total.Text = (Convert.ToInt16(txt_price.Text) * Convert.ToInt16(txt_qty.Text)).ToString();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (txt_discount.Text.Length > 0)
            {
                txt_net.Text = (Convert.ToInt16(txt_sub.Text) - Convert.ToInt16(txt_discount.Text)).ToString();

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (txt_paid.Text.Length>0)
            {
                txt_balance.Text = (Convert.ToInt16(txt_paid.Text) -  Convert.ToInt16(txt_net.Text)).ToString();

            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_items_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmb_items.SelectedItem.ToString() == "Gulab Jamun")
            { txt_price.Text = "50"; }
            else if (cmb_items.SelectedItem.ToString() == "Rasamalai")
            { txt_price.Text = "100"; }
            else if (cmb_items.SelectedItem.ToString() == "Kajju Kathli")
            { txt_price.Text = "150"; }
            else if (cmb_items.SelectedItem.ToString() == "Plum Cake")
            { txt_price.Text = "200"; }
            else if (cmb_items.SelectedItem.ToString() == "Ice Cake")
            { 
                txt_price.Text = "250"; }
            else if (cmb_items.SelectedItem.ToString() == "Plain Cake")
            { txt_price.Text = "300"; }
            else
            { txt_price.Text = "0"; }


            txt_total.Text = "";
            txt_qty.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] arr = new string[4];
            arr[0] =cmb_items.SelectedItem.ToString();
            arr[1] = txt_price.Text;
            arr[2] = txt_qty.Text;
            arr[3] = txt_total.Text;

            ListViewItem lvi = new ListViewItem(arr);

            listView1.Items.Add(lvi);

            txt_sub.Text = (Convert.ToInt32(txt_sub.Text) + Convert.ToInt32(txt_total.Text)).ToString();


            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                        txt_sub.Text = (Convert.ToInt16(txt_sub.Text) - Convert.ToInt16(listView1.Items[i].SubItems[3].Text)).ToString();
                        listView1.Items[i].Remove();


                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                try
                {
        string ConnectionString = @"Data Source=LAPTOP-LI87DI8M\SQLEXPRESS;Initial Catalog=AB_Inventory_DB;Integrated Security=True";

                    SqlConnection connection = new SqlConnection(ConnectionString);
                    SqlCommand command = connection.CreateCommand();

                connection.Open();

            command.CommandText = "Insert into Test_Invoice_Master (InvoiceDate, Sub_Total, Discount, Net_Amount, Paid_Amount) values " +
                                  " ( getdate() , " + @txt_sub.Text + " ," + @txt_discount.Text + " , " + @txt_net.Text + ", " + @txt_paid.Text + ")  select scope_identity() ";

                    string InvoiceID = command.ExecuteScalar().ToString();

                    foreach (ListViewItem ListItem in listView1.Items)
                    {

                        command.CommandText = "Insert into Test_Invoice_Detail (MasterID, ItemName, ItemPrice, ItemQtty, ItemTotal ) values   " +
                   " ('" + @InvoiceID + "', '" + @ListItem.SubItems[0].Text + "', '" + @ListItem.SubItems[1].Text + "', '" + @ListItem.SubItems[2].Text + "' , " + @ListItem.SubItems[3].Text + ")";

                        command.ExecuteNonQuery();

                    }
                    connection.Close();
                    MessageBox.Show("Sale Created Successfully, with Invoice # " + InvoiceID);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Sale Not Created, Error!");
                }

            }
            else
            {
                MessageBox.Show("Must Add an Item In the List");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Report.PrintInvoiceForm().Show();
        }
    }
}
