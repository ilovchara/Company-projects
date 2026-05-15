using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCVP.Net8.Model
{
    // 视图模型是暴露在外部的，所以需要给与 public 权限
    public class UserVo
    {
        // 对外暴露的 字段
        // 加上? 表示这个字段可以为空
        // 不加上，那就需要先赋值 null 即可
        public string? UserName { get; set; }


    }
}
