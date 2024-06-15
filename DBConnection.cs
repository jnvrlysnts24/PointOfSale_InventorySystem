using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{


    public class DBConnection
    {
        //public string path = Path.GetFullPath(Environment.CurrentDirectory);
       // public string databaseName = "POS-INVT.mdf";


        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private double dailysales;
        //private double weeklysales;
        //private double monthlysales;
        private int productline;
        private int stockonhand;
        private int critical;
        private string con;
       
        public string MyConnection()
        {
            con = @"Data Source=DESKTOP-H5VLVO8\SQLEXPRESS;Initial Catalog=POS-INVT;Integrated Security=True;";
            return con;
        }

        public double DailySales()
        {
            string sdate = DateTime.Now.ToShortDateString();
            cn = new SqlConnection();
            cn.ConnectionString = con;
            cn.Open();
            cm = new SqlCommand("Select isnull(sum(total),0) as total from tblCart where sdate between '" + sdate + "' and '" + sdate + "' and status like 'Sold' ", cn);
            dailysales = double.Parse(cm.ExecuteScalar().ToString());
            cn.Close();
            return dailysales;
        }

        //public double WeeklySales()
        //{
        //    string sdate = DateTime.Now.ToShortDateString();
        //    cn = new SqlConnection();
        //    cn.ConnectionString = con;
        //    cn.Open();
        //    cm = new SqlCommand("Select isnull(sum(total),0) as total from tblCart where week(sdate) = week(now()) and status like 'Sold' ", cn);
        //    weeklysales = double.Parse(cm.ExecuteScalar().ToString());
        //    cn.Close();
        //    return weeklysales;
        //}

        //public double MonthlySales()
        //{
        //    string sdate = DateTime.Now.ToShortDateString();
        //    cn = new SqlConnection();
        //    cn.ConnectionString = con;
        //    cn.Open();
        //    cm = new SqlCommand("Select isnull(sum(total),0) as total from tblCart where month(sdate) = month(now()) and status like 'Sold' ", cn);
        //    monthlysales = double.Parse(cm.ExecuteScalar().ToString());
        //    cn.Close();
        //    return monthlysales;
        //}


        public double ProductLine()
        {
            cn = new SqlConnection();
            cn.ConnectionString = con;
            cn.Open();
            cm = new SqlCommand("Select count(*) from tblProduct", cn);
            productline = int.Parse(cm.ExecuteScalar().ToString());
            cn.Close();
            return productline;
        }

        public double StockOnHand()
        {
            cn = new SqlConnection();
            cn.ConnectionString = con;
            cn.Open();
            cm = new SqlCommand("Select isnull(sum(qty),0) as qty from tblProduct", cn);
            stockonhand = int.Parse(cm.ExecuteScalar().ToString());
            cn.Close();
            return stockonhand;
        }

        public double CriticalItems()
        {
            cn = new SqlConnection();
            cn.ConnectionString = con;
            cn.Open();
            cm = new SqlCommand("Select count(*) from vwCriticalItems", cn);
            critical = int.Parse(cm.ExecuteScalar().ToString());
            cn.Close();
            return critical;
        }


        public double GetVal()
        {
            double vat=0;
            cn.ConnectionString = MyConnection();
            cn.Open();
            cm = new SqlCommand("select * from tblVat",cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                vat = Double.Parse(dr["vat"].ToString());
            }
            dr.Close();
            cn.Close();
            return vat;

        }

        public string GetPassword(string user)
        {
            string password = "";
            cn.ConnectionString = MyConnection();
            cn.Open();
            cm = new SqlCommand("select * from tblUser where username = @username", cn);
            cm.Parameters.AddWithValue("@username", user);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                password = dr["password"].ToString();
            }

            dr.Close();
            cn.Close();
            return password;
        }
    }
}
