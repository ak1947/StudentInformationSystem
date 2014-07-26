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

namespace OBS_Interface_5
{
    /// <summary>
    /// Interaction logic for GirisEkrani.xaml
    /// </summary>
    public partial class AnaMenu : Window
    {
        public string studentID;
        public AnaMenu(string userName)
        {
            InitializeComponent();
            var ogrenciBilgileri = new OBS_Interface_5.Views.OgrenciBilgileri(userName);
            MenuIcerigi.Children.Insert(0, ogrenciBilgileri);
            studentID = userName;
        }

        private void OgrenciBilgileriMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuIcerigi.Children.Clear();
            var ogrenciBilgileri = new OBS_Interface_5.Views.OgrenciBilgileri(studentID);
            MenuIcerigi.Children.Insert(0, ogrenciBilgileri);
        }

        private void DersProgramMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuIcerigi.Children.Clear();
            var dersProgrami = new OBS_Interface_5.Views.DersProgrami();
            MenuIcerigi.Children.Insert(0, dersProgrami);
        }


        private void NotDurumDatabase_Click(object sender, RoutedEventArgs e)
        {
            MenuIcerigi.Children.Clear();
            var yariYilNotBilgileriDatabase = new OBS_Interface_5.Views.YariYilNotBilgileriDatabase(studentID);
            MenuIcerigi.Children.Insert(0, yariYilNotBilgileriDatabase);
        }

        private void TranskriptMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuIcerigi.Children.Clear();
            var transkriptBilgileri = new OBS_Interface_5.Views.TranskriptBilgileri(studentID);
            MenuIcerigi.Children.Insert(0, transkriptBilgileri);
        }
    }
}
