using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.Sqlite;

namespace SQLiteAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataAccess1.InitializeDatabase();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            string CustomerData = "";

            foreach (string data in DataAccess1.GetData())
            {
                CustomerData = CustomerData + data + "\n";
            }
            MessageBox.Show(CustomerData, "All Customer Data");

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DataAccess1.AddData(txtCustomer.Text, txtFirstname.Text, txtLastname.Text, txtMail.Text);
            MessageBox.Show("Your data has been Added");
            txtCustomer.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtMail.Text = "";
        }
    }
}
