using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
   class SubjectService
    {
        MY_DB db = new MY_DB();
        public DataTable getSubject(MySqlCommand command)
        {
            command.Connection = db.getConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        public bool insertSubject(string subjectName, int numLesson)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `subject`(`subjectName`, `numLesson`) VALUES (@subname, @num)", db.getConnection);


            command.Parameters.Add("@subname", MySqlDbType.VarChar).Value = subjectName;
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = numLesson;

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

        public bool updateSubject(int subjectId, string subjectName, int numLesson)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `subject` SET `subjectName` = @subname, `numLesson` = @num WHERE `subjectId` = @id", db.getConnection);

            command.Parameters.Add("@subname", MySqlDbType.VarChar).Value = subjectName;
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = numLesson;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = subjectId;

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

        public bool deleteSubject(int personId)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `subject` WHERE `subjectId` = @id", db.getConnection);
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
    }
}
