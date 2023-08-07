using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SQLApp
{
    public partial class FormRegister : Form
    {
        Point lastPoint;
        public FormRegister()
        {
            InitializeComponent();
            this.textBoxPasswordReg.AutoSize = false;
            this.textBoxPasswordReg.Size = new Size(this.textBoxPasswordReg.Size.Width, 77);
            textBoxFirstName.Text = "First name";
            textBoxLastName.Text = "Last name";
            textBoxLoginReg.Text = "Login";
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {


            DB db = new DB();
            String loginUser = textBoxLoginReg.Text;
            String passUser = md5.HashPassword(textBoxPasswordReg.Text);
            String firstNameUser = textBoxFirstName.Text;
            String lastNameUser = textBoxLastName.Text;

            if (loginUser == "Login")
            {
                MessageBox.Show("Whrite your login");
                return;
            }
            else if (passUser == String.Empty)
            {
                MessageBox.Show("Whrite your password");
                return;
            }
            else if (firstNameUser == "First name")
            {
                MessageBox.Show("Whrite your name");
                return;
            }
            else if (lastNameUser == "Last name")
            {
                MessageBox.Show("Whrite your surname");
                return;
            }

            if (CheckUserExistence() == true)
            {
                return;
            }

            db.OpenConnection();

            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`Firstname`,`Lastname`,`Login`,`Passwort`) VALUES (@FN,@LN,@Login,@Password)", db.GetConnection());
            command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = passUser;   
            command.Parameters.Add("@FN", MySqlDbType.VarChar).Value = firstNameUser;
            command.Parameters.Add("@LN", MySqlDbType.VarChar).Value = lastNameUser;


            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Account was successfully created");
            }
            else
            {
                MessageBox.Show("Account wasn't created");
            }


            db.CloseConnection();
        }

        public Boolean CheckUserExistence()
        { 
        String loginUser = textBoxLoginReg.Text;
        String passUser = textBoxPasswordReg.Text;

        DB db = new DB();
        DataTable table = new DataTable();
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `Login` = @lU", db.GetConnection());
        command.Parameters.Add("@lU", MySqlDbType.VarChar).Value = loginUser;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("This login already exists, please try another one");
                return true;
            }
            else
            {
                return false;
            }
        }



        private void labelXReg_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelXReg_MouseEnter(object sender, EventArgs e)
        {
            labelX.ForeColor = Color.Green;
        }

        private void labelXReg_MouseLeave(object sender, EventArgs e)
        {
            labelX.ForeColor = Color.White;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void textBoxFirstName_Enter(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text == "First name")
            {
                textBoxFirstName.Text = string.Empty;
            }
        }

        private void textBoxLastName_Enter(object sender, EventArgs e)
        {
            if (textBoxLastName.Text == "Last name")
            {
                textBoxLastName.Text = string.Empty;    

            }
        }

        private void textBoxLoginReg_Enter(object sender, EventArgs e)
        {
            if (textBoxLoginReg.Text == "Login")
            {
                textBoxLoginReg.Text = string.Empty;
            }
        }

        private void textBoxFirstName_Leave(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text == string.Empty)
            {
                textBoxFirstName.Text = "First name";
            }

        }

        private void textBoxLastName_Leave(object sender, EventArgs e)
        {
            if (textBoxLastName.Text == string.Empty)
            {
                textBoxLastName.Text = "Last name";
            }
        }

        private void textBoxLoginReg_Leave(object sender, EventArgs e)
        {
            if (textBoxLoginReg.Text == string.Empty)
            {
                textBoxLoginReg.Text = "Login";
            }
        }


        private void labelLoginLink_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }
    }
}
