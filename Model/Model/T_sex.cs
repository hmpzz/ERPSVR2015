using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 性别类
    /// </summary>
    public class T_sex
    {

        public T_sex()
        {
            T_users = new HashSet<T_user>();
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //自增长列
        public int id { get; set; }


        

        /// <summary>        /// 性别编号        /// </summary>        [Key, Required] //主键
        public int sex_no { get; set; }
        



        /// <summary>        /// 员工姓名        /// </summary>        [DefaultValue(""), Required] //默认值，必填项
        public string sex_name { get; set; }


        /// <summary>
        /// 对应的员工对象
        /// </summary>
        public virtual ICollection<T_user> T_users { get; set; }

    }

    public class T_sexMap : EntityTypeConfiguration<T_sex>
    {
        public T_sexMap()
        {

            HasMany(u => u.T_users)
                  .WithRequired(s => s.sex)
                  .Map(p => p.MapKey("sexid"));
        }
    }


}
