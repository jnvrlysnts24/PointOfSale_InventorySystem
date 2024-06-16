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

namespace WindowsFormsApplication1
{
    public partial class frmBrandList : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        public frmBrandList()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            LoadRecords();

            // for(int i=1; i<=10; ++i)
            //  {
            //     dataGridView1.Rows.Add(i, "1", "BRAND1 " +i);

            //  }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmBrand frm = new frmBrand(this);
            frm.btnSave.Enabled = true;
            frm.btnUpdate.Enabled = false;
            frm.ShowDialog();
        }

        public void LoadRecords()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * FROM tblBrand order by brand",cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["brand"].ToString());
            }
            dr.Close();
            cn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(colName == "Edit")
            {
                frmBrand frm = new frmBrand(this);
                frm.lblID.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                frm.txtBrand.Text = dataGridView1[2,e.RowIndex].Value.ToString();
                frm.btnSave.Enabled = false;
                frm.btnUpdate.Enabled = true;
                frm.ShowDialog();
            } else if (colName=="Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this brand?","Delete Record",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM tblBrand WHERE id LIKE '" + dataGridView1[1, e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Brand has been successfully deleted.","POS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadRecords();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
