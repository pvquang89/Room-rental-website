using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NHNT_G08.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
namespace NHNT_G08.Controllers
{
    [Route("[controller]")]
    public class ChangePassController : Controller
    {
        private readonly ILogger<ChangePassController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly NHNTContext _context;
        public ChangePassController(NHNTContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        [Route("Index")]
        public IActionResult Index()
        {
            var maTaiKhoan = HttpContext.Session.GetString("maTaiKhoan");
            int maTaiKhoanInt = int.Parse(maTaiKhoan);
            if (maTaiKhoan != null)
            {
                var user = _context.tblTaiKhoan.SingleOrDefault(u => u.maTaiKhoan == maTaiKhoanInt);
                //++ mã tk ++ maDmTaiKhoan
                return View("~/Views/Account/ChangePass.cshtml",user);
            }
            return View("~/Views/Account/ChangePass.cshtml");
        }

        [Route("Index")]
        [HttpPost]
        public async Task<IActionResult> Update(TaiKhoan taiKhoan, IFormFile anhDaiDien, string matKhauCu, string nhaplai_matkhau)
        {
            var maTaiKhoan = HttpContext.Session.GetString("maTaiKhoan");
            int maTaiKhoanInt = int.Parse(maTaiKhoan);

            var user = _context.tblTaiKhoan.SingleOrDefault(u => u.maTaiKhoan == maTaiKhoanInt);
            ViewBag.tenDangNhap = user.tenDangNhap;

            if (ModelState.IsValid)
            {
                if (!string.Equals(user.matKhau, matKhauCu))
                {
                    ViewBag.loi = "Mật Khẩu Cũ Sai";
                    // return View("~/Views/Account/ChangePass.cshtml",taiKhoan);
                }
                if (string.Equals(user.matKhau, taiKhoan.matKhau))
                {
                    ViewBag.loi = "Mật Khẩu Mới Phải Khác Mật Khẩu Cũ";
                    // return View("~/Views/Account/ChangePass.cshtml",taiKhoan);
                }
                if(!string.Equals(taiKhoan.matKhau, nhaplai_matkhau))
                {
                    ViewBag.loi = "Mật Khẩu Nhập Lại Giống Mật Khẩu Mới";
                    // return View("~/Views/Account/ChangePass.cshtml", taiKhoan);
                }
                user.matKhau = taiKhoan.matKhau;
                _context.tblTaiKhoan.Update(user);
                _context.SaveChanges();
                ViewBag.ThanhCong = "Thay Đổi Mật Khẩu Thành Công";
            }else
            {
                ViewBag.loi = "Vui lòng nhập đủ thông tin !";
                // return View("~/Views/Account/ChangePass.cshtml", taiKhoan);
            }

            return View("~/Views/Account/ChangePass.cshtml", taiKhoan);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Error")]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}