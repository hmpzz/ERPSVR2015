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
    /// 婚否类
    /// </summary>
    public class T_hf
    {


        public T_hf()
        {
            T_users = new HashSet<T_user>();
        }



        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //自增长列
        public int id { get; set; }







        /// <summary>        ///婚否编号        /// </summary>        [Key, Required] //主键
        public int HF_no { get; set; }


        

        /// <summary>        /// 婚否        /// </summary>        [DefaultValue(""), Required] //默认值，必填项
        public string HF_name { get; set; }


        /// <summary>
        /// 对应的员工对象
        /// </summary>
        public virtual ICollection<T_user> T_users { get; set; }

    }


    public class T_hfMap : EntityTypeConfiguration<T_hf>
    {
        public T_hfMap()
        {

            HasMany(d => d.T_users)
                  .WithRequired()
                  .HasForeignKey(p => p.hf);

                        
        }
    }
}
