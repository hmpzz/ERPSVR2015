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
            
        }

        public virtual DbSet<T_user> T_userSet { get; set; }
        public virtual DbSet<T_sex> T_sexSet { get; set; }
        public virtual DbSet<T_hf> T_HFSet { get; set; }
        public virtual DbSet<T_bm> t_BMSet { get; set; }
        public virtual DbSet<T_xl> T_xlSet { get; set; }




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
    }


   
}
