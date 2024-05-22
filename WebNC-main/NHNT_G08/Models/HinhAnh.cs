using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NHNT_G08.Models
{
    public class HinhAnh
    {
        [Key]
        public int maAnh { get; set; }
        public string duongDan { get; set; }
        public int maPhong { get; set; }
    }
}
