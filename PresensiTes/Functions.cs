using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace PresensiTes
{
    class Functions : KoneksiDB
    {
        public void LOGIN(string namaProcedure, SqlParameter[] parameters, Form namaForm)
        {
            this.commandParameter(namaProcedure, parameters, namaForm);
        }
        //gunakan encrypsi dan decripsi ke-2
        private byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        public string Crypt2(string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        public string Decrypt2(string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }
        //================= get Auto ID
        public string getAutoID(string jenisId)
        { 
            string next_ID = "";
            string query = "";
            if (jenisId == "Siswa")
            {
                query = "SELECT MAX (right(idSiswa,3)) FROM tbSiswa";
            }
            else if (jenisId == "Guru")
            {
                query = "SELECT MAX (right(idGuru,3)) FROM guru";
            }
            else if (jenisId == "Admin")
            {
                query = "SELECT MAX (right(idAdmin,3)) FROM tbAdmin";
            }
            else if (jenisId == "Jadwal")
            {
                query = "SELECT MAX (right(idJadwal,3)) FROM jadwal";
            }
            else if (jenisId == "Presensi")
            {
                query = "SELECT MAX (right(idPresensi,3)) FROM presensi";
            }
            else
            {
                query = "";
                MessageBox.Show("Anda salah memasukan tipe", "Error");
            }
            SqlConnection con = get_Koneksi();
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                dr.Read();
                string fullstring = dr[0].ToString();
                if (jenisId == "Siswa")
                {
                    if (fullstring != "")
                    {
                        next_ID = "WA" + "00" + (int.Parse(fullstring) + 1).ToString();
                    }
                    else
                    {
                        next_ID = "WA" + "001";
                    }
                }
                else if (jenisId == "Guru")
                {
                    if (fullstring != "")
                    {
                        next_ID = "GR" + "00" + (int.Parse(fullstring) + 1).ToString();
                    }
                    else
                    {
                        next_ID = "GR" + "00" + "1";
                    }
                }
                else if (jenisId == "Admin")
                {
                    if (fullstring != "")
                    {
                        next_ID = "AD" + "00" + (int.Parse(fullstring) + 1).ToString();
                    }
                    else
                    {
                        next_ID = "AD" + "00" + "1";
                    }
                }
                else if (jenisId == "Jadwal")
                {
                    if (fullstring != "")
                    {
                        next_ID = "JD"+ "00" + (int.Parse(fullstring) + 1).ToString();
                    }
                    else
                    {
                        next_ID = "JD"+ "001";
                    }
                }
                else if (jenisId == "Presensi")
                {
                    if (fullstring != "")
                    {
                        next_ID = "PS"+ "00" + (int.Parse(fullstring) + 1).ToString();
                    }
                    else
                    {
                        next_ID = "PS" + "001";
                    }
                }
                else
                {
                    MessageBox.Show("Gagal Generate autoNext-ID!", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gagal memuat Auto-ID");
            }
            dr.Close();
            return next_ID;
        }
        public string getJumlahHadir(List<string[]> namaList)
        {
            string jumlah = "";
            for(int i=0; i < namaList.Count(); i++)
            {
                if(namaList[i][3].ToString() == "Hadir")
                {
                    List<string> listHadir = new List<string>();
                    listHadir.Add(namaList[i][3]);
                    jumlah = listHadir.Count().ToString();
                }
            }

            return jumlah;
        }
    }
}
