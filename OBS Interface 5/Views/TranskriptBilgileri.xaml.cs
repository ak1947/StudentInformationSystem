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
using System.Data.SqlClient;
using System.Collections;
using OBS_Interface_5.Classes;
using System.Windows.Controls.Primitives;

namespace OBS_Interface_5.Views
{
    /// <summary>
    /// Interaction logic for TranskriptBilgileri.xaml
    /// </summary>
    public partial class TranskriptBilgileri : UserControl
    {
        private string studentID;
        private List<ListView> notListViewList;
        private List<StackPanel> stackPanelList;
        private List<TextBlock> txtBlockOrtalamaList;
        int yariyilSayisi;
        public TranskriptBilgileri(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
            notListViewList = new List<ListView>();
            stackPanelList = new List<StackPanel>();
            txtBlockOrtalamaList = new List<TextBlock>();
            notListViewList.Add(notListView1);
            notListViewList.Add(notListView2);
            notListViewList.Add(notListView3);
            notListViewList.Add(notListView4);
            notListViewList.Add(notListView5);
            notListViewList.Add(notListView6);
            notListViewList.Add(notListView7);
            notListViewList.Add(notListView8);
            stackPanelList.Add(stackPanel1);
            stackPanelList.Add(stackPanel2);
            stackPanelList.Add(stackPanel3);
            stackPanelList.Add(stackPanel4);
            stackPanelList.Add(stackPanel5);
            stackPanelList.Add(stackPanel6);
            stackPanelList.Add(stackPanel7);
            stackPanelList.Add(stackPanel8);
            ShowListViews();
            ListViewsFill();
            AddTextBlock();
        }

        public int FetchYariyilSayisi(){
            SqlCommand cmd;
            DatabaseConnection db;
            db = new DatabaseConnection();
            db.OpenConnection();
            SqlDataReader rdr;
            SqlConnection conn = db.getConnection();
            string sql = string.Format("SELECT yearTerm " +
                                        "FROM SECTION_GRADE " +
                                        "WHERE studentID='{0}' " +
                                        "GROUP BY yearTerm;", studentID);
            cmd = new SqlCommand(sql, conn);
            rdr = cmd.ExecuteReader();
            int rowCount=0;
            while (rdr.Read())
            {
                rowCount++;
            }
            
            yariyilSayisi = rowCount;
            return yariyilSayisi;
        }
        public void ShowListViews() 
        {
            int yariyilSayisi = FetchYariyilSayisi();
            for (int i = 0; i < yariyilSayisi; i++)
            {
                stackPanelList[i].Visibility = Visibility.Visible;
            }
        }
        public void ListViewsFill()
        {
            int yariyil = 1;
            int season = 1;
            SqlCommand cmd;
            DatabaseConnection db;
            db = new DatabaseConnection();
            db.OpenConnection();
            SqlConnection conn = db.getConnection();
            for (int i = 0; i < yariyilSayisi; i++)
            {
                SqlDataReader rdr;
                List<Notlar> list = new List<Notlar>();
                string sql = string.Format("SELECT courseCode, courseName, midterm, final, average, grade_level, grade " +
                                        "FROM SECTION_GRADE WHERE studentID='{0}' " +
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
                notListViewList[i].ItemsSource = list;
                season--;
                if (season==-1)
                {
                    season = 1;
                    yariyil++;
                }
                rdr.Close();
            }
        }

        public void AddTextBlock()
        {
            for (int i = 0; i < stackPanelList.Count; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Width = stackPanel1.Width;
                tb.Height = 30;
                tb.Text = "TEST";
                txtBlockOrtalamaList.Add(tb);
                stackPanelList[i].Children.Add(tb);
            }
        }

    }
}
