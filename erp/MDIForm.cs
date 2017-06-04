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
    public partial class MDIForm : Form
    {
        public MDIForm()
        {
            InitializeComponent();
        }

        private void 建立数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Bll.DataBase.CreateDataBase();
        }

        private void aaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine( Helper.SecurityHelper.EncryptDES("Server=localhost;Database=erp;user id=sa;password=tjhmpz801023;"));
        }
    }
}
