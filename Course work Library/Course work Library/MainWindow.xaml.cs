using Course_work_Library.BookModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Course_work_Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
        }
        public MainWindow(string pathToBooks)
        {

        }
        private void MainWindows_OnMouseDown(object sender,MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void PackIconBoxIconsExit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void bthSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SingIn.SingIn.CheckUser(txtUsername.Text, txtPassword.Password);
                Window window = new Window1();
                this.Close();
                window.Show();
            }
            catch (Exception)
            {

                MessageBox.Show("Username or password is incorrect");
            }
        }

        private void PackIconBoxIcons_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }


    }
}
