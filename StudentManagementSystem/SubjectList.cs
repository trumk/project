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
    public partial class SubjectList : Form
    {
        private int selectedSubjectId;
        private string selectedName;
        private string selectedNum;
        public SubjectList()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();  
        }

        SubjectService service = new SubjectService();
        private void loadSubjectData()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `subject`");
            subjectInf.ReadOnly = true;
            subjectInf.RowTemplate.Height = 50;
            subjectInf.DataSource = service.getSubject(command);
            subjectInf.AllowUserToAddRows = false;

            subjectInf.Columns["subjectId"].HeaderText = "Subject ID";
            subjectInf.Columns["subjectName"].HeaderText = "Subject Name";
            subjectInf.Columns["numLesson"].HeaderText = "Number Of Lesson";

       
            foreach (DataGridViewColumn column in subjectInf.Columns)
            {
                column.FillWeight = 1;
            }

            subjectInf.Columns[subjectInf.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private int selectedRowIndex = -1;

        private void SubjectList_Load(object sender, EventArgs e)
        {
            loadSubjectData();
            subjectInf.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            subjectInf.CellClick += (s, args) =>
            {
                if (args.RowIndex >= 0 && args.RowIndex < subjectInf.Rows.Count)
                {
                    selectedRowIndex = args.RowIndex;

                    DataGridViewRow selectedRow = subjectInf.Rows[args.RowIndex];
                    selectedSubjectId = Convert.ToInt32(selectedRow.Cells["subjectId"].Value);
                    selectedName = selectedRow.Cells["subjectName"].Value.ToString();
                    selectedNum = selectedRow.Cells["numLesson"].Value.ToString();
                }
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSubject addSub = new AddSubject();
            addSub.Show(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedName == null)
            {
                MessageBox.Show("Please select a student to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UpdateSubject updateForm = new UpdateSubject();
            updateForm.SetSelectedSubject(selectedName, selectedNum);
            updateForm.ShowDialog();

            loadSubjectData();
        }

        private void subjectInf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.subjectInf.Rows[e.RowIndex];
                selectedSubjectId = Convert.ToInt32(row.Cells["subjectId"].Value);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadSubjectData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this subjet?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SubjectService subjectService = new SubjectService();
                bool deleteSuccessful = subjectService.deleteSubject(selectedSubjectId);

                if (deleteSuccessful)
                {
                    MessageBox.Show("Subject deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete subject.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
