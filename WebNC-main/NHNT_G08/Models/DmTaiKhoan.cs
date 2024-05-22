using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NHNT_G08.Models
{
    public class DmTaiKhoan
    {
        [Key]
        public int maDmTaiKhoan { get; set; }
        public string tenLoaiTK { get; set; }
    }
}
