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
    /// 员工类
    /// </summary>
    [Table("T_users")]
    public class T_user
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //自增长列
        public int id { get; set; }

        

        /// <summary>        /// 员工编号        /// </summary>        [Key, Required] //主键
        public string rs_no { get; set; }

                                /// <summary>        /// 员工姓名        /// </summary>        [DefaultValue(""), Required] //默认值，必填项
        public string rs_name { get; set; }



        /// <summary>        /// 身份证号        /// </summary>        [DefaultValue("")] //默认值
        public string Card { get; set; }

        

        /// <summary>        /// 部门        /// </summary>        [Required] //必填项
        public virtual T_bm T_bm { get; set; }


        /// <summary>
        /// 性别
        /// </summary>
        [Required] //必填项
        public virtual T_sex sex { get; set; }


        

        /// <summary>        /// 婚否        /// </summary>        [Required] //必填项
        public virtual T_hf hf { get; set; }



        



        /// <summary>        /// 停用标记        /// </summary>        [DefaultValue(1), Required] //默认值，必填项
        public Stop_state stop { get; set; }








        /// <summary>        /// 学历(t_xl表中的ID)        /// </summary>        [Required] //必填项
        public virtual T_xl xl { get; set; }


        



        /// <summary>        /// 录入日期        /// </summary>        [Required]  //必填项
        public DateTime input_date { get; set; }


        

        /// <summary>        /// 录入人        /// </summary>        [Required] //必填项
        public string input_man { get; set; }





        /// <summary>        /// 修改时间        /// </summary>
        public DateTime? modify_date { get; set; }









        /// <summary>        /// 修改人        /// </summary>          [DefaultValue("")]//默认值
        public string modify_man { get; set; }

        


        /// <summary>        /// 其他        /// </summary>        [DefaultValue("")]  //默认值
        public string memo { get; set; }

        

        /// <summary>        /// 联系电话        /// </summary>        [DefaultValue("")] //默认值
        public string Tel { get; set; }











        /// <summary>        /// 家庭住址        /// </summary>        [DefaultValue("")] //默认值
        public string HOME_address { get; set; }









        /// <summary>        /// 家庭住址        /// </summary>        
        public int sexid { get; set; }


    }



    public class T_userMap : EntityTypeConfiguration<T_user>
    {
        public T_userMap()
        {

            //HasMany(d => d.T_users)
            //      .WithRequired()
            //      .HasForeignKey(p => p.T_bm);


            HasRequired(d => d.sex)
                .WithMany(a => a.T_users)
                .HasForeignKey(p => p.sexid);
        }
    }
}
