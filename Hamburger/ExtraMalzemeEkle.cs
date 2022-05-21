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
    public partial class ExtraMalzemeEkle : Form
    {
        public ExtraMalzemeEkle(SqlConnection sqlHamburger,SqlCommand query)
        {
            InitializeComponent();
            this.sqlHamburger = sqlHamburger;
            this.query = query;
        }
        SqlConnection sqlHamburger;
        SqlCommand query;
        string qAddNewExtra = "EXEC AddNewExtra @Name,@Price";
        private void ExtraMalzemeEkle_Load(object sender, EventArgs e)
        {
        }
        private void btnAddExtra_Click(object sender, EventArgs e)
        {
            AddNewExtra();
        }
       internal bool extraAdded;
        void AddNewExtra()
        {
            try
            {
                if (txtExtraName.Text.Length == 0)
                {
                    MessageBox.Show("You Should Define A Name First!");
                    return;
                }
                if (sqlHamburger.State == ConnectionState.Closed)
                {
                    sqlHamburger.Open();
                }
                if (MessageBox.Show("Are You Sure?\nName=" + txtExtraName.Text + " Price=" + numExtraPrice.Value, "Adding New Extra!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    query.CommandText = qAddNewExtra;
                    query.Parameters["@Name"].Value = txtExtraName.Text;
                    query.Parameters["@Price"].Value = (double)numExtraPrice.Value;
                    query.ExecuteNonQuery();
                    extraAdded = true;
                    MessageBox.Show("New Extra Added!");
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
