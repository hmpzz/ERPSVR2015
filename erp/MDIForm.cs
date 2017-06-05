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
            //Console.WriteLine( Helper.SecurityHelper.EncryptDES("Server=localhost;Database=erp;user id=sa;password=tjhmpz801023;"));
            Dal.Context db = new Dal.Context();


            var SM = db.Sys_Menu.OrderBy(d => d.menu_index).Where(d => d.Menu_NO == "0"  ).ToList();
            Console.WriteLine(db.Sys_Menu.Max(d=>d.Menu_NO.Length));
            printSysMenu(SM);


            //Console.WriteLine(SM[0].father_Sys_menu.Menu_NO);

            //var aa=db.T_user.

        }

        private void printSysMenu(List<Sys_Menu> sm)
        {
            foreach (var item in sm)
            {

                Console.WriteLine("Menu_no--{0},Menu_name--{1}", item.Menu_NO.PadRight(6,' '), item.Menu_Name);
                printSysMenu(item.sub_Sys_menu.Where(d=>d.IN_User== Menu_Stop_state.启用).ToList());



            }
        }
    }
}
