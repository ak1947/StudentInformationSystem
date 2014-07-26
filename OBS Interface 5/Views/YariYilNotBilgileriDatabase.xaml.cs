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
using System.Collections;
using OBS_Interface_5.Classes;

namespace OBS_Interface_5.Views
{
    /// <summary>
    /// Interaction logic for YariYilNotBilgileriDatabase.xaml
    /// </summary>
    public partial class YariYilNotBilgileriDatabase : UserControl
    {
        private string studentID;
        public YariYilNotBilgileriDatabase(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
            notListView.ItemsSource = notGoruntule(1, 1);
        }

        public ArrayList notGoruntule(int yariyil, int season) 
        {
            ArrayList list = new ArrayList();
            SqlCommand cmd;
            DatabaseConnection db;
            db = new DatabaseConnection();
            db.OpenConnection();
            SqlDataReader rdr;
            SqlConnection conn = db.getConnection();
            string sql = string.Format("SELECT courseCode, courseName, midterm, final, average, grade_level, grade " +
                                        "FROM SECTION_GRADE WHERE studentID='{0} ' " +
                                        "AND substring(courseCode,4,1)='{1}' " +
                                        "AND SUBSTRING(courseCode,6,1)%2={2};", studentID, yariyil, season);
            cmd = new SqlCommand(sql, conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new Notlar(rdr.GetValue(0).ToString(),
                                    rdr.GetValue(1).ToString(), 
                                    rdr.GetValue(2).ToString(), 
                                    rdr.GetValue(3).ToString(), 
                                    rdr.GetValue(4).ToString(), 
                                    rdr.GetValue(5).ToString(),
                                    rdr.GetValue(6).ToString()
                                    ));
            }
            return list;
        }

        private void yariYilComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (notListView!=null)
            {
                if (yariYilComboBox.SelectedIndex%2==0)
                {
                    notListView.ItemsSource = notGoruntule(yariYilComboBox.SelectedIndex + 1, 1);
                }
                else
                {
                    notListView.ItemsSource = notGoruntule(yariYilComboBox.SelectedIndex + 1, 0);
                }
                switch (yariYilComboBox.SelectedIndex)
                {
                    case 0:
                        notListView.ItemsSource = notGoruntule(1, 1);
                        break;
                    case 1:
                        notListView.ItemsSource = notGoruntule(1, 0);
                        break;
                    case 2:
                        notListView.ItemsSource = notGoruntule(2, 1);
                        break;
                    case 3:
                        notListView.ItemsSource = notGoruntule(2, 0);
                        break;
                    case 4:
                        notListView.ItemsSource = notGoruntule(3, 1);
                        break;
                    case 5:
                        notListView.ItemsSource = notGoruntule(3, 0);
                        break;
                    case 6:
                        notListView.ItemsSource = notGoruntule(4, 1);
                        break;
                    case 7:
                        notListView.ItemsSource = notGoruntule(4, 0);
                        break;
                    default:
                        notListView.ItemsSource = notGoruntule(1, 1);
                        break;
                }
                
            }
            
        }

        private void btnTumu_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
