using MySql.Data.MySqlClient;
using StudentManagementSystem.Models;
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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string personName = txtName.Text;
            string personAddress = txtAddress.Text;
            DateTime dob = datePick.Value;
            string subject = cbSubject.SelectedItem.ToString();

            
            Student student = new Student(0, personName, personAddress, dob, subject);
            StudentService service = new StudentService();

            if (Verify())
            {
                if (string.IsNullOrEmpty(personName) || string.IsNullOrEmpty(personAddress) || cbSubject.SelectedItem == null || dob == DateTime.MinValue)
                {
                    MessageBox.Show("Please fill in all the required information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (service.insertStudent(personName, personAddress, dob, cbSubject.SelectedValue.ToString()))
                    {
                        MessageBox.Show("New student added", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            txtName.Text = "";
            txtAddress.Text = "";
            cbSubject.SelectedIndex = -1;
            datePick.Value = DateTime.Now;
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

        private void AddStudent_Load(object sender, EventArgs e)
        {
            LoadSubject();
        }

        private void LoadSubject()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=advanceAsm";
            string query = "SELECT subjectId, subjectName FROM subject";  // Thêm subjectId vào truy vấn để ánh xạ giá trị
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
            cbSubject.ValueMember = "subjectId";  // Ánh xạ giá trị của subjectId vào ValueMember
            cbSubject.DataSource = dt;
        }
    }
}
