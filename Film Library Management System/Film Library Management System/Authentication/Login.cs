using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Film_Library_Management_System
{
    public partial class Login : Form
    {
        SignUp signup;
        Admin admin;
        User user;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try 
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Select User Type");
                }
                else if (comboBox1.SelectedIndex == 0)
                {
                    if (txtUsername.Text == " " || txtPassword.Text == " ")
                    {
                        MessageBox.Show("Enter both Username , Password or User type");
                    }
                    else
                    {
                        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-EAB1MTR7;Initial Catalog=Film_Library;Integrated Security=True");
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM User_info WHERE Username ='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "'and User_type='" + comboBox1.Text + "'", connection);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);



                        if (dataTable.Rows[0][0].ToString() == "1")
                        {
                            this.Hide();
                            admin = new Admin();
                            admin.Show();
                            connection.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username , Password or user type");
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                            comboBox1.Text = "User Type";
                            

                        }
                        connection.Close();
                    }
                }
                else
                {
                    if (txtUsername.Text == " " || txtPassword.Text == " ")
                    {
                        MessageBox.Show("Enter both Username and Password");
                    }
                    else
                    {
                        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-EAB1MTR7;Initial Catalog=Film_Library;Integrated Security=True");
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM User_info WHERE Username='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "' and User_type='" + comboBox1.Text + "'", connection);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);



                        if (dataTable.Rows[0][0].ToString() == "1")
                        {
                            
                            this.Hide();
                            user = new User();
                            user.Show();
                            connection.Close(); 
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username, Password or user type");
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                            comboBox1.Text = "User Type";
                        }
                        connection.Close();
                    }
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
                
            }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            signup = new SignUp();
            signup.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0';

            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
    }

