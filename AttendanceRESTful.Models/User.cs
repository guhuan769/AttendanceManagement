using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Attendance.Model
{
    ///<summary>
    ///用户表
    ///</summary>
    [SugarTable("User")]
    public partial class User
    {
        /// <summary>
        /// Desc:用户ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int UserId { get; set; }

        /// <summary>
        /// Desc:用户名
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string UserName { get; set; }

        /// <summary>
        /// Desc:年龄
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? Age { get; set; }

    }
}
