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
    
    public partial class TumSiparisler : Form
    {
        SqlDataAdapter daHamburger = new SqlDataAdapter("SELECT O.ID,O.[Order Date],O.[Total Price],S.State FROM Orders O JOIN States S ON S.ID=O.[Order State ID] WHERE [User ID]=@UserID", ConfigurationManager.ConnectionStrings["hamburger"].ConnectionString);
        DataTable dtOrders = new DataTable("My Orders");
        SqlConnection sqlHamburger;
        SqlCommand query;
        string qMonthly = "SELECT SUM([Total Price]) FROM [Orders Last 30 Days] WHERE [User ID]=@UserID";
        string qTotalRemaining = "SELECT SUM([Total Price]) FROM Orders WHERE [User ID]=@UserID AND [Order State ID]=1";
        public TumSiparisler(int userID,SqlConnection sqlHamburger,SqlCommand query)
        {
            InitializeComponent();
            this.userID = userID;
            this.sqlHamburger = sqlHamburger;
            this.query = query;
            VisibleChanged += TumSiparisler_VisibleChanged;
        }
        int userID;
        private void TumSiparisler_Load(object sender, EventArgs e)
        {
            MyOrdersLoad();
        }
        void MyOrdersLoad()
        {
            daHamburger.SelectCommand.Parameters.AddWithValue("@UserID",userID);
            query.CommandText = qTotalRemaining;
            sqlHamburger.Open();
            lblRemainingPayment.Text = query.ExecuteScalar().ToString();
            sqlHamburger.Close();
        }

        public void MyOrders()
        {
            query.CommandText = qMonthly;
            dgvMyOrders.Controls.Clear();
            dtOrders.Clear();
            daHamburger.Fill(dtOrders);
            dgvMyOrders.DataSource = dtOrders;
            lblTotalOrders.Text = dtOrders.Rows.Count.ToString();
            dgvMyOrders.AutoResizeColumns();
            dgvMyOrders.AutoResizeRows();
            if (sqlHamburger.State==ConnectionState.Closed)
            {
                sqlHamburger.Open();
                lblMonthlyTotalPrice.Text=query.ExecuteScalar().ToString();
            }
            query.CommandText = qTotalRemaining;
            lblRemainingPayment.Text = query.ExecuteScalar().ToString();
            sqlHamburger.Close();
        }

        private void TumSiparisler_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                MyOrders();
            }
        }
        internal bool payment;
        private void btnPayment_Click(object sender, EventArgs e)
        {
            payment = true;
            Hide();
        }
    }
}
