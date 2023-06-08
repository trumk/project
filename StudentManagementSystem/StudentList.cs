using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StudentManagementSystem.Models;

namespace StudentManagementSystem
{
    public partial class StudentList : Form
    {
        private int selectedPersonId;
        private string selectedName;
        private string selectedAddress;
        private DateTime selectedDob;
        private string selectedSubject;
        private float selectedGrade;
        public StudentList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStudent addStu = new AddStudent();
            addStu.Show(this);
        }

        StudentService service = new StudentService();
        private int selectedRowIndex = -1;
        private void StudentList_Load(object sender, EventArgs e)
        {
            LoadStudentData();
            studentInf.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            studentInf.CellClick += (s, args) =>
            {
                if (args.RowIndex >= 0 && args.RowIndex < studentInf.Rows.Count)
                {
                    selectedRowIndex = args.RowIndex; 

                    DataGridViewRow selectedRow = studentInf.Rows[args.RowIndex];
                    selectedPersonId = Convert.ToInt32(selectedRow.Cells["personId"].Value);
                    selectedName = selectedRow.Cells["personName"].Value.ToString();
                    selectedAddress = selectedRow.Cells["personAddress"].Value.ToString();
                    selectedDob = Convert.ToDateTime(selectedRow.Cells["dob"].Value);
                    selectedSubject = selectedRow.Cells["subjectName"].Value.ToString();
                    float.TryParse(selectedRow.Cells["grade"].Value.ToString(), out selectedGrade);


                    UpdateStudent updateStudent = new UpdateStudent();
                    updateStudent.SelectedPersonId = selectedPersonId;
                }
            };
            
        }
        private void LoadStudentData()
        {

            MySqlCommand command = new MySqlCommand("SELECT student.personId, student.personName, student.personAddress, student.dob, student.grade, subject.subjectName FROM student INNER JOIN subject ON student.subjectId = subject.subjectId");
            studentInf.ReadOnly = true;
            studentInf.RowTemplate.Height = 50;
            studentInf.DataSource = service.getStudent(command);
            studentInf.AllowUserToAddRows = false;

            studentInf.Columns["personId"].HeaderText = "Student ID";
            studentInf.Columns["personName"].HeaderText = "Student Name";
            studentInf.Columns["personAddress"].HeaderText = "Address";
            studentInf.Columns["dob"].HeaderText = "Date of Birth";
            studentInf.Columns["grade"].HeaderText = "Grade";
            studentInf.Columns["subjectName"].HeaderText = "Subject Name";

            studentInf.Columns["subjectName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudentData();
        }


        private void studentInf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.studentInf.Rows[e.RowIndex];
                selectedPersonId = Convert.ToInt32(row.Cells["personId"].Value); 
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedName == null)
            {
                MessageBox.Show("Please select a student to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UpdateStudent updateForm = new UpdateStudent();
            updateForm.SetSelectedStudent(selectedName, selectedAddress, selectedDob, selectedSubject, selectedGrade);
            updateForm.ShowDialog();

            LoadStudentData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                StudentService studentService = new StudentService();
                bool deleteSuccessful = studentService.deleteStudent(selectedPersonId);

                if (deleteSuccessful)
                {
                    MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
