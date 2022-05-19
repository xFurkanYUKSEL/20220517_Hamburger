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
        SqlConnection conHamburger = new SqlConnection(ConfigurationManager.ConnectionStrings["hamburger"].ConnectionString);
        SqlCommand query = new SqlCommand();
        string qMonthly = "SELECT SUM([Total Price]) FROM [Orders Last 30 Days] WHERE [User ID]=@UserID";
        string qTotalRemaining = "SELECT SUM([Total Price]) FROM Orders WHERE [User ID]=@UserID AND [Order State ID]=1";
        public TumSiparisler(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            VisibleChanged += TumSiparisler_VisibleChanged;
        }
        int userID;
        private void TumSiparisler_Load(object sender, EventArgs e)
        {
            MyOrdersLoad();
        }
        void MyOrdersLoad()
        {
            daHamburger.SelectCommand.Parameters.AddWithValue("@UserID", userID);
            query.Parameters.AddWithValue("@UserID", userID);
            daHamburger.Fill(dtOrders);
            query.CommandText = qTotalRemaining;
            query.Connection = conHamburger;
            conHamburger.Open();
            lblRemainingPayment.Text = query.ExecuteScalar().ToString();
            conHamburger.Close();
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
            if (conHamburger.State==ConnectionState.Closed)
            {
                conHamburger.Open();
                lblMonthlyTotalPrice.Text=query.ExecuteScalar().ToString();
            }
            conHamburger.Close();
            query.CommandText = qTotalRemaining;
            conHamburger.Open();
            lblRemainingPayment.Text = query.ExecuteScalar().ToString();
            conHamburger.Close();
        }

        private void TumSiparisler_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                MyOrders();
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
