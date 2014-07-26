using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using OBS_Interface_5.Classes;
using System.Windows;

namespace OBS_Interface_5
{
    class DatabaseConnection
    {
        private SqlConnection conn;

        public DatabaseConnection()
        {
            conn = new SqlConnection(@"Server= .\; Integrated Security= true; Database=obs_nisan_6");
        }

        public SqlConnection OpenConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        public SqlConnection CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return conn;
        }
        public SqlConnection getConnection() {
            return conn;
        }

        public Student getStudentInformation(string studentID, SqlConnection conn)
        {
            string sql = String.Format("SELECT * FROM STUDENT WHERE student_id='{0}';",
                studentID);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rdr;
            Student student = new Student();
            try
            {
                rdr = cmd.ExecuteReader();
                rdr.Read();
                student.advisior = rdr.GetValue(0).ToString();
                student.department = rdr.GetValue(1).ToString();
                student.firstName = rdr.GetValue(2).ToString();
                student.lastName = rdr.GetValue(3).ToString();
                student.student_id = rdr.GetValue(4).ToString();
                student.tc_no = rdr.GetValue(5).ToString();
                student.e_mail = rdr.GetValue(6).ToString();
                student.tell = rdr.GetValue(7).ToString();
                student.address = rdr.GetValue(8).ToString();
                student.sex = rdr.GetValue(9).ToString();
                student.birth_date = rdr.GetValue(10).ToString();
                student.military_status = rdr.GetValue(11).ToString();
                student.image = rdr.GetValue(12).ToString();
                student.cepTel = rdr.GetValue(13).ToString();
                student.yakinTel = rdr.GetValue(14).ToString();
                student.yakinDerece = rdr.GetValue(15).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Server Bakımda!");

            }
            return student;

        }

        public Staff getDanismanInformation(string studentID, SqlConnection conn)
        {
            string sql = String.Format("SELECT bölüm, ad, soyad, sicil_no, unvan, STAFF.tc_no, email, tel, adres " +
                                       "FROM STAFF, STUDENT " +
                                       "WHERE STUDENT.student_id='{0}' AND STUDENT.advisor=STAFF.sicil_no;", studentID);
            Staff staff = new Staff();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rdr;
            try
            {
                rdr = cmd.ExecuteReader();
                rdr.Read();
                staff.department = rdr.GetValue(0).ToString();
                staff.name = rdr.GetValue(1).ToString();
                staff.lastName = rdr.GetValue(2).ToString();
                staff.sicilNo = rdr.GetValue(3).ToString();
                staff.unvan = rdr.GetValue(4).ToString();
                staff.tcNo = rdr.GetValue(5).ToString();
                staff.eMail = rdr.GetValue(6).ToString();
                staff.tel = rdr.GetValue(7).ToString();
                staff.address = rdr.GetValue(8).ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Server bakımda..");
            }

            return staff;
        }
    }
}
