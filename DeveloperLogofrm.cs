using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class DeveloperLogofrm : Form
    {
        public DeveloperLogofrm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
        if (progressBar1.Value == 30)
          {
                SplashScreen frm = new SplashScreen();
                this.Hide();
                frm.Show();
               

                timer1.Stop();

        
            }
           
        }

        private void DeveloperLogofrm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }
    }
}
