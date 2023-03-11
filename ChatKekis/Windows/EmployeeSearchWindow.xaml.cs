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
    /// Логика взаимодействия для EmployeeSearchWindow.xaml
    /// </summary>
    public partial class EmployeeSearchWindow : Window
    {
        int CurrentChatroom;
        public EmployeeSearchWindow(int chatroom)
        {
            InitializeComponent();
            LvEmployee.ItemsSource = DBconnection.connect.Employee.ToList();
            CurrentChatroom = chatroom;
        }
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LvEmployee.ItemsSource = DBconnection.connect.Employee.Where(z => z.Name.Contains(TxtSearch.Text)).ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeeChat addemployee = new EmployeeChat();
            addemployee.Chatroom_Id = CurrentChatroom;
            var a = LvEmployee.SelectedItem as Employee;
            var b = DBconnection.connect.Employee.Where(z => z.Id_Employee == a.Id_Employee).FirstOrDefault();
            addemployee.Employee_Id = b.Id_Employee;
            DBconnection.connect.EmployeeChat.Add(addemployee);
            DBconnection.connect.SaveChanges();
            MessageBox.Show("Saved!");
        }
    }
}
