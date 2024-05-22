using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NHNT_G08.Models
{
    public class DanhGiaPhong
    {
        [Key]
        public int maDanhGia { get; set; }
        public int maPhong { get; set; }
        public int maTaiKhoan { get; set; }
        public int soSao { get; set; }
    }
}
