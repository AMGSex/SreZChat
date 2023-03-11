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
    /// Логика взаимодействия для ChangeTopicWindow.xaml
    /// </summary>
    public partial class ChangeTopicWindow : Window
    {
        Chatroom chatroomm;
        public ChangeTopicWindow(Chatroom chatroom)
        {
            InitializeComponent();
            chatroomm = chatroom;
            this.DataContext = chatroomm;
        }

        private void BtnSAve_Click(object sender, RoutedEventArgs e)
        {
            DBconnection.connect.SaveChanges();
            MessageBox.Show("Save");
            this.Close();
        }
    }
}
