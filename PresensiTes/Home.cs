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
using System.Data;
using Microsoft.VisualBasic;

namespace PresensiTes
{
    public partial class Home : Form
    {
        //instance komponen
        Komponen kom = new Komponen();
        operasiDB odb = new operasiDB();
        Functions fn = new Functions();
        //dataPengguna
        string[] keyPengguna = { Login.setValueUsername, Login.setValuePassword, Login.setJenisLogin };
        string[] dataPengguna = { }; //berisis id-- nama -- kontak --username --password
        string[] kategoriTbSiswa = { "All", "1", "2", "3" };
        string[] adminJenisTabel = { "Siswa", "Guru", "Jadwal" };
        //
        string[] daftarKelas = { "1", "2", "3" };
        string[] jenisKelamin = { "LK", "PR" };
        // 
        string[] days = { "Senin", "Selasa", "Rabu", "Kamis", "Jum'at" };
        string[] jamKe = { "ke-1", "ke-2" };
        string[] mapel = { "MTK", "IPA", "IPS", "KIMIA", "BAHASA" };
        string[] daftarIdGuru = { };


        public Home()
        {
            InitializeComponent();
        }
        //Method ketika button di klik====================
        private void navigasiCLICKED(Button BT_diCLICK, Panel barButton, Panel WRAPPER)
        {
            Button[] DAFTAR_BT_NAVIGASI =
            {
                BT_HOME,BT_ABSENSI,BT_MENUADMIN,BT_LAPORAN
            };
            Panel[] BAR_BUTTON =
            {
                bar_Home, bar_Absensi, bar_MenuAdmin, bar_Laporan
            };
            Panel[] WRAPPER_MENU =
            {
                PN_HOME, PN_ABSENSI, PN_MENUADMIN, PN_LAPORAN
            };
            //setButton
            foreach (Button BT in DAFTAR_BT_NAVIGASI)
            {
                BT.BackColor = SystemColors.HotTrack;
                BT.ForeColor = Color.Black;
            }
            //set barPanel
            foreach (Panel panel in BAR_BUTTON)
            {
                panel.BackColor = SystemColors.HotTrack;
            }
            //visible WRAPPER PANEL
            foreach(Panel pan in WRAPPER_MENU)
            {
                pan.Visible = false;
            }
            BT_diCLICK.ForeColor = Color.White;
            barButton.BackColor = Color.White;
            WRAPPER.Visible = true;
        }
        // button close dan minimize
        private void btClose_Click(object sender, EventArgs e)
        {
            kom.button_Close();
        }

        private void btMinimize_Click(object sender, EventArgs e)
        {
            kom.button_Minimize(this);
        }
        // ======================================================== HOME LOAD ==========================================
        private void Home_Load(object sender, EventArgs e)
        {
            navigasiCLICKED(BT_HOME, bar_Home, PN_HOME);
            dataPengguna = odb.getDataPengguna(keyPengguna, "null");

            //set textBox
            textBox1.Text = dataPengguna[0];
            txUsername.Text = dataPengguna[1];
            textBox2.Text = dataPengguna[2];
            textBox3.Text = dataPengguna[3];
            textBox4.Text = fn.Decrypt2(dataPengguna[4]);
            label24.Text = keyPengguna[2];
            //add combo box
            comboBox2.Items.AddRange(kategoriTbSiswa);
            comboBox3.Items.AddRange(adminJenisTabel);
            this.reportViewer1.RefreshReport();
            //
            button1.Visible = false;
            buttonLogin.Visible = true;

            if (keyPengguna[2] == "Admin")
            {
                button1.Visible = false;
                buttonLogin.Visible = false;
            }
        }
        //========================================================== HOME =============================================
        private void BT_HOME_Click(object sender, EventArgs e)
        {
            navigasiCLICKED(BT_HOME, bar_Home, PN_HOME);
        }
        //========================================================== ABSENSI =============================================
        private void BT_ABSENSI_Click(object sender, EventArgs e)
        {
            TextBox[] grupTB_Absen = { textBox14, textBox16, textBox17, textBox15 };
            if (keyPengguna[2] == "Guru")
            {
                navigasiCLICKED(BT_ABSENSI, bar_Absensi, PN_ABSENSI);
                //idGuru
                textBox10.Text = dataPengguna[0];
                kom.textBx_Reset(grupTB_Absen);
                //comboBox
                comboBox9.Items.Clear();
                comboBox9.Items.AddRange(days);
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(jamKe);
                //panel presensi
                panel8.Visible = false;
            }
            else
            {
                MessageBox.Show("Menu tidak tersedia untuk Admin", "Peringatan");
            }
            
        }
        //========================================================== MENU ADMIN =============================================
        private void BT_MENUADMIN_Click(object sender, EventArgs e)
        {
            if(keyPengguna[2] == "Admin")
            {
                navigasiCLICKED(BT_MENUADMIN, bar_MenuAdmin, PN_MENUADMIN);
                daftarIdGuru = odb.getIDGuru("Guru");
            }
            else
            {
                MessageBox.Show("Menu tidak tersedia, Anda bukanlah admin", "Peringatan");
            }  
        }
        //========================================================== LAPORAN =============================================
        private void BT_LAPORAN_Click(object sender, EventArgs e)
        {
            navigasiCLICKED(BT_LAPORAN, bar_Laporan, PN_LAPORAN);
            odb.showDataGV("SELECT * FROM presensi", dataGridView3);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            TextBox[] grupTB =
            {
                txUsername, textBox2, textBox3, textBox4
            };
            kom.textBx_ReadOnly(grupTB, false);
            buttonLogin.Visible = false;
            button1.Visible = true;
            textBox4.UseSystemPasswordChar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] grupTB =
            {
                textBox1, txUsername, textBox2, textBox3, textBox4
            };
            string id = textBox1.Text;
            string nama = txUsername.Text;
            string telp = textBox2.Text;
            string uname = textBox3.Text;
            string pass = textBox4.Text;
            if (textBox1.Text !="" && txUsername.Text !="" && textBox2.Text != "" && textBox3.Text !="" && textBox4.Text != "" && Information.IsNumeric(textBox2.Text))
            {
                string query = "UPDATE guru set namaGuru='" + nama + "', alamat='" + telp + "', ussernameGuru='" + uname + "' , passwordGuru='" + pass + "' WHERE idGuru='" + id + "'";
                if (odb.iudDataTunggal(query, "Update") == true)
                {
                    kom.textBx_ReadOnly(grupTB, true);
                    buttonLogin.Visible = true;
                    button1.Visible = false;
                    textBox4.UseSystemPasswordChar = true;
                }
                else
                {
                    MessageBox.Show("Gagal Meng-Update Guru", "Failed");
                }
            }
            else
            {
                MessageBox.Show("Harap isi dengan format yang benar");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox[] grupTB =
            {
                textBox24, textBox26, textBox27, textBox28, textBox29, textBox23
            };
            textBox24.ReadOnly = true;
            string qTampil = "";
            if (comboBox3.Text == "Siswa")
            {
                kom.textBx_Reset(grupTB);
                //
                label28.Text = "ID Siswa :";
                label29.Text = "Nama :";
                label30.Text = "Kelas :";
                label31.Text = "Jenis Kelamin :";
                label32.Text = "Alamat :";
                //set Visibel
                label33.Visible = false;
                textBox23.Visible = false;
                //
                textBox26.ReadOnly = false;
                comboBox4.Visible = false;
                textBox27.ReadOnly = true;
                comboBox5.Visible = true;
                textBox28.ReadOnly = true;
                comboBox6.Visible = true;
                textBox29.ReadOnly = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                // Auto ID
                textBox24.Text = fn.getAutoID("Siswa");
                //ComboBox
                comboBox5.Items.Clear();
                comboBox5.Items.AddRange(daftarKelas);//kelas
                comboBox6.Items.Clear();
                comboBox6.Items.AddRange(jenisKelamin);
                qTampil = "SELECT * FROM tbSiswa";
            }
            else if(comboBox3.Text == "Guru")
            {
                kom.textBx_Reset(grupTB);
                //
                //set Visibel
                label33.Visible = true;
                textBox23.Visible = true;
                // set Label
                label28.Text = "ID Guru :";
                label29.Text = "Nama Guru :";
                label30.Text = "Alamat :";
                label31.Text = "Kontak :";
                label32.Text = "Username :";
                label33.Text = "Password :";
                //
                comboBox4.Visible = false;
                textBox26.ReadOnly = false;
                textBox27.ReadOnly = false;
                comboBox5.Visible = false;
                textBox28.ReadOnly = false;
                comboBox6.Visible = false;
                textBox29.ReadOnly = false;
                comboBox7.Visible = false;
                textBox23.ReadOnly = false;
                comboBox8.Visible = false;
                // Auto ID
                textBox24.Text = fn.getAutoID("Guru");
                qTampil = "SELECT * FROM guru";
            }
            else if(comboBox3.Text == "Jadwal")
            {
                kom.textBx_Reset(grupTB);
                //
                //set Visibel
                label33.Visible = true;
                textBox23.Visible = true;
                // set Label
                label28.Text = "ID Jadwal :";
                label29.Text = "Hari :";
                label30.Text = "Jam Ke :";
                label31.Text = "Mapel :";
                label32.Text = "ID Guru :";
                label33.Text = "Kelas :";
                //
                textBox26.ReadOnly = true;
                comboBox4.Visible = true;
                textBox27.ReadOnly = true;
                comboBox5.Visible = true;
                textBox28.ReadOnly = true;
                comboBox6.Visible = true;
                textBox29.ReadOnly = true;
                comboBox7.Visible = true;
                textBox23.ReadOnly = true;
                comboBox8.Visible = true;
                // Auto ID
                textBox24.Text = fn.getAutoID("Jadwal");
                //ComboBox
                comboBox4.Items.Clear();
                comboBox4.Items.AddRange(days);
                comboBox5.Items.Clear();
                comboBox5.Items.AddRange(jamKe);
                comboBox6.Items.Clear();
                comboBox6.Items.AddRange(mapel);
                comboBox7.Items.Clear();
                comboBox7.Items.AddRange(daftarIdGuru);
                comboBox8.Items.Clear();
                comboBox8.Items.AddRange(daftarKelas);
                qTampil = "SELECT * FROM jadwal";
            }
            odb.showDataGV(qTampil, dataGridView2);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox26.Text = comboBox4.Text;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox27.Text = comboBox5.Text;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox28.Text = comboBox6.Text;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT namaGuru FROM guru WHERE idGuru='" + comboBox7.Text + "'";
            textBox29.Text = odb.getNamaGuru(query);
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox23.Text = comboBox8.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TextBox[] grupTxB = { textBox24, textBox26, textBox27, textBox28, textBox29, textBox23 };
            string namaProcedure = "";
            string qTampil = "";
            SqlParameter parA = new SqlParameter("@parA", SqlDbType.VarChar);
            SqlParameter parB = new SqlParameter("@parB", SqlDbType.VarChar);
            SqlParameter parC = new SqlParameter("@parC", SqlDbType.VarChar);
            SqlParameter parD = new SqlParameter("@parD", SqlDbType.VarChar);
            SqlParameter parE = new SqlParameter("@parE", SqlDbType.VarChar);

            SqlParameter[] parameters = {};
            if (textBox24.Text != "" && textBox26.Text != "" && textBox27.Text != "" && textBox28.Text != "" && textBox29.Text != "")
            {
                parA.Value = textBox24.Text;
                parB.Value = textBox26.Text;
                parC.Value = textBox27.Text;
                parD.Value = textBox28.Text;
                parE.Value = textBox29.Text;


                if (comboBox3.Text == "Siswa")
                {
                    SqlParameter[] tesParams = { parA, parB, parC, parD, parE};
                    parameters = tesParams;
                    namaProcedure = "Insert_Siswa";
                    qTampil = "SELECT * FROM tbSiswa";
                }
                else if (comboBox3.Text == "Guru" && textBox23.Text != "")
                {
                    SqlParameter parF = new SqlParameter("@parF", SqlDbType.VarChar);
                    parF.Value = fn.Crypt2(textBox23.Text);
                    SqlParameter[] tesParams = { parA, parB, parC, parD, parE, parF };
                    parameters = tesParams;
                    namaProcedure = "Insert_Guru";
                    qTampil = "SELECT * FROM guru";

                }
                else if (comboBox3.Text == "Jadwal" && textBox23.Text != "")
                {
                    SqlParameter parF = new SqlParameter("@parF", SqlDbType.VarChar);
                    parE.Value = comboBox7.Text;
                    parF.Value = textBox23.Text;
                    SqlParameter[] tesParams = { parA, parB, parC, parD, parE, parF };
                    parameters = tesParams;
                    namaProcedure = "Insert_Jadwal";
                    qTampil = "SELECT * FROM jadwal";
                }
                odb.procedureIUD(namaProcedure, parameters, "Insert");
                kom.textBx_Reset(grupTxB);
                //getNextId
                textBox24.Text = fn.getAutoID(comboBox3.Text);
                odb.showDataGV(qTampil, dataGridView2);
            }
            else
            {
                MessageBox.Show("Tidak boleh ada yang kosong!", "Peringatan");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "";
            if(comboBox2.Text == "All")
            {
                query = "SELECT idSiswa, namaSiswa FROM tbSiswa";
            }else if(comboBox2.Text == "1")
            {
                query = "SELECT idSiswa, namaSiswa FROM tbSiswa WHERE kelasSiswa='1'";
            }
            else if (comboBox2.Text == "2")
            {
                query = "SELECT idSiswa, namaSiswa FROM tbSiswa WHERE kelasSiswa='2'";
            }
            else if (comboBox2.Text == "3")
            {
                query = "SELECT idSiswa, namaSiswa FROM tbSiswa WHERE kelasSiswa='3'";
            }
            odb.showDataGV(query, dataGridView1);
        }

        private void dataGridView1_cellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = dataGridView1.CurrentRow.Index;
            string key_id = dataGridView1.Rows[indexRow].Cells[0].Value.ToString();
            string[] arr = { key_id, "coba", "Siswa" };
            string[] dataSiswa = odb.getDataPengguna(arr,"null");

            textBox5.Text = dataSiswa[0];
            textBox6.Text = dataSiswa[1];
            textBox8.Text = dataSiswa[2];
            textBox9.Text = dataSiswa[3];
            textBox7.Text = dataSiswa[4];
        }
        //List komponen dan list pesanan
        private List<string[]> listID_NamaSiswa = new List<string[]>();
        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox9.Text !="" && comboBox1.Text != "")
            {
                string[] arr = { comboBox9.Text, comboBox1.Text,"Jadwal" };
                string[] detJadwal = odb.getDataPengguna(arr, textBox10.Text);

                textBox14.Text = detJadwal[0];
                textBox16.Text = detJadwal[1];
                textBox17.Text = odb.getNamaGuru("SELECT namaGuru FROM guru WHERE idGuru='"+ detJadwal[2]+ "'");
                textBox15.Text = detJadwal[3];
                //enable panel presensi
                if(textBox17.Text != "")
                {
                    panel8.Visible = true;
                    //Generate daftar siswa
                    listID_NamaSiswa = odb.getListFromTable("Siswa", textBox15.Text);
                    textBox11.Text = listID_NamaSiswa.Count().ToString();

                    listBox1.Items.Clear();
                    foreach (string[] arry in listID_NamaSiswa)
                    {
                        listBox1.Items.Add(arry[1].ToString());
                    }
                }
                else
                {
                    textBox14.Clear();
                    textBox16.Clear();
                    textBox15.Clear();
                }
                
            }
            else
            {
                MessageBox.Show("Silahkan pilih hari dan jam ajar!", "Peringatan");
            }
            textBox30.Text = fn.getAutoID("Presensi");
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for(int i=0; i < listID_NamaSiswa.Count(); i++)
            {
                if(listID_NamaSiswa[i][1] == listBox1.SelectedItem)
                {
                    textBox12.Text = listID_NamaSiswa[i][0].ToString();
                }
            }
        }
        //listPresensi
        private List<string[]> listKehadiranKelas = new List<string[]>();
        private void button5_Click(object sender, EventArgs e)
        {
            string idPresensi = textBox30.Text;
            string idJadwal = textBox14.Text;
            string statusKehadiran = "";
            if (textBox12.Text != "" && (rb_Hadir.Checked || rb_Sakit.Checked || rbIjin.Checked || rbAlpha.Checked) && int.Parse(textBox31.Text)<int.Parse(textBox11.Text))
            {
                string idSiswa = textBox12.Text;
                string namaSiswa = listBox1.SelectedItem.ToString();
                if (rb_Hadir.Checked)
                {
                    statusKehadiran = "Hadir";
                }else if (rb_Sakit.Checked)
                {
                    statusKehadiran = "Sakit";
                }else if (rbIjin.Checked)
                {
                    statusKehadiran = "Ijin";
                }else if (rbAlpha.Checked)
                {
                    statusKehadiran = "Alpha";
                }
                string[] kehadiranIndividu = { idPresensi, idSiswa, namaSiswa, statusKehadiran };
                listKehadiranKelas.Add(kehadiranIndividu);
                //reset Text
                textBox12.Clear();
                textBox31.Text = listKehadiranKelas.Count().ToString(); // hitung panajng list -- total siswa
                // 
                int sum = int.Parse(textBox32.Text);
                string hadir = fn.getJumlahHadir(listKehadiranKelas);
                //int sumTotal = sum + int.Parse(hadir);
                textBox32.Text = hadir;// jumlah hadir
                //
                textBox33.Text = (int.Parse(textBox31.Text) - int.Parse(textBox32.Text)).ToString(); // jumlah tidah hadir (sakit/ijin/alpa)
            }
            else
            {
                MessageBox.Show("Pastikan terisi dengan benar", "Peringatan");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox11.Text == textBox31.Text)
            {
                string query = "INSERT INTO presensi(idPresensi, idJadwal, jumlahHadir, jumlahTidakHadirr) VALUES ('"+ textBox30 .Text+ "','"+ textBox14.Text+ "','"+ textBox32 .Text+ "','"+ textBox33 .Text+ "')";
                if (odb.iudDataTunggal(query, "Insert") == true)
                {
                    if (odb.insertDataList(listKehadiranKelas) == true)
                    {
                        MessageBox.Show("Presensi Berhasil direcord!", "Succes");
                        listKehadiranKelas.Clear();
                        textBox31.Clear();
                        textBox32.Clear();
                        textBox33.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Gagal record presensi", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Gagal record presensi", "Error");
                }
            }
            else
            {
                MessageBox.Show("Pastikan siswa sudah terabsen semua", "Peringatan");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(textBox34.Text != "")
            {
                odb.reportPDF(reportViewer1, textBox34.Text);
            }
            else
            {
                MessageBox.Show("Anda Belum memilih field yang akan dicetak!", "Peringatan");
            }
            
        }

        private void dataGridView3_cellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = dataGridView3.CurrentRow.Index;
            string key_id = dataGridView3.Rows[indexRow].Cells[0].Value.ToString();
            textBox34.Text = key_id;
        }
    }
}
