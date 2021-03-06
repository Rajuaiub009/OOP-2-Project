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
    public partial class User : Form
    {

        Operation op = new Operation();

        public User()
        {
            InitializeComponent();
            Load_gridview();
            Wmp.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        void Load_gridview()
        {
            dtgridview.DataSource = op.Get_all();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            var row = this.dtgridview.Rows[0];
            this.Wmp.URL = row.Cells["Path"].Value.ToString();
            Wmp.Show();
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.dtgridview.DataSource = 
            op.Get_allbycategory("Hollywood");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Load_gridview();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.dtgridview.DataSource =
            op.search(this.textBox1.Text);
            

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.dtgridview.DataSource =
            op.Get_allbycategory("Bollywood");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Change_Password cp = new Change_Password();
            this.Hide();
            cp.Show();
        }
    }
}
