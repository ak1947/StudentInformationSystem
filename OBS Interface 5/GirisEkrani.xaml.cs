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
using System.Data;
using System.Data.SqlClient;


namespace OBS_Interface_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GirisEkrani : Window
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }

        
        private void GirisBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd;
            DatabaseConnection db;
            db = new DatabaseConnection();
            db.OpenConnection();
            SqlDataReader rdr;
            SqlConnection conn = db.getConnection();
            String sql = String.Format("SELECT student_id, tc_no FROM STUDENT WHERE student_id='{0}' AND tc_no='{1}';", 
                usernameText.Text, passwordText.Password);
            cmd = new SqlCommand(sql, conn);
            try
            {
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {  
                    string userName = rdr.GetValue(0).ToString();
                    AnaMenu m = new AnaMenu(userName);
                    rdr.Close();
                    m.Show();
                    this.Close();
                }
                else
                {
                    errorLabel.Content = "Kullanıcı adı veya parola hatalı!";
                    errorLabel.Height = 25;
                    SolidColorBrush brush = new SolidColorBrush(Colors.Red);
                    errorLabel.Foreground = brush;
                }

            }
            catch (Exception)
            {

                errorLabel.Content = "Server Bakımda!";
                errorLabel.Height = 25;
                SolidColorBrush brush = new SolidColorBrush(Colors.Red);
                errorLabel.Foreground = brush;

            }
            

        }

        private void passwordText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //PerformClick Metodu yerine WPF'de bunu kullanabiliyoruz
                GirisBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void usernameText_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //errorLabel.Height = 0;
        }
    }

}
