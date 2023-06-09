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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentList studentList = new StudentList();
            studentList.Show(this);
        }

        private void subjectListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubjectList subjectList = new SubjectList();
            subjectList.Show(this);
        }
    }
}
