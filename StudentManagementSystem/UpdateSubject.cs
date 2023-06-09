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
    public partial class UpdateSubject : Form
    {
        public int SelectedSubjectId { get; set; }
        private int selectedSubjectId;
        private string selectedName;
        private string selectedNum;
        public UpdateSubject()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SetSelectedSubject(string name, string num)
        {
            selectedName = name;
            selectedNum = num;

            txtNameSub.Text = selectedName;
            txtNumLesson.Text = selectedNum;
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            string updatedName = txtNameSub.Text;
            string updatedNum = txtNumLesson.Text;

            if (!int.TryParse(updatedNum, out int updatedNumInt))
            {
                MessageBox.Show("Invalid number of lessons.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SubjectService subjectService = new SubjectService();
            bool updateSuccessful = subjectService.updateSubject(selectedSubjectId, updatedName, updatedNumInt);
            if (updateSuccessful)
            {
                MessageBox.Show("Subject updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update subject.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
