//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyWeb.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Types
    {
        public Types()
        {
            this.UserInfo = new HashSet<UserInfo>();
        }
    
        public int id { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    
        public virtual Types Types1 { get; set; }
        public virtual Types Types2 { get; set; }
        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}
