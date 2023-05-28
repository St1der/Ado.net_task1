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
                conn.Open();

                string insertQuery = "INSERT INTO Authors (Id,Firstname, Lastname) VALUES (@id,@firstName, @lastName)";

                using (SqlCommand command = new SqlCommand(insertQuery, conn))
                {
            
                    command.Parameters.AddWithValue("@id", idtextbox.Text);
                    command.Parameters.AddWithValue("@firstName", firstnametextbox.Text);
                    command.Parameters.AddWithValue("@lastName", lastnametextbox.Text);

                  
                    command.ExecuteNonQuery();
                }

 
                conn.Close();
            }

            idtextbox.Clear();
            firstnametextbox.Clear();
            lastnametextbox.Clear();

            MessageBox.Show("Elave edildi");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
