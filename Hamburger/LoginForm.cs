﻿using System;
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
                LoadUserDetails();
                this.Show();
                main.Dispose();
            }
        }
        Main main;
        SqlConnection sqlHamburger = new SqlConnection(ConfigurationManager.ConnectionStrings["hamburger"].ConnectionString);
        SqlCommand query = new SqlCommand();
        SqlDataReader dr;
        string qGetCurrentUser = "SELECT Username,Password FROM [Current User]";
        string qUpdateCurrentUser = "UPDATE [Current User] SET Username=@Username,Password=@Password";
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
                            userID = dr.GetInt32(0);
                            MessageBox.Show("Welcome " + dr["FirstName"] + " " + dr["LastName"]);
                            title = dr["Title"].ToString();
                        }
                        dr.Close();
                        query.CommandText = qUpdateCurrentUser;
                        query.Parameters["@Username"].Value = "";
                        query.Parameters["@Password"].Value = "";
                        if (chkPassword.Checked)
                        {
                            query.Parameters["@Password"].Value = txtPassWord.Text;
                            query.Parameters["@Username"].Value = txtUserName.Text;
                        }
                        else if (chkUsername.Checked)
                        {
                            query.Parameters["@Username"].Value = txtUserName.Text;
                        }
                        query.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Username or Password is Wrong!");
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
                main = new Main(userID, title, sqlHamburger);
                main.VisibleChanged += Main_VisibleChanged;
                Hide();
                main.Show();
            }

        }
        void Query()
        {
            query.Connection = sqlHamburger;
            query.Parameters.AddWithValue("@Username", txtUserName.Text);
            query.Parameters.AddWithValue("@Password", txtPassWord.Text);
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            Query();
            LoadUserDetails();
        }
        void LoadUserDetails()
        {
            chkShowHide.Checked = false;
            try
            {
                query.CommandText = qGetCurrentUser;
                if (sqlHamburger.State == ConnectionState.Closed)
                {
                    sqlHamburger.Open();
                    dr = query.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txtUserName.Text = dr["Username"].ToString();
                            txtPassWord.Text = dr["Password"].ToString();
                            if (txtPassWord.Text.Length > 0)
                            {
                                chkPassword.Checked = true;
                            }
                            else if (txtUserName.Text.Length > 0)
                            {
                                chkUsername.Checked = true;
                            }
                        }
                    }
                    dr.Close();
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
    }
}
