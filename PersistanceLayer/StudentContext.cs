using Microsoft.Data.SqlClient;
using StudentEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEx.PersistanceLayer
{
    public class StudentContext
    {
        public static void GetStudent(Student s)
        {
            SqlConnection connection = new SqlConnection("Server=(localdb)\\Sahithi;Database=Ldb1;User Id=sahithi;Password=sahithi;encrypt=false;");
            try
            {
                string d = s.Dob.ToString("yyyy-MM-dd");
                string insertcommand = ($"INSERT INTO Student(Name,Branch,RollNo,DoB,City) " + $"VALUES('{s.Name}','{s.Branch}',{s.RollNo},'{d}','{s.City}')");
                SqlCommand command = new SqlCommand(insertcommand,connection);
                connection.Open();
                int rdr = command.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public static void EditStudent(int id,Student s)
        {
            SqlConnection connection = new SqlConnection("Server=(localdb)\\Sahithi;Database=Ldb1;User Id=sahithi;Password=sahithi;encrypt=false");
            try
            {
                string d = s.Dob.ToString("yyyy-MM-dd");


                string updatecommand = $"update Student set Name='{s.Name}',Branch='{s.Branch}',RollNo={s.RollNo},DoB='{d}',City='{s.City}' Where Id ={id};";
                SqlCommand command = new SqlCommand(updatecommand,connection);
                connection.Open();
                int sdr = command.ExecuteNonQuery();
                //if (sdr >=0)
                //{
                //    connection.Close();


                //}

            }
            catch(Exception e)
            {
                throw;

            }
        }


        public static Student GetStudentById(int Id)
        {
            SqlConnection connection = new SqlConnection("Server=(localdb)\\Sahithi;Database=Ldb1;User Id=sahithi;Password=sahithi;encrypt=false");
            try
            {
                Student student = null;
                string select = $"select * from Student" + $" Where Id = '{Id}'; ";
                SqlCommand command = new SqlCommand(select,connection);
                connection.Open();
                SqlDataReader rdr = command.ExecuteReader();
                while(rdr.Read())
                {
                    student = new Student();
                    student.Id = int.Parse(rdr["Id"].ToString());
                    student.Name = rdr["Name"].ToString();
                    student.Branch = rdr["Branch"].ToString();
                    student.RollNo = int.Parse(rdr["RollNo"].ToString());
                    student.Dob = DateTime.Parse(rdr["Dob"].ToString());
                    student.City = rdr["City"].ToString();
                }
                connection.Close();
                return student;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public static List<Student> ListOfStudents()
        {
            List<Student> students = new List<Student>();
            SqlConnection connection = new SqlConnection("Server=(localdb)\\Sahithi;Database=Ldb1;User Id=sahithi;Password=sahithi;encrypt=false;");
            try
            {
                
                string selectcommand = "Select * from dbo.Student";
                SqlCommand command = new SqlCommand (selectcommand,connection);
                connection.Open();
                SqlDataReader rdr = command.ExecuteReader();
                while(rdr.Read())
                {
                    Student student = new Student();
                    student.Id = int.Parse(rdr["Id"].ToString());
                    student.Name = rdr["Name"].ToString();
                    student.Branch = rdr["Branch"].ToString();
                    student.RollNo = int.Parse(rdr["RollNo"].ToString());
                    student.Dob = DateTime.Parse(rdr["DoB"].ToString());
                    student.City = rdr["City"].ToString();

                    students.Add(student);
                }
                connection.Close();
                return students;
            }
            
            catch (Exception e)
            {
                throw;
            }
            
        }
    }
}
