using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace PresensiTes
{
    // class komponen berisi method yang berkaitan dengan komponen-komponen
    class Komponen
    {
        // button close
        public void button_Close()
        {
            DialogResult dr = MessageBox.Show("Yakin ingin keluar?", "Konfirmasi Keluar", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        //button minimize
        public void button_Minimize(Form namaForm)
        {
            namaForm.WindowState = FormWindowState.Minimized;
        }
        // set texBox readOnly
        public void textBx_ReadOnly(TextBox[] grupTextBox, bool status)
        {
            foreach (TextBox tb in grupTextBox)
            {
                if (status == true)
                {
                    tb.ReadOnly = true;
                    tb.BackColor = Color.White;
                    tb.BorderStyle = BorderStyle.None;
                }
                else
                {
                    tb.ReadOnly = false;
                    tb.BackColor = SystemColors.ControlLight;
                    tb.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }
        //Reset Text
        public void textBx_Reset(TextBox[] grupTextBox)
        {
            foreach (TextBox tb in grupTextBox)
            {
                tb.Clear();
            }
        }
    }
}
