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
            Dal.Context db = new Dal.Context();

            var sex = db.T_sex.ToList();
            //var SM = db.Sys_Menu.OrderBy(d => d.menu_index).Where(d => d.Menu_NO == "0").ToList();
            //Console.WriteLine(db.Sys_Menu.Max(d => d.Menu_NO.Length));
            //printSysMenu(SM);

            this.exDataGridView1.DataSource = sex;
            
            this.exDataGridView1.AddColumn(sex.)
        }
    }
}
