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
    public partial class SignUp : Form
    {
        Login login;

        public SignUp()
        {
            InitializeComponent();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            login = new Login();
            login.Show();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
           
                //Password & confirm password equality check
                if (txtPassword.Text != txtRetypepassword.Text)
                {
                    MessageBox.Show("Password do not match");
                    txtPassword.Text = "";
                    txtRetypepassword.Text = "";
                }




                //Show message if any field is empty
                else if (txtfname.Text == "" || txtlname.Text == "" || txtuname.Text == "" || txtemail.Text == "" || txtPassword.Text == "" || txtRetypepassword.Text == "")
                {
                    MessageBox.Show("All the field must be fill");
                }




                else
                {
                    //Check if User Id is alredy exist or not
                    SqlConnection connection = new SqlConnection("Data Source=LAPTOP-EAB1MTR7;Initial Catalog=Film_Library;Integrated Security=True");
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM User_info WHERE Username='" + txtuname.Text + "'", connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);

                    int i = dataset.Tables[0].Rows.Count;
                    if (i > 0)
                    {
                        MessageBox.Show("Username " + txtuname.Text + " is already exist.\nPlease Enter an Unique Username");
                        dataset.Clear();
                        txtuname.Text = "";
                    }



                    else
                    {
                       
                            //Registration Main part
                            connection = new SqlConnection("Data Source=LAPTOP-EAB1MTR7;Initial Catalog=Film_Library;Integrated Security=True");
                            connection.Open();
                            command = new SqlCommand("INSERT INTO User_info(First_name,Last_name,Username,Email,Password,Retype_Password,User_type) VALUES(@First_name,@Last_name,@Username,@Email,@Password,@Retype_password,@User_type)", connection);
                            command.Parameters.AddWithValue("@First_name", txtfname.Text);
                            command.Parameters.AddWithValue("@Last_name", txtlname.Text);
                            command.Parameters.AddWithValue("@Username", txtuname.Text);
                            command.Parameters.AddWithValue("@Email",txtemail.Text);
                            command.Parameters.AddWithValue("@Password", txtPassword.Text);
                            command.Parameters.AddWithValue("@Retype_password", txtRetypepassword.Text);
                     
                            command.Parameters.AddWithValue("@User_type", txtUser.Text);
                            command.ExecuteNonQuery();

                            connection.Close();
                            MessageBox.Show("Successfully Inserted");
                            txtfname.Text = "";
                            txtlname.Text = "";
                            txtuname.Text = "";
                            txtemail.Text = "";
                            txtPassword.Text = "";
                            txtRetypepassword.Text = "";
                            
                        
                        
                    }
                } 
            
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            txtUser.Hide();
        }
    }
}
