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
    public partial class Change_Password : Form
    {
        Operation op = new Operation();
        public Change_Password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtu.Text == "" || txtnp.Text == "" )
            {
                MessageBox.Show("All the field must be fill");
            }
            else
            {
                op.Change_pass(txtnp.Text, txtu.Text);
                MessageBox.Show("Password Changed Successfully");
            }
                            
        }

        private void lblback_Click(object sender, EventArgs e)
        {
            User user = new User();
            this.Hide();
            user.Show();

        }
    }
}
