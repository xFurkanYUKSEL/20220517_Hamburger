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
using System.Configuration;

namespace Hamburger
{
    public partial class MenuEkle : Form
    {
        public MenuEkle(SqlConnection sqlHamburger,SqlCommand query)
        {
            InitializeComponent();
            this.sqlHamburger = sqlHamburger;
            this.query = query;
        }
        SqlConnection sqlHamburger;
        SqlCommand query;
        string qAddNewMenu = "EXEC AddNewMenu @Name,@Price";
        internal bool menuIsNew, menuAdded;
        private void btnAddMenu_Click(object sender, EventArgs e)
        {
           
        }
        void AddNewMenu()
        {
            try
            {
                if (txtMenuName.Text.Length == 0)
                {
                    MessageBox.Show("You Should Define A Name First!");
                    return;
                }
                if (sqlHamburger.State == ConnectionState.Closed)
                {
                    sqlHamburger.Open();
                }
                if (MessageBox.Show("Are You Sure?\nName=" + txtMenuName.Text + " Price=" + numMenuPrice.Value, "Adding New Menu!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    query.CommandText = qAddNewMenu;
                    query.Parameters["@Name"].Value = txtMenuName.Text;
                    query.Parameters["@Price"].Value = (double)numMenuPrice.Value;
                    query.ExecuteNonQuery();
                    menuAdded = true;
                    MessageBox.Show("New Menu Added!");
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
    }
}
