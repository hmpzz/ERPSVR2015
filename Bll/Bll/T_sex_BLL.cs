using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;


namespace Bll
{
    public class T_sex_BLL
    {
        T_sex_DAL t_sex_dal;
        public T_sex_BLL()
        {
            t_sex_dal = new T_sex_DAL();
        }

        public List<T_sex> GetList()
        {
            
            return t_sex_dal.GetList();
        }

        public void save()
        {
            t_sex_dal.save();
        }
    }
}
