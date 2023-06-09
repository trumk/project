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

namespace StudentManagementSystem
{
    public partial class Login_Form : Form
    {
        Thread th;
        public Login_Form()
        {
            InitializeComponent();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
          
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT users.*, roles.role_name FROM users INNER JOIN roles ON users.role_id = roles.role_id WHERE users.username = @usn AND users.password = @pass", db.getConnection);
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = txtUsn.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = txtPass.Text;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            try
            {
                if (string.IsNullOrEmpty(txtUsn.Text) || string.IsNullOrEmpty(txtPass.Text))
                {
                    MessageBox.Show("Please enter username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (table.Rows.Count > 0)
                {
                    string roleName = table.Rows[0]["role_name"].ToString();

                    if (roleName == "admin")
                    {
                        MessageBox.Show("Admin logged in");
                        th = new Thread(openMainForm);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                        this.Close();

                    }
                    else if (roleName == "teacher")
                    {
                        MessageBox.Show("Teacher logged in");
                    }
                    else if (roleName == "student")
                    {
                        MessageBox.Show("Student logged in");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }



        }

        //Sua loi could not copy
        private void openMainForm()
        {
            Application.Run(new MainForm());
        }
    }
}
