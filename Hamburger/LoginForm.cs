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
using System.IO;
using System.Xml.Serialization;

namespace Hamburger
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Main_VisibleChanged(object sender, EventArgs e)
        {
            if (!main.Visible)
            {
                //LoadUserDetails();
                this.Show();
                main.Dispose();
                main.Close();
                MessageBox.Show(userID.ToString());
            }
        }
        Main main;
        SqlConnection sqlHamburger = new SqlConnection(ConfigurationManager.ConnectionStrings["hamburger"].ConnectionString);
        SqlCommand query = new SqlCommand();
        SqlDataReader dr;
        string qGetUserID = "SELECT ID,FirstName,LastName,Title FROM Users WHERE Username=@Username AND Password=@Password";
        int userID;
        string title;
        private void chkShowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkShowHide.Checked)
            {
                txtPassWord.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassWord.UseSystemPasswordChar = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlHamburger.State == ConnectionState.Closed)
                {
                    query.CommandText = qGetUserID;
                    query.Parameters["@Username"].Value = txtUserName.Text;
                    query.Parameters["@Password"].Value = txtPassWord.Text;
                    sqlHamburger.Open();
                    dr = query.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            SerializeCurrentUser();
                            userID = dr.GetInt32(0);
                            query.Parameters["@UserID"].Value = userID;
                            MessageBox.Show("Welcome " + dr["FirstName"] + " " + dr["LastName"]);
                            title = dr["Title"].ToString();
                            main = new Main(userID, title, sqlHamburger, query);
                            main.VisibleChanged += Main_VisibleChanged;
                            Hide();
                            main.Show();
                            break;
                        }
                        dr.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username or Password is Wrong!");
                        return;
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
        void Query()
        {
            query.Connection = sqlHamburger;
            query.Parameters.AddWithValue("@Username", txtUserName.Text);
            query.Parameters.AddWithValue("@Password", txtPassWord.Text);
            query.Parameters.AddWithValue("@UserID", userID);
            query.Parameters.AddWithValue("@NewOrderID", 1);
            query.Parameters.AddWithValue("@MenuName", "");
            query.Parameters.AddWithValue("@SizeName", "");
            query.Parameters.AddWithValue("@ExtraName", "");
            query.Parameters.AddWithValue("@Amount", "");
            query.Parameters.AddWithValue("@PersonID", 1);
            query.Parameters.AddWithValue("@Name", "");
            query.Parameters.AddWithValue("@Price", 0.0);
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            DeSerializeCurrentUser();
            Query();
        }
        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked)
            {
                chkUsername.Checked = true;
            }
        }

        private void chkUsername_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkUsername.Checked)
            {
                chkPassword.Checked = false;
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (main == null)
            {
                if (MessageBox.Show("Are You Really Sure?", "Closing!", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                if (main.IsDisposed)
                {
                    if (MessageBox.Show("Are You Really Sure?", "Closing!", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
        User currentUser = new User();
        Stream stream;
        XmlSerializer xmlSerializer=new XmlSerializer(typeof(User));
        void SerializeCurrentUser()
        {
            try
            {
                stream = new FileStream("currentUser.xml", FileMode.Create, FileAccess.Write);
                currentUser.Username = "";
                currentUser.Password = "";
                if (chkPassword.Checked)
                {
                    currentUser.Username = txtUserName.Text;
                    currentUser.Password = txtPassWord.Text;
                }
                else if (chkUsername.Checked)
                {
                    currentUser.Username = txtUserName.Text;
                }
                xmlSerializer.Serialize(stream,currentUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                stream.Close();
            }
        }
        void DeSerializeCurrentUser()
        {
            chkShowHide.Checked = false;
            try
            {
                stream = new FileStream("currentUser.xml",FileMode.Open,FileAccess.Read);
                currentUser=(User)xmlSerializer.Deserialize(stream);
                txtUserName.Text = currentUser.Username;
                txtPassWord.Text = currentUser.Password;
                if (txtPassWord.Text.Length > 0)
                {
                    chkPassword.Checked = true;
                }
                else if (txtUserName.Text.Length > 0)
                {
                    chkUsername.Checked = true;
                }
            }
            catch (Exception)
            {
                SerializeCurrentUser();
            }
            finally
            {
                stream.Close();
            }
        }
    }
}
