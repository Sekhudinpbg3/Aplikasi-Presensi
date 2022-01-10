using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace PresensiTes
{
    class operasiDB : KoneksiDB
    {
        // =============== get data Pengguna
        public string[] getDataPengguna(string[] arrayKeyData,string keyTambahan)
        {
            string keyA = arrayKeyData[0];
            string keyB = arrayKeyData[1];
            string jenisPengguna = arrayKeyData[2];

            string tambahan = keyTambahan;

            string[] dataPengguna = { "id", "nama", "kontak", "username", "password"};
            string query = "";
            if (jenisPengguna == "Admin")
            {
                query = "SELECT idAdmin, namaAdmin, kontakAdmin, usernameAdmin, passwordAdmin FROM tbAdmin WHERE usernameAdmin='" + keyA + "' AND passwordAdmin='" + keyB + "'";
            }
            else if (jenisPengguna == "Guru")
            {
                query = "SELECT idGuru, namaGuru, kontakGuru, ussernameGuru, passwordGuru FROM guru WHERE ussernameGuru='" + keyA + "' AND passwordGuru='" + keyB + "'";
            }else if(jenisPengguna == "Siswa")
            {
                query = "SELECT * FROM tbSiswa WHERE idSiswa='" + keyA + "'";
            }else if(jenisPengguna == "Jadwal")
            {
                query = "SELECT idJadwal, mapel, idGuru, kelasAjar, hari FROM jadwal WHERE hari='"+keyA+"' AND jamKe='"+keyB+"' AND idGuru='"+tambahan+"'";
            }
            SqlConnection conn = this.get_Koneksi();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                try
                {
                    while (dr.Read())
                    {
                        for (int i = 0; i < dataPengguna.Length; i++)
                        {
                            dataPengguna[i] = dr[i].ToString();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!");
                }
            }
            else
            {
                MessageBox.Show("Akun Anda tidak ditemukan", "Error");
            }
            return dataPengguna;
        }
        // Procedure INSERT UPDATE DELETE
        public void procedureIUD(string namaProcedure, SqlParameter[] parameters, string jenisProcedure)
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
                cmd.ExecuteNonQuery();
                if (jenisProcedure == "Update")
                {
                    MessageBox.Show("Berhasil perbarui data!", "Succes!");
                }
                else if (jenisProcedure == "Insert")
                {
                    MessageBox.Show("Berhasil menambahkan data!", "Succes!");
                }
                else if (jenisProcedure == "Delete")
                {
                    MessageBox.Show("Berhasil dihapus!", "Succes!");
                }

            }
            catch (Exception ex)
            {
                if (jenisProcedure == "Update")
                {
                    MessageBox.Show("Data gagal diperbarui!\n" + ex.Message, "Error!");
                }
                else if (jenisProcedure == "Insert")
                {
                    MessageBox.Show("Data gagal ditambahkan!\n" + ex.Message, "Error!");
                }
                else if (jenisProcedure == "Delete")
                {
                    MessageBox.Show("Data gagal dihapus!\n" + ex.Message, "Error!");
                }
            }
        }
        //Tampilkan database
        public void showDataGV(string query, DataGridView namaGridview)
        {
            SqlConnection conn = get_Koneksi();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                namaGridview.DataSource = dt;
                namaGridview.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        //getID guru
        public string[] getIDGuru(string jenisMenu)
        {
            string query = "";
            string[] daftarMenu = { };
            SqlConnection conn = get_Koneksi();
            DataTable ds = new DataTable();
            conn.Open();
            try
            {
                if (jenisMenu == "Guru")
                {
                    query = "SELECT idGuru FROM guru";
                }
                else if (jenisMenu == "Minuman")
                {
                    query = "SELECT namaMinuman FROM minuman WHERE ketersediaan='Yes'";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                daftarMenu = new string[ds.Rows.Count];
                for (int i = 0; i < daftarMenu.Length; i++)
                {
                    daftarMenu[i] = ds.Rows[i].ItemArray[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat menu\n" + ex.Message, "Error");
            }
            return daftarMenu;
        }
        //getString nama guru berdasar id yang diketagui
        public string getNamaGuru(string query)
        {
            string namaGuru = "";
            SqlConnection conn = get_Koneksi();
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        namaGuru= dr[0].ToString();
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return namaGuru;
        }
        public List<string[]> getListFromTable(string jenisMenu,string param)
        {
            string query = "";
            List<string[]> ListMHS = new List<string[]>();
            SqlConnection conn = get_Koneksi();
            DataTable dt = new DataTable();
            conn.Open();
            try
            {
                if (jenisMenu == "Siswa")
                {
                    query = "SELECT idSiswa, namaSiswa FROM tbSiswa WHERE kelasSiswa='"+param+"'";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach(DataRow dro in dt.Rows)
                {
                    string id = dro.ItemArray[0].ToString();
                    string nama = dro.ItemArray[1].ToString();
                    string[] siswa = { id, nama };
                    ListMHS.Add(siswa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat menu\n" + ex.Message, "Error");
            }
            return ListMHS;
        }
        //IUD data Tunggal
        public bool iudDataTunggal(string query, string jenisOperasiDB)
        {
            SqlConnection conn = get_Koneksi();
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil di" + jenisOperasiDB, "Succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal " + jenisOperasiDB + "!\n" + ex.Message, "Error");
                return false;
            }
            return true;
        }
        //Inset data List
        public bool insertDataList(List<string[]> kehadiranIndividu)
        {
            SqlConnection conn = this.get_Koneksi();
            conn.Open();
            try
            {
                //untuk detailMinuman
                foreach (string[] ind in kehadiranIndividu)
                {
                    string idPresensi = ind[0];
                    string idSiswa = ind[1];
                    string namaSiswa = ind[2];
                    string statusKehadiran = ind[3];
                    string query = "INSERT INTO detpresensi(idPresensi, idSiswa, namaSiswa, statusPresensi)" +
                        "VALUES('" + idPresensi + "','" + idSiswa + "','" + namaSiswa + "','" + statusKehadiran + "')";
                    SqlCommand com = new SqlCommand(query, conn);
                    com.CommandType = CommandType.Text;
                    com.ExecuteNonQuery();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        //GetLaporan PDF
        public void reportPDF(ReportViewer namaReportV,string key)
        {
            SqlConnection conn = get_Koneksi();
            conn.Open();
            string query = "SELECT * FROM presensi WHERE idPresensi='"+key+"'";
            string querydetail = "SELECT * FROM detpresensi WHERE idPresensi='" + key + "'";
            //satu
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // dua
            SqlCommand com = new SqlCommand(querydetail, conn);
            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataTable dtab = new DataTable();
            dap.Fill(dtab);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportDataSource rdsa = new ReportDataSource("DataSet2", dtab);
            namaReportV.LocalReport.ReportPath = @"E:\KULIAH\SEMESTER 5\FRAMEWORK-IFB\praktikum\PresensiTes\PresensiTes\Report1.rdlc";
            namaReportV.LocalReport.DataSources.Clear();
            namaReportV.LocalReport.DataSources.Add(rds);
            namaReportV.LocalReport.DataSources.Add(rdsa);
            namaReportV.RefreshReport();
        }

    }
}
