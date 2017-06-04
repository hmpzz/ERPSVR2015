using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Context:DbContext
    {
        public Context() : base("name=FirstCodeFirstApp")
        {

            

            //Database.SetInitializer(new Initializer());//执行这名就会执行初始化器
            //Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }
    }
}
