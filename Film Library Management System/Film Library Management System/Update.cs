using DataAccess.Entity;
using DataAccess.Operation;
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
    

    public partial class Update : Form
    {
        Admin admin;

        public Update()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Update_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin = new Admin();
            admin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MovieUpdate mu = new MovieUpdate();


            mu.Name = txtName.Text;
            mu.IMDB = txtimdb.Text;

            Operation op = new Operation();

            if (txtName.Text == "" || txtimdb.Text == "" )
            {
                MessageBox.Show("All the field must be fill");
            }
            
            else
            {
                op.update(mu);
            }
        }
    }
}
