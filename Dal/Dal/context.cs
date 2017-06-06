using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Context:DbContext
    {

        
        public Context() : base(GetConnStr())
        {
            
            //Database.SetInitializer(new Initializer());//执行这名就会执行初始化器
            //Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Sys_MenuMap());

            modelBuilder.Configurations.Add(new T_sexMap());
            
        }


        #region 生成表的部分

        public virtual DbSet<T_user> T_user { get; set; }
        public virtual DbSet<T_sex> T_sex { get; set; }
        public virtual DbSet<T_hf> T_HF { get; set; }
        public virtual DbSet<T_bm> t_BM { get; set; }
        public virtual DbSet<T_xl> T_xl { get; set; }
        public virtual DbSet<Sys_Menu> Sys_Menu { get; set; }

        #endregion


        #region 解密后得到连接字符串
        /// <summary>
        /// 得到解密后的连接字符串
        /// </summary>
        /// <returns>返回解密后的连接字符串</returns>
        private static string GetConnStr()
        {

            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //根据Key读取<connectionString>元素的Value
            string name = config.AppSettings.Settings["connectionString"].Value;

            string connstr= Helper.SecurityHelper.DecryptDES(name);

            return connstr;
            
        }
        #endregion


    }



}
