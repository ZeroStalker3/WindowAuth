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
using WindowAuth.DataBase;

namespace WindowAuth
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            OdbConnectorHelper.odbobj = new AuthorDBEntities();

            if (CheckboxRemember.IsChecked == true)
            {
                LoginTxbLoginTxb.Text = Properties.Settings.Default.SaveLogin;
                PasswordBox.Password = Properties.Settings.Default.SavePassword;
            }
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы авторизовались как Гость");
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Переход на страницу Регистрации");
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = OdbConnectorHelper.odbobj.Users.FirstOrDefault(
                    x => x.Login == LoginTxbLoginTxb.Text && x.Password == PasswordBox.Password
                );
                if (userObj == null)
                {

                    MessageBox.Show("Такой пользователь отсутствует в приложения",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }
                else
                {
                    switch (userObj.Id)
                    {
                        case 1:
                            MessageBox.Show("Вы вошли", "Informations", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        //case 2:
                            
                        //    break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбор в работе приложения", "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
