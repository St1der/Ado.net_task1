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

                string deleteQuery = "DELETE FROM Authors WHERE Id = @id AND Firstname = @firstName AND Lastname = @lastName";
                SqlDataAdapter adapter = new SqlDataAdapter(deleteQuery, conn);

                adapter.SelectCommand.Parameters.AddWithValue("@id", idtextbox.Text);
                adapter.SelectCommand.Parameters.AddWithValue("@firstName", firstnametextbox.Text);
                adapter.SelectCommand.Parameters.AddWithValue("@lastName", lastnametextbox.Text);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                int rowsAffected = dataTable.Rows.Count;

                if (rowsAffected > 0)
                    MessageBox.Show("melumat artiq silinib.");
                else
                    MessageBox.Show("melumat tapila bilmedi.");
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