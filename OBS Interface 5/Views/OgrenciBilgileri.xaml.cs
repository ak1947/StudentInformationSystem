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
using OBS_Interface_5.Classes;
using OBS_Interface_5;
using System.IO;
using System.Drawing;
using Microsoft.Win32;
using System.Data;

namespace OBS_Interface_5.Views
{
    /// <summary>
    /// Interaction logic for OgrenciBilgileri.xaml
    /// </summary>
    public partial class OgrenciBilgileri : UserControl
    {
        private string studentID, email, evTel, cepTel, yakinTel, yakinDerece;
        public OgrenciBilgileri(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
            ArayuzOlustur();
        }

        public void ArayuzOlustur() 
        {
            Student student = getOgrenciBilgileri(studentID);
            studentIDLabel.Content = student.student_id;
            TCLabel.Content = student.tc_no;
            studentNameLabel.Content = student.firstName;
            studentLastNameLabel.Content = student.lastName;
            eMailLabel.Content = student.e_mail;
            MilitaryStatusLabel.Content = student.military_status;
            studentSexLabel.Content = student.sex;
            studentBirthLabel.Content = student.birth_date;
            evTelLabel.Content = student.tell;
            cepTelLabel.Content = student.cepTel;
            yakinTelLabel.Content = student.yakinTel;
            yakinDereceLabel.Content = student.yakinDerece;

            Staff staff = getDanismanBilgileri(this.studentID);
            staffNameLabel.Content = staff.name;
            staffLastNameLabel.Content = staff.lastName;
            staffUnvanLabel.Content = staff.unvan;
            staffTelLabel.Content = staff.tel;
            staffEMailLabel.Content = staff.eMail;

            ShowImage(this.studentID);

        }

        public Student getOgrenciBilgileri(string studentID) 
        {

            DatabaseConnection db = new DatabaseConnection();
            db.OpenConnection();
            Student student = db.getStudentInformation(studentID, db.getConnection());
            return student;
        }

        public Staff getDanismanBilgileri(string studentID)
        {

            DatabaseConnection db = new DatabaseConnection();
            db.OpenConnection();
            Staff staff = db.getDanismanInformation(studentID, db.getConnection());
            return staff;
        }

        public void ShowImage(string studentID)
        {
            SqlCommand cmd;
            DatabaseConnection db;
            db = new DatabaseConnection();
            db.OpenConnection();
            SqlDataReader rdr;
            SqlConnection conn = db.getConnection();
            string sql = String.Format("SELECT image " +
                                       "FROM STUDENT " +
                                       "WHERE STUDENT.student_id='{0}';", studentID);
            cmd = new SqlCommand(sql, conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                byte[] picData = rdr.GetValue(0) as byte[];
                if (picData != null)
                {
                    
                        MemoryStream ms = new MemoryStream(picData, 0, picData.Length);
                        ms.Write(picData, 0, picData.Length);
                        ms.Seek(0, SeekOrigin.Begin);
                        System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                        Bitmap bmp = new Bitmap(ms);
                        BitmapSource bmsource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                        imgStudentPicture.Source = bmsource;
                        imgStudentPicture.Stretch = Stretch.UniformToFill;
                        pictureBorder.Width = imgStudentPicture.Width;
                    

                }

            }
        }

        private void btnPictureChange_Click(object sender, RoutedEventArgs e)
        {
            string filePath;
            byte[] imageData;
            int maxImageSize = 1000000;
            SqlCommand cmd = new SqlCommand(); ;
            DatabaseConnection db;
            db = new DatabaseConnection();
            db.OpenConnection();
            SqlConnection conn = db.getConnection();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {
                filePath = dialog.FileName;
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes(maxImageSize);
                cmd.Connection = conn;
                cmd.CommandText = @"UPDATE STUDENT SET image=@imageData WHERE student_id=@studentID;";
                cmd.Parameters.Add("@imageData", SqlDbType.VarBinary, 10000000);
                cmd.Parameters.Add("@studentID", SqlDbType.NChar, 10);
                cmd.Prepare();
                cmd.Parameters["@imageData"].Value = imageData;
                cmd.Parameters["@studentID"].Value = studentID;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Upload failed!", "Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            ShowImage(this.studentID);
        }

        private void imgStudentPicture_MouseEnter(object sender, MouseEventArgs e)
        {
            btnPictureChange.Opacity = 0.8;
        }

        private void imgStudentPicture_MouseLeave(object sender, MouseEventArgs e)
        {
            btnPictureChange.Opacity = 0.5;
        }

        private void btnPictureChange_MouseEnter(object sender, MouseEventArgs e)
        {
            btnPictureChange.Opacity = 1;
        }

        private void btnPictureChange_MouseLeave(object sender, MouseEventArgs e)
        {
            btnPictureChange.Opacity = 0.8;
        }

        private void btnIletisimGuncelle_Click(object sender, RoutedEventArgs e)
        {
            eMailTextBox.Visibility = Visibility.Visible;
            evTelTextBox.Visibility = Visibility.Visible;
            cepTelTextBox.Visibility = Visibility.Visible;
            yakinTelTextBox.Visibility = Visibility.Visible;
            yakinDereceTextBox.Visibility = Visibility.Visible;
            eMailTextBox.Text = eMailLabel.Content.ToString();
            evTelTextBox.Text = evTelLabel.Content.ToString();
            cepTelTextBox.Text = cepTelLabel.Content.ToString();
            yakinTelTextBox.Text = yakinTelLabel.Content.ToString();
            yakinDereceTextBox.Text = yakinDereceLabel.Content.ToString();
            btnIletisimGuncelle.Visibility = Visibility.Hidden;
            btnTamamIletisim.Visibility = Visibility.Visible;
        }

        private void btnTamamIletisim_Click(object sender, RoutedEventArgs e)
        {
            email = eMailTextBox.Text;
            evTel = evTelTextBox.Text;
            cepTel = cepTelTextBox.Text;
            yakinTel = yakinTelTextBox.Text;
            yakinDerece = yakinDereceTextBox.Text;
            SqlCommand cmd;
            DatabaseConnection db;
            db = new DatabaseConnection();
            db.OpenConnection();
            SqlConnection conn = db.getConnection();
            string sql = String.Format("UPDATE STUDENT " +
                                       "SET e_mail='{0}', tell='{1}', cepTel='{2}', yakinTel='{3}', yakinDerece='{4}' " +
                                       "WHERE STUDENT.student_id='{5}';", email, evTel, cepTel, yakinTel, yakinDerece, studentID);
            cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                eMailLabel.Content = email;
                evTelLabel.Content = evTel;
                cepTelLabel.Content = cepTel;
                yakinTelLabel.Content = yakinTel;
                yakinDereceLabel.Content = yakinDerece;
                eMailTextBox.Visibility = Visibility.Hidden;
                evTelTextBox.Visibility = Visibility.Hidden;
                cepTelTextBox.Visibility = Visibility.Hidden;
                yakinTelTextBox.Visibility = Visibility.Hidden;
                yakinDereceTextBox.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
                MessageBox.Show("Güncelleme Hatası!", "Hata!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            btnIletisimGuncelle.Visibility = Visibility.Visible;
            btnTamamIletisim.Visibility = Visibility.Hidden;

        }

        


    }
}
