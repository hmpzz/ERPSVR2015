//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_user
    {
        public int id { get; set; }
        public string RS_no { get; set; }
        public string rs_name { get; set; }
        public int T_sexId { get; set; }
        public int T_HFId { get; set; }
    
        public virtual T_sex T_sex { get; set; }
        public virtual T_HF T_HF { get; set; }
    }
}
