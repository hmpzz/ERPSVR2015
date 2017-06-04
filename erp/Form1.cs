using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.T_user user = new Model.T_user();

            this.textBox1.Text=Helper.SecurityHelper.EncryptDES("Server=172.16.1.79;Database=hmptest;user id=sa;password=MP@ssw0rd;");
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = Helper.SecurityHelper.DecryptDES(this.textBox1.Text.Trim());
        }

        private void button3_Click(object sender, EventArgs e)
        {

            using (var context = new Dal.Context())
            {
                var user = context.T_userSet.ToList<T_user>();

                foreach (var item in user)
                {
                    Console.WriteLine(item.rs_name);
                }

            }






        }
    }
}
