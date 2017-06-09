using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class DataBase
    {
        public static void CreateDataBase()
        {
            using (var context = new Context())
            {
                context.Database.CreateIfNotExists();//如果数据库不存在时则创建

                #region 增加系统菜单内的数据
                var Sys_Menus = new List<Sys_Menu>
                 {



                    new Sys_Menu { menu_index = "999",    Menu_NO= "999",     Father_No = "999",  Menu_Name = "虚拟最高层",     Menu_ID = "虚拟最高层",       IN_User = Menu_Stop_state.停用 },
                    new Sys_Menu { menu_index = "0",      Menu_NO= "0",       Father_No = "999",  Menu_Name = "菜单",           Menu_ID = "菜单",             IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "000",    Menu_NO = "000",    Father_No = "0",    Menu_Name = "系统",           Menu_ID = "ID_系统",          IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "000000", Menu_NO = "000000", Father_No = "000",  Menu_Name = "公司基本信息",   Menu_ID = "ID_公司基本信息",  IN_User = Menu_Stop_state.停用 },
                    new Sys_Menu { menu_index = "000001", Menu_NO = "000001", Father_No = "000",  Menu_Name = "月结日期设定",   Menu_ID = "ID_月结日期设定",  IN_User = Menu_Stop_state.停用 },
                    new Sys_Menu { menu_index = "000003", Menu_NO = "000002", Father_No = "000",  Menu_Name = "系统角色权限",   Menu_ID = "ID_系统角色权限",  IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "000004", Menu_NO = "000003", Father_No = "000",  Menu_Name = "系统用户权限",   Menu_ID = "ID_系统用户权限",  IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "001",    Menu_NO = "002",    Father_No = "0",    Menu_Name = "人事",           Menu_ID = "ID_人事",          IN_User = Menu_Stop_state.启用},
                    new Sys_Menu { menu_index = "001000", Menu_NO = "002000", Father_No = "002",  Menu_Name = "部门资料维护",   Menu_ID = "ID_部门资料维护",  IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "001001", Menu_NO = "002001", Father_No = "002",  Menu_Name = "员工资料维护",   Menu_ID = "ID_员工资料维护",  IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "011",    Menu_NO = "011",    Father_No = "0",    Menu_Name = "视图",           Menu_ID = "ID_视图",          IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "011000", Menu_NO = "011000", Father_No = "011",  Menu_Name = "更改密码",       Menu_ID = "ID_更改密码",      IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "011001", Menu_NO = "011001", Father_No = "011",  Menu_Name = "注销",           Menu_ID = "ID_注销",          IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "011002", Menu_NO = "011002", Father_No = "011",  Menu_Name = "退出",           Menu_ID = "ID_退出",          IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "012",    Menu_NO = "012",    Father_No = "0",    Menu_Name = "窗口",           Menu_ID = "ID_窗口",          IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "012000", Menu_NO = "012000", Father_No = "012",  Menu_Name = "水平平铺",       Menu_ID = "ID_水平平铺",      IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "012001", Menu_NO = "012001", Father_No = "012",  Menu_Name = "垂直平铺",       Menu_ID = "ID_垂直平铺",      IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "012002", Menu_NO = "012002", Father_No = "012",  Menu_Name = "层叠",           Menu_ID = "ID_层叠",          IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "012003", Menu_NO="012003",   Father_No ="012",   Menu_Name="排列窗口",         Menu_ID="ID_排列窗口",        IN_User=Menu_Stop_state.启用}

                 };

                context.Sys_Menu.AddRange(Sys_Menus);
                #endregion

                #region  增加学历表内的数据
                var T_XL = new List<T_xl>
                {
                    new T_xl { xl_no=0,xl_name="小学"},
                    new T_xl { xl_no=1,xl_name="初中"},
                    new T_xl { xl_no=2,xl_name="高中"},
                    new T_xl { xl_no=3,xl_name="中专"},
                    new T_xl { xl_no=4,xl_name="大专"},
                    new T_xl { xl_no=5,xl_name="本科"},
                    new T_xl { xl_no=6,xl_name="硕士"},
                    new T_xl { xl_no=7,xl_name="博士"}


                };
                context.T_xl.AddRange(T_XL);
                #endregion

                #region  增加性别表内的数据
                var T_SEX = new List<T_sex>
                {
                    new T_sex { sex_no=0,sex_name="男" },
                    new T_sex { sex_no=1,sex_name="女" }

                };
                context.T_sex.AddRange(T_SEX);
                #endregion

                #region  增加婚否表内的数据
                var T_HF = new List<T_hf>
                {
                    new T_hf { HF_no=0,HF_name="未婚" },
                    new T_hf { HF_no=1,HF_name="已婚" },
                    new T_hf { HF_no=2,HF_name="离异" },
                    new T_hf { HF_no=3,HF_name="丧偶" }

                };
                context.T_HF.AddRange(T_HF);
                #endregion

                //#region  增加学生数据
                //var T_STUDENT = new List<T_student>
                //{
                //    new T_student {  student_no=1, student_name="学生甲", SX=100,YW=100,YY=100 },
                //    new T_student {  student_no=2, student_name="学生乙", SX=99,YW=99,YY=99 },
                //    new T_student {  student_no=3, student_name="学生丙", SX=98,YW=98,YY=98 },
                //    new T_student {  student_no=4, student_name="学生丁", SX=97,YW=97,YY=97 }
                //};
                //context.T_student.AddRange(T_STUDENT);
                //#endregion  



                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException dbex)
                {

                    Console.WriteLine(dbex.Message);
                }


          



            }
        }
    }
}
