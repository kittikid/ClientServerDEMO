using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using WpfApp.Base;

namespace WpfApp.Windows
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            Database = new CutlerysEntities();
            LoginCheck = 0;
        }

        private int _second;
        private DispatcherTimer timer;
        private CutlerysEntities Database;
        private int LoginCheck;

        public void DispatcherTimerSample()
        {
            _second = 0;
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _second++;
            LoginButton.Content = $"00:0{10 - _second}";

            if (_second == 10)
            {
                LoginButton.Content = "Login";
                LoginButton.IsEnabled = true;
                timer.Stop();
            }
        }

        public void CaptchaCreate()
        {
            string allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            string[] arr = allowchar.Split(a);
            string pwd = " ";
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {
                string temp = arr[(r.Next(0, arr.Length))];
                pwd += temp;
            }
            CaptchaText.Text = pwd.Trim();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            PasswordTextBox.Text = PasswordPasswrodBox.Password;
            
            try
            {
               if (CaptchaTextBox.Text != CaptchaText.Text) throw new Exception();
                
                User user = Database.User.Where((t) => t.UserLogin == LoginTextBox.Text && t.UserPassword == PasswordTextBox.Text).Single();
                MainWindow mainWindow = new MainWindow();
                Close();
                mainWindow.Show();
                LoginCheck = 0;
            } 
            catch
            {
                MessageBox.Show("Неверный ввод!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
                PasswordPasswrodBox.Password = "";
                ++LoginCheck;
                if (LoginCheck > 0) CaptchaCreate();
                switch (LoginCheck)
                {
                    case 1:
                        CaptchaPanel.Visibility = Visibility.Visible;
                        break;
                    case 2:
                        LoginButton.IsEnabled = false;
                        DispatcherTimerSample();
                        --LoginCheck;
                        break;
                }
            }
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }
    }
}
