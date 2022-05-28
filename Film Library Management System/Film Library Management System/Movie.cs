using DataAccess.Entity;
using DataAccess.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Film_Library_Management_System
{
    
    public partial class Movie : Form
    {
        Admin admin;
        public Movie()
        {
            InitializeComponent();
        }

        public string IMDB { get; private set; }
        public string Language { get; private set; }
        public string Category { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            MovieDetails md = new MovieDetails();


            md.Name = txtName.Text;
            md.IMDB = txtimdb.Text;
            md.Language = txtLanguage.Text;
            md.Path = txtpath.Text;

            md.Category = cmbcat.Text;

            Operation op = new Operation();

           

            if (txtName.Text == "" || txtLanguage.Text == "" || txtimdb.Text == "")
            {
                MessageBox.Show("All the field must be fill");
            }
            else if(cmbcat.SelectedIndex == -1)
            {
                MessageBox.Show("Select Movie Type");
            }
            
            else
            {
                op.insert(md);
            }



        }
       

        private void lblback_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin = new Admin();
            admin.Show();
        }

        private void lblIMDB_Click(object sender, EventArgs e)
        {

        }
    }
}
