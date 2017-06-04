using Dal;
using Model;
using System;
using System.Collections.Generic;
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

                var Sys_Menus = new List<Sys_Menu>
                 {

                    new Sys_Menu { menu_index = "0", Menu_NO= "0999", Father_No = "0999", Menu_Name = "虚拟最高层", Menu_ID = "", IN_User = Menu_Stop_state.停用 },
                    new Sys_Menu { menu_index = "0", Menu_NO= "0", Father_No = "0999", Menu_Name = "菜单", Menu_ID = "菜单", IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "000", Menu_NO = "000", Father_No = "0", Menu_Name = "系统", Menu_ID = "ID_系统", IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "000000", Menu_NO = "000000", Father_No = "000", Menu_Name = "公司基本信息", Menu_ID = "ID_公司基本信息", IN_User = Menu_Stop_state.停用 },
                    new Sys_Menu { menu_index = "000001", Menu_NO = "000001", Father_No = "000", Menu_Name = "月结日期设定", Menu_ID = "ID_月结日期设定", IN_User = Menu_Stop_state.停用 },
                    new Sys_Menu { menu_index = "000003", Menu_NO = "000002", Father_No = "000", Menu_Name = "系统角色权限", Menu_ID = "ID_系统角色权限", IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "000004", Menu_NO = "000003", Father_No = "000", Menu_Name = "系统用户权限", Menu_ID = "ID_系统用户权限", IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "001", Menu_NO = "002", Father_No = "0", Menu_Name = "人事", Menu_ID = "ID_人事", IN_User = Menu_Stop_state.启用},
                    new Sys_Menu { menu_index = "001000", Menu_NO = "002000", Father_No = "002", Menu_Name = "部门资料维护", Menu_ID = "ID_部门资料维护", IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "001001", Menu_NO = "002001", Father_No = "002", Menu_Name = "员工资料维护", Menu_ID = "ID_员工资料维护", IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "003", Menu_NO = "011", Father_No = "0", Menu_Name = "视图", Menu_ID = "ID_视图", IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "003000", Menu_NO = "011000", Father_No = "011", Menu_Name = "更改密码", Menu_ID = "ID_更改密码", IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "003001", Menu_NO = "011001", Father_No = "011", Menu_Name = "注销", Menu_ID = "ID_注销", IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "003002", Menu_NO = "011002", Father_No = "011", Menu_Name = "退出", Menu_ID = "ID_退出", IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "004", Menu_NO = "012", Father_No = "0", Menu_Name = "窗口", Menu_ID = "ID_窗口", IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "004000", Menu_NO = "012000", Father_No = "012", Menu_Name = "水平平铺", Menu_ID = "ID_水平平铺", IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "004001", Menu_NO = "012001", Father_No = "012", Menu_Name = "垂直平铺", Menu_ID = "ID_垂直平铺", IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index = "004002", Menu_NO = "012002", Father_No = "012", Menu_Name = "层叠", Menu_ID = "ID_层叠", IN_User = Menu_Stop_state.启用 },
                    new Sys_Menu { menu_index="004003",Menu_NO="012003",Father_No ="012",Menu_Name="排列窗口",Menu_ID="ID_排列窗口",IN_User=Menu_Stop_state.启用}

                 };

                context.Sys_Menu.AddRange(Sys_Menus);
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
