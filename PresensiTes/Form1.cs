using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PresensiTes
{
    public partial class Login : Form
    {
        // instance class
        Komponen kom = new Komponen();
        Functions fn = new Functions();
        //Pilihan Login
        private string[] tipeLogin = { "Admin", "Guru" };
        //Data Login
        public static string setValueUsername = "";
        public static string setValuePassword = "";
        public static string setJenisLogin = "";

        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(tipeLogin);
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (txUsername.Text != "" && txPassword.Text != "" && comboBox1.Text != "")
            {
                setValueUsername = txUsername.Text;
                setValuePassword = fn.Crypt2(txPassword.Text);
                setJenisLogin = comboBox1.Text;
                string namaProcedure = "";
                if (comboBox1.Text == "Admin")
                {
                    namaProcedure = "loginAdmin";
                }
                else if (comboBox1.Text == "Guru")
                {
                    namaProcedure = "loginGuru";
                }

                SqlParameter Username = new SqlParameter("@Username", SqlDbType.VarChar);
                SqlParameter Password = new SqlParameter("@Password", SqlDbType.VarChar);

                SqlParameter[] parameters = { Username, Password };

                Username.Value = txUsername.Text;
                Password.Value = fn.Crypt2(txPassword.Text); ; // nanti di encrripsy

                fn.LOGIN(namaProcedure, parameters, this);
            }
            else
            {
                if (txUsername.Text == "")
                {
                    MessageBox.Show("Username wajib diisi!", "Peringatan");
                    txUsername.Focus();
                }
                else if (txPassword.Text == "")
                {
                    MessageBox.Show("Password wajib diisi!", "Peringatan");
                    txPassword.Focus();
                }
                else if (comboBox1.Text == "")
                {
                    MessageBox.Show("Wajib pilih tipe login!", "Peringatan");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txPassword.UseSystemPasswordChar = true;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            kom.button_Close();
        }

        private void btMinimize_Click(object sender, EventArgs e)
        {
            kom.button_Minimize(this);
        }
    }
}
