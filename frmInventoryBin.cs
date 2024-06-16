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
    public partial class frmInventoryBin : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        //string username;
        Form1 frm = new Form1();
        public frmInventoryBin()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            LoadBin();
        }

        public void LoadBin()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * FROM vwBin WHERE action LIKE 'REMOVE FROM INVENTORY'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), DateTime.Parse(dr[6].ToString()).ToString("yyyy-MM-dd"), dr[7].ToString());
            }
            dr.Close();
            cn.Close();
        }

        public void SaveRestoredBin(string user)
        {

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                if (MessageBox.Show("Are you sure you want to restore this item to stock inventory?", "Restore Stocks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    SqlStatement("Update tblProduct set qty = (qty + " + int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) + ") where pcode like '" + dataGridView1.Rows[e.RowIndex].Cells[2].ToString() + "'");

               
                }
                SqlStatement("update tblAdjustment set action='RESTORED TO INVENTORY' where referenceno like '" + dataGridView1.Rows[e.RowIndex].Cells[1].ToString() + "'");
                MessageBox.Show("Stock successfully restored to inventory!", "Successful Restoration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBin();
                dr.Close();
                cn.Close();


                //string act = "RESTORED TO INVENTORY";


                //frm.lblUser.Text = username;

                //cn.Open();
                //cm = new SqlCommand("insert into tblBin (referenceno, pcode, pdesc, qty, action, date_removed, removed_by, date_restored, restored_by) values (@referenceno, @pcode, @pdesc, @qty, @action, @date_removed, @removed_by, @date_restored, @restoredby)", cn);
                //cm.Parameters.AddWithValue("@referenceno", dataGridView1.Rows[0].ToString());
                //cm.Parameters.AddWithValue("@pcode", dataGridView1.Rows[1].ToString());
                //cm.Parameters.AddWithValue("@pdesc", dataGridView1.Rows[2].ToString());
                //cm.Parameters.AddWithValue("@qty", int.Parse(dataGridView1.Rows[3].ToString()));
                //cm.Parameters.AddWithValue("@action", act);
                //cm.Parameters.AddWithValue("@date_removed", dataGridView1.Rows[6].ToString());
                //cm.Parameters.AddWithValue("@removed_by", dataGridView1.Rows[7].ToString());
                //cm.Parameters.AddWithValue("@date_restored", DateTime.Now);
                //cm.Parameters.AddWithValue("@restored_by", username);
                //cm.ExecuteNonQuery();

                //cn.Close();



            }
            else
            {
                return;
               
            }
            
           
        }

        public void SqlStatement(string _sql)
        {
            cn.Open();
            cm = new SqlCommand(_sql, cn);
            cm.ExecuteNonQuery();
            cn.Close();
        }

       
    }
}
