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
        SqlConnection sqlHamburger;
        SqlCommand query = new SqlCommand();
        SqlDataReader dr;
        int newOrderID;
        string qAddNewOrder = "DECLARE @OrderID INT EXEC AddNewOrder @UserID, @OrderID OUTPUT SELECT @OrderID";
        string qNewOrderDetails = "EXEC NewOrder @NewOrderID,@MenuName,@SizeName,@ExtraName,@Amount,@PersonID";
        string qMenus = "SELECT Name FROM Menus";
        string qSizes = "SELECT Name FROM Sizes";
        string qExtras = "SELECT Name FROM Extras";
        public Hamburgerci(int userID, SqlConnection sqlHamburger)
        {
            InitializeComponent();
            this.userID = userID;
            this.sqlHamburger = sqlHamburger;
            this.sqlHamburger.Close();
        }
        int userID, personID = 1;
        private void Siparis_Load(object sender, EventArgs e)
        {
            HamburgerciLoad();
        }
        void HamburgerciLoad()
        {
            query.Connection = sqlHamburger;
            LoadMenus();
            LoadSizes();
            LoadExtras();
            query.Parameters.AddWithValue("@UserID", userID);
            query.Parameters.AddWithValue("@NewOrderID", 1);
            query.Parameters.AddWithValue("@MenuName", "");
            query.Parameters.AddWithValue("@SizeName", "");
            query.Parameters.AddWithValue("@ExtraName", "");
            query.Parameters.AddWithValue("@Amount", "");
            query.Parameters.AddWithValue("@PersonID", 1);
            listView1.Columns.Add("Menu", 150);
            listView1.Columns.Add("Size", 100);
            listView1.Columns.Add("Extra", 200);
            listView1.Columns.Add("Amount", 50);
        }

        void LoadMenus()
        {
            try
            {
                cmbMenu.Items.Clear();
                query.CommandText = qMenus;
                if (sqlHamburger.State == ConnectionState.Closed)
                {
                    sqlHamburger.Open();
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
                sqlHamburger.Close();
            }
        }
        void LoadSizes()
        {
            try
            {
                flpSizes.Controls.Clear();
                query.CommandText = qSizes;
                if (sqlHamburger.State == ConnectionState.Closed)
                {
                    sqlHamburger.Open();
                    dr = query.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            flpSizes.Controls.Add(new RadioButton() { Text = dr["Name"].ToString(), AutoSize = true });
                        }
                    }
                }
                foreach (RadioButton size in flpSizes.Controls)
                {
                    size.CheckedChanged += Size_CheckedChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlHamburger.Close();
            }
        }

        private void Size_CheckedChanged(object sender, EventArgs e)
        {
            sizeChecked = true;
        }

        void LoadExtras()
        {
            try
            {
                flpExtras.Controls.Clear();
                query.CommandText = qExtras;
                if (sqlHamburger.State == ConnectionState.Closed)
                {
                    sqlHamburger.Open();
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
                sqlHamburger.Close();
            }
        }
        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            SubmitOrder();
            Clear();
        }
        SqlTransaction transaction;
        void SubmitOrder()
        {
            try
            {
                if (listView1.Items.Count == 0)
                {
                    MessageBox.Show("Please Add At Least One Menu!");
                    return;
                }
                query.CommandText = qAddNewOrder;
                if (sqlHamburger.State == ConnectionState.Closed)
                {
                    sqlHamburger.Open();
                    transaction = sqlHamburger.BeginTransaction();
                    query.Transaction = transaction;
                    newOrderID = int.Parse(query.ExecuteScalar().ToString());
                    OrderDetails();
                }
                transaction.Commit();
                MessageBox.Show("Order Added To Your Orders Successfully!");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                transaction.Dispose();
                sqlHamburger.Close();
            }
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
                    query.Parameters["@PersonID"].Value = personID;
                    query.ExecuteNonQuery();
                }
                personID++;
                order.Remove();
            }
            personID = 1;
        }
        string sizeName, extras;
        private void button1_Click(object sender, EventArgs e)
        {
            NewMenu();
        }
        bool sizeChecked;
        void NewMenu()
        {
            try
            {
                if (cmbMenu.SelectedIndex==-1 || !sizeChecked)
                {
                    MessageBox.Show("Select Menu And Size First!");
                    return;
                }
                extras = "";
                foreach (RadioButton size in flpSizes.Controls)
                {
                    if (size.Checked)
                    {
                        sizeName = size.Text;
                        size.Checked = false;
                        sizeChecked = false;
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
                foreach (ListViewItem menu in listView1.Items)
                {
                    if (menu.SubItems[0].Text == cmbMenu.Text &&
                        menu.SubItems[1].Text == sizeName &&
                        menu.SubItems[2].Text == extras)
                    {
                        menu.SubItems[3].Text = (int.Parse(menu.SubItems[3].Text) + numAmount.Value).ToString();
                        numAmount.Value = 1;
                        cmbMenu.SelectedIndex = -1;
                        return;
                    }
                }
                listView1.Items.Add(new ListViewItem(new string[] { cmbMenu.Text, sizeName, extras, ((int)numAmount.Value).ToString() }));
                numAmount.Value = 1;
                cmbMenu.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Hamburgerci_VisibleChanged(object sender, EventArgs e)
        {
            Clear();
        }
        bool removed;
        private void btnRemoveOrders_Click(object sender, EventArgs e)
        {
            RemoveOrders();
        }
        void RemoveOrders()
        {
            try
            {
                if (listView1.Items.Count == 0)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

