using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;

namespace StudentManagementSystem
{
    class StudentService
    {
        MY_DB db = new MY_DB();


        public bool insertStudent(string personName, string personAddress, DateTime dob, string subject)
        {
            int nextId = Student.GetNextId(); 

            MySqlCommand command = new MySqlCommand("INSERT INTO `student`(`personId`, `personName`, `personAddress`, `dob`, `subjectId`) VALUES (@id, @name, @addr, @dob, @sub)", db.getConnection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = nextId;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = personName;
            command.Parameters.Add("@addr", MySqlDbType.VarChar).Value = personAddress;
            command.Parameters.Add("@dob", MySqlDbType.Date).Value = dob;
            command.Parameters.Add("@sub", MySqlDbType.VarChar).Value = subject;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                Student.IncrementNextId(); 
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }



        public bool updateStudent(int personId, string personName, string personAddress, DateTime dob, string subject, float? grade)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `student` SET personName = @name, personAddress = @address, dob = @dob, grade = @grade, subjectId = @sub WHERE personId = @ID", db.getConnection);

            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = personId;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = personName;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = personAddress;
            command.Parameters.Add("@dob", MySqlDbType.Date).Value = dob;
            command.Parameters.Add("@grade", MySqlDbType.Float).Value = grade.HasValue ? (object)grade.Value : DBNull.Value;
            command.Parameters.Add("@sub", MySqlDbType.VarChar).Value = subject;


            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }


        public bool deleteStudent(int personId)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `student` WHERE `personId` = @id", db.getConnection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = personId;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }


        public DataTable getStudent(MySqlCommand command)
        {
            command.Connection = db.getConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

    
    }
}
