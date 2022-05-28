using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccess.Operation
{
    public class Operation
    {
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-EAB1MTR7;Initial Catalog=Film_Library;Integrated Security=True");

        public void insert (MovieDetails md)
        {
            
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM MovieDetails WHERE MovieName ='" + md.Name + "'", connection);
            

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            int i = dataset.Tables[0].Rows.Count;
            if (i > 0)
            {
                MessageBox.Show("Movie Name " + md.Name + " is already exist.\nPlease Enter an Unique Username");
                dataset.Clear();
                
            }
            else
            {
                
                SqlCommand cmd = new SqlCommand("INSERT INTO MovieDetails (MovieName , Language, IMDB, Category, Path) values ('" + md.Name + "', '"+ md.Language +"','" + md.IMDB +"','" +md.Category+"' ,'"+ md.Path +"')" , connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                adp.Fill(dt);
                MessageBox.Show("Successully Inserted");

            }
        }
        public void update(MovieUpdate mu)
        {
            
            SqlCommand cmd = new SqlCommand("UPDATE MovieDetails SET IMDB= '" + mu.IMDB + "' WHERE MovieName = '" + mu.Name + "'" , connection);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            adp.Fill(dt);
            MessageBox.Show("Successfully Updated");

        }
        public void delete(string mn)
        {
            SqlCommand cmd = new SqlCommand("DELETE MovieDetails  WHERE MovieName = '" + mn + "'", connection);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            adp.Fill(dt);
            MessageBox.Show("Successfully Deleted");

        }
        public object search(string s)
        {
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-EAB1MTR7;Initial Catalog=Film_Library;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM MovieDetails WHERE MovieName LIKE '%"+s+"%'", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        
        public object Get_all()
        {
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-EAB1MTR7;Initial Catalog=Film_Library;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM MovieDetails", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public object Get_allbycategory(string c)
        {
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-EAB1MTR7;Initial Catalog=Film_Library;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM MovieDetails WHERE Category = '"+c+"'", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public object Change_pass(string p , string n)
        {
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-EAB1MTR7;Initial Catalog=Film_Library;Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE User_info SET Password= '" + p + "' WHERE Username = '" + n + "'" , connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }

    
}
