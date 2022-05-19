using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Hamburger
{
    public partial class Hamburgerci : Form
    {
        SqlConnection conHamburger = new SqlConnection(ConfigurationManager.ConnectionStrings["hamburger"].ConnectionString);
        SqlCommand query = new SqlCommand();
        SqlDataReader dr;
        int newOrderID;
        string qAddNewOrder = "DECLARE @OrderID INT EXEC AddNewOrder @UserID, @OrderID OUTPUT SELECT @OrderID";
        string qNewOrderDetails = "NewOrder @NewOrderID,@MenuName,@SizeName,@ExtraName,@Amount";
        string qMenus = "SELECT Name FROM Menus";
        string qSizes = "SELECT Name FROM Sizes";
        string qExtras = "SELECT Name FROM Extras";
        public Hamburgerci(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }
        int userID;
        private void Siparis_Load(object sender, EventArgs e)
        {
            HamburgerciLoad();
        }
        void HamburgerciLoad()
        {
            query.Connection = conHamburger;
            LoadMenus();
            LoadSizes();
            LoadExtras();
            query.Parameters.AddWithValue("@UserID", userID);
            query.Parameters.AddWithValue("@NewOrderID", 1);
            query.Parameters.AddWithValue("@MenuName", "");
            query.Parameters.AddWithValue("@SizeName", "");
            query.Parameters.AddWithValue("@ExtraName", "");
            query.Parameters.AddWithValue("@Amount", "");
            listView1.Columns.Add("Menu", 100);
            listView1.Columns.Add("Size", 100);
            listView1.Columns.Add("Extra", 100);
            listView1.Columns.Add("Amount", 100);
        }

        void LoadMenus()
        {
            try
            {
                cmbMenu.Items.Clear();
                query.CommandText = qMenus;
                if (conHamburger.State == ConnectionState.Closed)
                {
                    conHamburger.Open();
                    dr = query.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            cmbMenu.Items.Add(dr["Name"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conHamburger.Close();
            }
        }
        void LoadSizes()
        {
            try
            {
                flpSizes.Controls.Clear();
                query.CommandText = qSizes;
                if (conHamburger.State == ConnectionState.Closed)
                {
                    conHamburger.Open();
                    dr = query.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            flpSizes.Controls.Add(new RadioButton() { Text = dr["Name"].ToString(), AutoSize = true });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conHamburger.Close();
            }
        }
        void LoadExtras()
        {
            try
            {
                flpExtras.Controls.Clear();
                query.CommandText = qExtras;
                if (conHamburger.State == ConnectionState.Closed)
                {
                    conHamburger.Open();
                    dr = query.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            flpExtras.Controls.Add(new CheckBox() { Text = dr["Name"].ToString(), AutoSize = true });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conHamburger.Close();
            }
        }
        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Please Add At Least One Menu!");
                return;
            }
            query.CommandText = qAddNewOrder;
            if (conHamburger.State == ConnectionState.Closed)
            {
                conHamburger.Open();
                newOrderID = int.Parse(query.ExecuteScalar().ToString());
                conHamburger.Close();
                OrderDetails();
            }
            MessageBox.Show("Order Added To Your Orders Successfully!");
            Clear();
        }
        string[] extrasArray;
        void OrderDetails()
        {
            query.CommandText = qNewOrderDetails;
            foreach (ListViewItem order in listView1.Items)
            {
                extrasArray = order.SubItems[2].Text.Split(',');
                foreach (string extra in extrasArray)
                {
                    query.Parameters["@NewOrderID"].Value = newOrderID;
                    query.Parameters["@MenuName"].Value = order.SubItems[0].Text;
                    query.Parameters["@SizeName"].Value = order.SubItems[1].Text;
                    query.Parameters["@ExtraName"].Value = extra;
                    query.Parameters["@Amount"].Value = byte.Parse(order.SubItems[3].Text);
                    if (conHamburger.State == ConnectionState.Closed)
                    {
                        conHamburger.Open();
                        query.ExecuteNonQuery();
                        conHamburger.Close();
                    }
                }
                order.Remove();
            }
        }
        string sizeName, extras;
        private void button1_Click(object sender, EventArgs e)
        {
            extras = "";
            foreach (RadioButton size in flpSizes.Controls)
            {
                if (size.Checked)
                {
                    sizeName = size.Text;
                    size.Checked = false;
                }
            }
            foreach (CheckBox extra in flpExtras.Controls)
            {
                if (extra.Checked)
                {
                    extras += extra.Text + ",";
                    extra.Checked = false;
                }
            }
            extras = extras.TrimEnd(',');
            listView1.Items.Add(new ListViewItem(new string[] { cmbMenu.Text, sizeName, extras, ((int)numAmount.Value).ToString() }));
            numAmount.Value = 1;
            cmbMenu.SelectedIndex = -1;
        }

        private void Hamburgerci_VisibleChanged(object sender, EventArgs e)
        {
            Clear();
        }
        bool removed;
        private void btnRemoveOrders_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count==0)
            {
                MessageBox.Show("Please Add At Least One Menu To Order!");
                return;
            }
            if (MessageBox.Show("Are You Sure?", "Removing Selected Menus!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (ListViewItem order in listView1.Items)
                {
                    if (order.Checked)
                    {
                        order.Remove();
                        removed = true;
                    }
                }
            }
            if (removed)
            {
                MessageBox.Show("Removed Selected Menus!");
                removed = false;
            }
            else
            {
                MessageBox.Show("You Did Not Selected Any Menus To Remove!");
            }
        }

        void Clear()
        {
            foreach (RadioButton size in flpSizes.Controls)
            {
                size.Checked = false;
            }
            foreach (CheckBox extra in flpExtras.Controls)
            {
                extra.Checked = false;
            }
            listView1.Items.Clear();
            cmbMenu.SelectedIndex = -1;
            numAmount.Value = 1;
        }
    }
}

