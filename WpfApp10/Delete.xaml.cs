using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApp10
{
    public partial class Delete : Window
    {
        SqlConnection conn;
        string cs = "";
        public Delete()
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
                string deleteQuery = "DELETE FROM Authors WHERE  Id = @id  AND Firstname = @firstName AND Lastname = @lastName";

                using (SqlCommand command = new SqlCommand(deleteQuery, conn))
                {
                    command.Parameters.AddWithValue("@id", idtextbox.Text);
                    command.Parameters.AddWithValue("@firstName", firstnametextbox.Text);
                    command.Parameters.AddWithValue("@lastName", lastnametextbox.Text);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)MessageBox.Show("melumat artiq silinib.");
                    else MessageBox.Show("melumat tapila bilmedi.");   
                }
                conn.Close();
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