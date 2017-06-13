using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dal;
using Bll;
using Model;

namespace TestProject
{
    public partial class Form2 : Form
    {

        T_sex_BLL t_sex_bll = new T_sex_BLL();
        

        List<T_sex> bb;



        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            bb = t_sex_bll.GetList();
            //BindingList<T_sex> Bsex = new BindingList<T_sex>(bb);

            BindingSource BindingSource1 = new BindingSource();

            BindingSource1.DataSource = bb;



            //var SM = db.Sys_Menu.OrderBy(d => d.menu_index).Where(d => d.Menu_NO == "0").ToList();
            //Console.WriteLine(db.Sys_Menu.Max(d => d.Menu_NO.Length));
            //printSysMenu(SM);

            //this.exDataGridView1.DataSource = BindingSource1;

            this.exDataGridView1.DataSource = new Helper.BindingCollection<T_sex>(bb);
            //dataGridView1.DataSource = new BindingCollection<Person>(people);

            this.exDataGridView1.Columns.Clear();


            this.exDataGridView1.AddColumn("sex_no", "性别编号", Aligment: DataGridViewContentAlignment.MiddleLeft, IFReadOnly: false);
            this.exDataGridView1.AddColumn("sex_name", "性别", Aligment: DataGridViewContentAlignment.MiddleLeft, IFReadOnly: false);


            this.exDataGridView1.Columns.Add("aa", "aa");//这行没啥用，就是为了加一列显示一些自己需要的内容，只加到DataGridView上就好，不需要扩展类


            this.exDataGridView1.AllowUserToAddRows = true;
            this.exDataGridView1.AllowUserToDeleteRows = true;
            this.exDataGridView1.AllowUserToOrderColumns = true;
            this.exDataGridView1.RowHeadersVisible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            t_sex_bll.save();
        }
    }
}
