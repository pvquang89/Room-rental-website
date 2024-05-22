using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHNT_G08.Models
{
    public class NHNTContext:DbContext
    {
        public NHNTContext(DbContextOptions<NHNTContext> options)
            : base(options)
        {
        }

        public DbSet<NHNT_G08.Models.Phong> tblPhong { get; set; }
        public DbSet<NHNT_G08.Models.DanhGiaPhong> tblDanhGiaPhong { get; set; }
        public DbSet<NHNT_G08.Models.TaiKhoan> tblTaiKhoan { get; set; }
        public DbSet<NHNT_G08.Models.DmTaiKhoan> tblDmTaiKhoan { get; set; }
        public DbSet<NHNT_G08.Models.HinhAnh> tblHinhAnh { get; set; }

    }
}
