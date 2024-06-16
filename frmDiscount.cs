﻿using System;
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
    public partial class frmDiscount : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        //SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        frmPOS f;

        public frmDiscount(frmPOS frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            f = frm;
            this.KeyPreview = true;
        }

        private void txtPercent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double discount = Double.Parse(txtPrice.Text) * Double.Parse(txtPercent.Text);
                txtAmount.Text = discount.ToString("#,##0.00");
            } catch (Exception)
            {
                txtAmount.Text = "0.00";
                //MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Add discount? Click yes to confirm.","",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblCart set disc= @disc, disc_percent=@disc_percent where id=@id",cn);
                    cm.Parameters.AddWithValue("@disc",Double.Parse(txtAmount.Text));
                    cm.Parameters.AddWithValue("@disc_percent", Double.Parse(txtPercent.Text));
                    cm.Parameters.AddWithValue("@id",int.Parse(lblID.Text));
                    cm.ExecuteNonQuery();
                    cn.Close();
                    f.LoadCart();
                    this.Dispose();
                }
                {

                }
            } catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void frmDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
