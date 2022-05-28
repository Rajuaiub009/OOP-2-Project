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
    
    public partial class Admin : Form
    {
        Login login;
        Operation op = new Operation();


        public Admin()
        {
            InitializeComponent();
            Load_Gridview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login = new Login();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie();
            movie.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Admin_Load(object sender, EventArgs e)
        {

           

        }
        void Load_Gridview()
        {
           
            datagrdview.DataSource = op.Get_all();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Update update = new Update();
            update.Show();
            this.Hide();
        }

        private void datagrdview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
            var row = this.datagrdview.Rows[0];
            op.delete(row.Cells["MovieName"].Value.ToString());
            Load_Gridview();

        }

        private void button5_Click(object sender, EventArgs e)
        {
                this.datagrdview.DataSource = 
                op.search(this.txtsearch.Text);
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
