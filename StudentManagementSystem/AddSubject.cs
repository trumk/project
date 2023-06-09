using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagementSystem.Models;
using StudentManagementSystem.Builders;

namespace StudentManagementSystem
{
    public partial class AddSubject : Form
    {
        public AddSubject()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string subjectName = txtName.Text;
            string numLesson = txtNum.Text;

            SubjectConcreteBuilder subBuild = new SubjectConcreteBuilder();

            if (int.TryParse(numLesson, out int numLessonInt))
            {

                Subject subject = subBuild.SetSubjectName(subjectName)
                                          .SetNumLesson(numLessonInt)
                                          .Build();   
                SubjectService service = new SubjectService();

                if (Verify())
                {
                    if (string.IsNullOrEmpty(subjectName) || string.IsNullOrEmpty(numLesson))
                    {
                        MessageBox.Show("Please fill in all the required information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (service.insertSubject(subjectName, numLessonInt))
                        {
                            MessageBox.Show("New subject added", "Add subject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error", "Add subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                txtName.Text = "";
                txtNum.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid number of lessons", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool Verify()
        {
            if (string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtNum.Text) )
            
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
