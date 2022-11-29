using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Npgsql;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsAppResponsi
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=5432;Username=postgres;Password=informatika;Database=responsibagus";
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string sql = null;
        private DataGridViewRow r;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from st_insert(:_namaKaryawan,:_Departemen)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_namaKaryawan", txt.Text);
                
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data Karyawan Berhasil Diinputkan", "Well Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    btnLoad.PerformClick();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Insert FAIL!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from st_update(:_namaKaryawan,:_Departemen)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_namaKaryawan", txt.Text);

                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data Karyawan Berhasil Diupdate", "Well Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    btnLoad.PerformClick();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Update FAIL!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from st_delete(:_id)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_namaKaryawan", txt.Text);

                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data Karyawan Berhasil dihapus", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    btnLoad.PerformClick();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Delete!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn =new NpgsqlConnection(connstring); 
        }
    }
}
