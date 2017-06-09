using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erp
{
    public partial class Form1 : Form
    {
        Dal.Context db = new Dal.Context();


        List<T_sex> bb;
        List<Tsexa> cc;


        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 测试扩展类
        /// </summary>
        partial class Tsexa : T_sex
        {
 
            public string aa { get; set; }

        }


        


    


        private void button1_Click(object sender, EventArgs e)
        {
            
            bb =  db.T_sex.OrderBy(d=>d.sex_name).ToList();
            //BindingList<T_sex> Bsex = new BindingList<T_sex>(bb);

            BindingSource BindingSource1 = new BindingSource();

            BindingSource1.DataSource = bb;


            var sex = db.T_sex.ToList();
            //var SM = db.Sys_Menu.OrderBy(d => d.menu_index).Where(d => d.Menu_NO == "0").ToList();
            //Console.WriteLine(db.Sys_Menu.Max(d => d.Menu_NO.Length));
            //printSysMenu(SM);

            //this.exDataGridView1.DataSource = BindingSource1;

            this.exDataGridView1.DataSource = new Class1.BindingCollection<T_sex>(bb);
            //dataGridView1.DataSource = new BindingCollection<Person>(people);

            this.exDataGridView1.Columns.Clear();


                this.exDataGridView1.AddColumn("sex_no", "性别编号", Aligment: DataGridViewContentAlignment.MiddleLeft,IFReadOnly:false);
                this.exDataGridView1.AddColumn("sex_name", "性别", Aligment: DataGridViewContentAlignment.MiddleLeft, IFReadOnly: false);
            

            this.exDataGridView1.Columns.Add("aa", "aa");//这行没啥用，就是为了加一列显示一些自己需要的内容，只加到DataGridView上就好，不需要扩展类


            this.exDataGridView1.AllowUserToAddRows = true;
            this.exDataGridView1.AllowUserToDeleteRows = true;
            this.exDataGridView1.AllowUserToOrderColumns = true;
            this.exDataGridView1.RowHeadersVisible = true;


            


            //this.exDataGridView1.AddColumn()
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //反射得到属性
            var sex = new Model.T_sex();

            
            PropertyInfo[] ps = sex.GetType().GetProperties();
            
            foreach (PropertyInfo info in ps)
            {
                Console.WriteLine(info.Name);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //打印这个类里的东西
            var aa = (IList<Model.T_sex>)this.exDataGridView1.DataSource;

            
            foreach (var item in aa)
            {
                
                Console.WriteLine("id--{0},sex_no--{1},sex_name--{2}", item.id,item.sex_no, item.sex_name);


            }   
            
        }


        

        private void button4_Click(object sender, EventArgs e)
        {
            ////IList list = (IList)this.exDataGridView1.DataSource; //转换数据源  
            ////list.RemoveAt(exDataGridView1.CurrentRow.Index);//移除
            ////exDataGridView1.DataSource = null; //为空  
            ////exDataGridView1.DataSource = list;//显示数据

            

            //using (Dal.Context db = new Dal.Context())
            //{
                

            //        IList<T_sex> list = (IList<T_sex>)this.exDataGridView1.DataSource;

                

            //      //  db.Entry(list[2]).State = System.Data.Entity.EntityState.Detached;//指定状态为更新  
            //                                                                      //db.SaveChanges();//保存  

            //    exDataGridView1.DataSource = null; //为空  
            //    exDataGridView1.DataSource = list;//显示数据

            //}


        }

        private void button5_Click(object sender, EventArgs e)
        {
            // db.Entry(sex).State = System.Data.Entity.EntityState.
            T_sex sex = new T_sex();
            sex.sex_no = 2;
            sex.sex_name = "男"  ;

             //((IList<T_sex>)this.exDataGridView1.DataSource).Insert(this.exDataGridView1.SelectedRows[0].Index,sex);

            ((IList<T_sex>)this.exDataGridView1.DataSource).Add(sex);

            db.Entry(sex).State = System.Data.Entity.EntityState.Added;
            //db.Entry(((T_sex)this.exDataGridView1.Rows[this.exDataGridView1.NewRowIndex].DataBoundItem)).State = System.Data.Entity.EntityState.Added;


           //this.exDataGridView1.Refresh();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            //db.Entry(((T_sex)this.exDataGridView1.Rows[0].DataBoundItem)).State = System.Data.Entity.EntityState.Deleted;
            
            db.T_sex.Remove((T_sex)this.exDataGridView1.Rows[0].DataBoundItem);

            this.exDataGridView1.Rows.RemoveAt(0);//用命令删除必须删除这行，只删除list这行还是有




        }

        private void button8_Click(object sender, EventArgs e)
        {
            ((T_sex)this.exDataGridView1.SelectedRows[0].DataBoundItem).sex_name = "其他";

           

            //db.Entry(((T_sex)this.exDataGridView1.SelectedRows[0].DataBoundItem)).State = System.Data.Entity.EntityState.Modified;

            //this.exDataGridView1.SelectedRows[0].Cells["sex_name"].Value = "其他";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            var aa = from T in db.T_sex
                     join T1 in (from a in db.T_sex
                                 group a by a.sex_name into g
                                 select new
                                 {
                                     sex_name = g.Key,
                                     sexcount = g.Count()
                                 }) on T.sex_name equals T1.sex_name
                     select new { T.sex_no, T.sex_name, T1.sexcount };






            var bb = db.T_sex.Join(db.T_sex
                                .GroupBy(a => a.sex_name)
                                .Select(g => new
                                {
                                    sex_name = g.Key,
                                    sexcount = g.Count()
                                }),
                                  T => T.sex_name,
                                  T1 => T1.sex_name,
                                  (T, T1) =>
                                     new
                                     {
                                         Sex_no = T.sex_no,
                                         Sex_name = T.sex_name,
                                         sexcount = T1.sexcount
                                     }
                               ).ToList();


            foreach (var item in aa)
            {

                Console.WriteLine("sex_no--{0},sex_name--{1},sexcount--{2}", item.sex_no,item.sex_name,item.sexcount);


            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
