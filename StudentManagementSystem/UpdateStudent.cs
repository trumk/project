using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class UpdateStudent : Form
    {
        public int SelectedPersonId { get; set; }
        private string selectedName;
        private string selectedAddress;
        private DateTime selectedDob;
        private string selectedSubject;
        private float selectedGrade;
        public UpdateStudent()
        {
            InitializeComponent();
        }

        public UpdateStudent(int selectedPersonId)
        {
            SelectedPersonId = selectedPersonId;
        }
      


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SetSelectedStudent(string name, string address, DateTime dob, string subject, float grade)
        {
            selectedName = name;
            selectedAddress = address;
            selectedDob = dob;
            selectedSubject = subject;
            selectedGrade = grade;

            
            txtName.Text = selectedName;
            txtAddress.Text = selectedAddress;
            datePick.Value = selectedDob;
            cbSubject.SelectedItem = selectedSubject;
            txtGrade.Text = selectedGrade.ToString();
        }

        public void LoadSubject()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=advanceAsm";
            string query = "SELECT subjectId, subjectName FROM subject";  
            DataTable dt = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            cbSubject.DisplayMember = "subjectName";
            cbSubject.ValueMember = "subjectId";  // ánh xạ giá trị của subjectId vào ValueMember
            cbSubject.DataSource = dt;
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (!Verify())
            {
                return;
            }

            string updatedName = txtName.Text;
            string updatedAddress = txtAddress.Text;
            DateTime updatedDob = datePick.Value;
            string updatedSubject = cbSubject.Text;
            float updatedGrade = float.Parse(txtGrade.Text);
            int selectedPersonId = SelectedPersonId;


            StudentService studentService = new StudentService();
            bool updateSuccessful = studentService.updateStudent(selectedPersonId, updatedName, updatedAddress, updatedDob, updatedSubject, updatedGrade);
            if (updateSuccessful)
            {
                MessageBox.Show("Student updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        bool Verify()
        {
            if (string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtAddress.Text) ||
                cbSubject.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void UpdateStudent_Load(object sender, EventArgs e)
        {
            LoadSubject();
        }
    }
}
