using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApp10
{
    public partial class insert : Window
    {
        SqlConnection conn;
        string cs = "";
        public insert()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                cs = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                conn.ConnectionString = cs;

                string insertQuery = "INSERT INTO Authors (Id, Firstname, Lastname) VALUES (@id, @firstName, @lastName)";
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.InsertCommand = new SqlCommand(insertQuery, conn);
                adapter.InsertCommand.Parameters.AddWithValue("@id", idtextbox.Text);
                adapter.InsertCommand.Parameters.AddWithValue("@firstName", firstnametextbox.Text);
                adapter.InsertCommand.Parameters.AddWithValue("@lastName", lastnametextbox.Text);

                conn.Open();
                int rowsAffected = adapter.InsertCommand.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                    MessageBox.Show("Elave edildi");
                else
                    MessageBox.Show("Elave edilemedi");
            }

            idtextbox.Clear();
            firstnametextbox.Clear();
            lastnametextbox.Clear();

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
