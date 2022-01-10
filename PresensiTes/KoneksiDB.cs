using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PresensiTes
{
    //Class koneksi DB
    class KoneksiDB
    {
        private string alamat = "Data Source= SEKHUDIN;" +
               "Initial Catalog= dbPresensi;" +
               "Integrated Security= True";
        protected SqlConnection get_Koneksi()
        {
            var alamat = this.alamat;
            SqlConnection conn = new SqlConnection(@alamat);

            return conn;
        }
        protected bool cek_Koneksi()
        {
            try
            {
                SqlConnection conn = get_Koneksi();
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Koneksi terputus!");
                Application.Exit();
                return false;
            }
            return true;
        }
        protected void commandParameter(string namaProcedure, SqlParameter[] parameters, Form namaForm)
        {
            SqlConnection conn = get_Koneksi();
            conn.Open();
            SqlCommand cmd = new SqlCommand(namaProcedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter param in parameters)
            {
                cmd.Parameters.Add(param);
            }
            //coba jalankaan
            try
            {
                int usercount = (Int32)cmd.ExecuteScalar();
                if (usercount == 1)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil Login");
                    Home h = new Home();
                    h.Show();
                    namaForm.Hide();
                }
                else
                {
                    MessageBox.Show("Username atau password Anda salah!", "Gagal Login");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!");
            }
        }
    }
}
