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
using ChatKekis.Classes;
using ChatKekis.Model;
using ChatKekis.Windows;

namespace ChatKekis
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Employee emp;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PsBPassword.Password) || string.IsNullOrEmpty(TxtLogin.Text))
            {
                MessageBox.Show("Error");
            }
            else
            {
                var auth = DBconnection.connect.Employee.Where(z=>z.Password == PsBPassword.Password && z.Username == TxtLogin.Text).FirstOrDefault();
                if (auth != null)
                {
                    emp = auth;
                    MainUserWindow win = new MainUserWindow(emp);
                    win.Show();
                    MessageBox.Show($"Welcome {auth.Name}");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
