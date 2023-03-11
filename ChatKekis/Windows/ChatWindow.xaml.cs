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
using System.Windows.Threading;

namespace ChatKekis.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        public Employee employee;
        public Chatroom chatroomm;
        public EmployeeChat roomChat;
        public ChatMessage message;
        DispatcherTimer timer = new DispatcherTimer();
        public ChatWindow(Chatroom chatroom)
        {
            InitializeComponent();
            var chat = chatroom.Id_Chatroom;
            LvUser.ItemsSource = DBconnection.connect.EmployeeChat.Where(z => z.Chatroom_Id == chat).ToList();
            chatroomm = chatroom;
            this.DataContext = chatroomm;
            LvMessages.ItemsSource = DBconnection.connect.ChatMessage.Where(z => z.Chatroom_Id == chatroom.Id_Chatroom).ToList();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSearchWindow win = new EmployeeSearchWindow(chatroomm.Id_Chatroom);
            win.Show();
            this.Close();
            timer.Stop();
        }
        private void Refresh()
        {
            LvMessages.ItemsSource = null;
            LvMessages.ItemsSource = DBconnection.connect.ChatMessage.Where(z => z.Chatroom_Id == chatroomm.Id_Chatroom).ToList();
        }
        private void BtnChangeTopic_Click(object sender, RoutedEventArgs e)
        {
            ChangeTopicWindow changeTopic = new ChangeTopicWindow(chatroomm);
            changeTopic.Show();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtMessage.Text))
            {
                MessageBox.Show("You can't send an empty message!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var message = new ChatMessage()
                {
                    Sender_Id = MainUserWindow._employee.Id_Employee,
                    Chatroom_Id = chatroomm.Id_Chatroom,
                    Date = DateTime.Now,
                    Message = TxtMessage.Text,
                };
                DBconnection.connect.ChatMessage.Add(message);
                DBconnection.connect.SaveChanges();
                Refresh();
                TxtMessage.Text = "";
            }
        }

        private void LeaveChatroom_Click(object sender, RoutedEventArgs e)
        {
            employee = MainUserWindow._employee;
            MainUserWindow win = new MainUserWindow(employee);
            win.Show();
            this.Close();
            timer.Stop();
        }
    }
}
