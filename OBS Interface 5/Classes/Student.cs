using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS_Interface_5.Classes
{
    public class Student
    {
        public string advisior { get; set; }
        public string department { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string student_id { get; set; }
        public string tc_no { get; set; }
        public string e_mail { get; set; }
        public string tell { get; set; }
        public string address { get; set; }
        public string sex { get; set; }
        public string birth_date { get; set; }
        public string military_status { get; set; }
        public string cepTel { get; set; }
        public string yakinTel { get; set; }
        public string yakinDerece { get; set; }
        public string image { get; set; }

        public Student() { }
        public Student(string advisior, string  department, string firstName, string lastName,
            string student_id, string tc_no, string e_mail, string tell, string address, string sex, string birth_date,
            string military_status,string cepTel, string yakinTel, string yakinDerece, string image)
        {
            this.advisior = advisior;
            this.department = department;
            this.firstName = firstName;
            this.lastName = lastName;
            this.student_id = student_id;
            this.tc_no = tc_no;
            this.e_mail = e_mail;
            this.tell = tell;
            this.address = address;
            this.sex = sex;
            this.birth_date = birth_date;
            this.military_status = military_status;
            this.cepTel = cepTel;
            this.yakinTel = yakinTel;
            this.yakinDerece = yakinDerece;
            this.image = image;
            
        }

        
    }
}
