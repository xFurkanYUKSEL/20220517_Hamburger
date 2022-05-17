using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hamburger
{
    public partial class Payment : Form
    {
        SqlConnection tavşınBank = new SqlConnection(ConfigurationManager.ConnectionStrings["tavşınBank"].ConnectionString);
        SqlCommand query = new SqlCommand();
        SqlDataReader dr;
        string qGetUserID = "SELECT Money FROM Users WHERE Username=@Username AND Password=@Password";
        public Payment()
        {
            InitializeComponent();
        }
        float remainingPayment;
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }
        float money;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (tavşınBank.State == ConnectionState.Closed)
                {
                    query.CommandText = qGetUserID;
                    query.Parameters["@Username"].Value = txtUsername.Text;
                    query.Parameters["@Password"].Value = txtPassword.Text;
                    tavşınBank.Open();
                    dr = query.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            money = float.Parse(dr[0].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username or Password is Wrong!");
                    }
                    dr.Close();
                    tavşınBank.Close();
                    /////////////////////////////////////
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tavşınBank.Close();
            }
        }

        private void Payment_Load(object sender, EventArgs e)
        {

        }
        void PaymentLoad()
        {
            query.Parameters.AddWithValue("@Username","");
            query.Parameters.AddWithValue("@Password","");
        }
    }
}
