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
        public ExtraMalzemeEkle(SqlConnection sqlHamburger)
        {
            InitializeComponent();
            this.sqlHamburger = sqlHamburger;
        }
        SqlConnection sqlHamburger;
        private void ExtraMalzemeEkle_Load(object sender, EventArgs e)
        {
        }
        private void btnAddExtra_Click(object sender, EventArgs e)
        {
           
        }
    }
}
