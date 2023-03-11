using ChatKekis.Classes;
using ChatKekis.Model;
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
using System.Windows.Shapes;

namespace ChatKekis.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainUserWindow.xaml
    /// </summary>
    public partial class MainUserWindow : Window
    {
        public static Employee _employee;
        public MainUserWindow(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            this.DataContext = _employee;
            LvChats.ItemsSource = DBconnection.connect.Chatroom.ToList();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSearchWindow win = new EmployeeSearchWindow(0);
            win.Show();
            this.Close();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void LvChats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var b = DBconnection.connect.EmployeeChat.Where(z => z.Employee_Id == _employee.Id_Employee).FirstOrDefault();
            if (b != null)
            {
                var a = ((sender as ListView).SelectedItem as Chatroom);
                ChatWindow win = new ChatWindow(a);
                win.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You are not a member of this chat", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
