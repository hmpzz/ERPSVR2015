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
    /// 主菜单类
    /// </summary>
    [Table("Sys_menu")]
    public class Sys_Menu
    {


        /// <summary>
        /// 此实例对应的子类
        /// </summary>
        public Sys_Menu()
        {
            sub_Sys_menu = new HashSet<Sys_Menu>();
        }

        

        /// <summary>        /// 菜单项编号        /// </summary>        [Key, Required] //主键
        public string Menu_NO { get; set; }


        /// <summary>        /// 菜单项名称        /// </summary>        [ Required] //默认值，必填项
        public string Menu_Name { get; set; }



        /// <summary>        /// 对应的窗口ID        /// </summary>        [DefaultValue(""), Required] //默认值，必填项
        public string Menu_ID { get; set; }


        ///// <summary>
        ///// 父菜单编号
        ///// </summary>
        [Required, MaxLength(128)] //默认值，必填项
        public string Father_No { get; set; }


        


        /// <summary>        /// 菜单索引        /// </summary>        [ Required] //默认值，必填项
        public string menu_index { get; set; }


        /// <summary>
        /// 停用标记
        /// </summary>
        [Required]
        public Menu_Stop_state IN_User { get; set; }

        /// <summary>
        /// 对应的子项菜单 
        /// </summary>
        public virtual ICollection<Sys_Menu> sub_Sys_menu { get; set; }





    }



    public class Sys_MenuMap : EntityTypeConfiguration<Sys_Menu>
    {
        public Sys_MenuMap()
        {

            HasMany(s => s.sub_Sys_menu)
                  .WithRequired()
                  .HasForeignKey(p => p.Father_No);





            //this.HasMany(d => d.Sys_menu).WithRequired(p=> (Model.Sys_Menu)p.Sys_menu).Map(l => l.MapKey("Father_No1"));

        }
    }
}
