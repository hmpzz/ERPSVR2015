using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dal
{
    public class T_sex_DAL
    {
        Context db;
        public T_sex_DAL()
        {
             db = new Context();
        }

        public List<T_sex> GetList()
        {
            
            return db.T_sex.OrderBy(d => d.sex_name).ToList();
            
        }

        public void save()
        {
            db.SaveChanges();
        }
    }
}
