using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using NHNT_G08.Models;

namespace NHNT_G08.Controllers
{
    public class QuanLyBaiDangController : Controller
    {
        private readonly NHNTContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public QuanLyBaiDangController(NHNTContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: bài đăng
        [Route("thi")]
        public async Task<IActionResult> Index(string timP, string timND, string timDC)
        {
            //var maTaiKhoan = _httpContextAccessor.HttpContext.Session.GetString("maDmTaiKhoan");
            //if (maTaiKhoan != null && Convert.ToInt32(maTaiKhoan) == 1) {
                var listBD = await _context.tblPhong.ToListAsync();
                foreach (var phong in listBD)
                {
                    var taiKhoan = _context.tblTaiKhoan.First(p => p.maTaiKhoan == phong.maTaiKhoan);
                    phong.tenNguoiDang = taiKhoan.hoTenNguoiDung;
                }
                if (!String.IsNullOrEmpty(timP))
                    listBD = listBD.Where(s => s.tenPhong.ToUpper().Contains(timP.ToUpper())).ToList();

                if (!String.IsNullOrEmpty(timND))
                    listBD = listBD.Where(s => s.tenNguoiDang.Contains(timND)).ToList();

                if (!String.IsNullOrEmpty(timDC))
                    listBD = listBD.Where(s => s.diaChi.ToUpper().Contains(timDC.ToUpper())).ToList();

                return View(listBD);
            //}
            //else if (maTaiKhoan == null)
            //{
            //    TempData["ThongBao"] = "Bạn Cần Đăng Nhập Để Thực Hiện Tác Vụ Này";
            //    return RedirectToAction("Index", "Login");
            //}
            //else
            //{
            //    TempData["ThongBao"] = "Bạn Không Có Quyền Thực Hiện Tác Vụ Này";
            //    return RedirectToAction("Index", "Home");
            //}
        }

        [HttpPost]
        public async Task<bool> duyetBaiDang(int id)
        {
            try
            {
                var phong = _context.tblPhong.Where(p=>p.maPhong == id).First();
                phong.trangThaiBaiDang = "Duyệt";
                _context.tblPhong.Update(phong);
                await _context.SaveChangesAsync();
                return true;
            } catch
            {
                return false;
            }
        }
 

        [HttpPost]
        public async Task<IActionResult> xoaBaiDang(int id)
        {
                //var phong = _context.tblPhong.Where(p => p.maPhong == id).First();
                var phong = await _context.tblPhong.FindAsync(id);
                _context.tblPhong.Remove(phong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }
    }
}
