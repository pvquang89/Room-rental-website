using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NHNT_G08.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace NHNT_G08.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IWebHostEnvironment _environment;
        private readonly NHNTContext _context;
        public AccountController(NHNTContext context, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }


        [Route("Index")]
        public IActionResult Index()
        {
            var maTaiKhoan = HttpContext.Session.GetString("maTaiKhoan");
            if (maTaiKhoan != null)
            {
                int maTaiKhoanInt = int.Parse(maTaiKhoan);
                var user = _context.tblTaiKhoan.SingleOrDefault(u => u.maTaiKhoan == maTaiKhoanInt);
                //++ mã tk ++ maDmTaiKhoan
                ViewBag.tenDangNhap = user.tenDangNhap;
                ViewBag.hoTenNguoiDung = user.hoTenNguoiDung;
                ViewBag.soDienThoai = user.soDienThoai;

                ViewBag.anhDaiDien = Url.Content("~/img/anhdaidien/" + user.anhDaiDien);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return View("~/Views/Account/Account.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> Update(TaiKhoan taiKhoan, IFormFile anhDaiDien)
        {
            // if (ModelState.IsValid)
            // {
            var maTaiKhoan = HttpContext.Session.GetString("maTaiKhoan");
            if (!string.IsNullOrEmpty(maTaiKhoan))
            {
                int maTaiKhoanInt = int.Parse(maTaiKhoan);

                var user = _context.tblTaiKhoan.SingleOrDefault(u => u.maTaiKhoan == maTaiKhoanInt);

                if (anhDaiDien != null && anhDaiDien.Length > 0)
                {
                    // Lưu tệp tin vào thư mục trong dự án
                    string oldfile = "wwwroot/img/anhdaidien" + user.anhDaiDien;
                    if (System.IO.File.Exists(oldfile))
                    {
                        System.IO.File.Delete(oldfile);
                    }
                    string uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/anhdaidien");
                    string uniqueFileName = user.tenDangNhap + ".jpg";
                    string filePath = Path.Combine(uploadsPath, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await anhDaiDien.CopyToAsync(fileStream);
                    }
                    // Lưu tên tệp tin vào đối tượng taiKhoan
                    user.anhDaiDien = uniqueFileName;
                    _httpContextAccessor.HttpContext.Session.SetString("anhDaiDien", Url.Content("~/img/anhdaidien/" + user.anhDaiDien));
                }

                user.hoTenNguoiDung = taiKhoan.hoTenNguoiDung;
                user.soDienThoai = taiKhoan.soDienThoai;

                // Lưu thông tin taiKhoan vào cơ sở dữ liệu
                _context.tblTaiKhoan.Update(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Account", taiKhoan);
        }


        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete()
        {
            var maTaiKhoan = HttpContext.Session.GetString("maTaiKhoan");
            if (!string.IsNullOrEmpty(maTaiKhoan))
            {
                if (int.TryParse(maTaiKhoan, out int maTaiKhoanInt))
                {
                    var user = _context.tblTaiKhoan.SingleOrDefault(u => u.maTaiKhoan == maTaiKhoanInt);
                    if (user != null)
                    {
                        string filePath = Path.Combine(_environment.WebRootPath, "img", "anhdaidien", user.anhDaiDien);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                            // Cập nhật thông tin tài khoản vào cơ sở dữ liệu
                            user.anhDaiDien = null;
                            _context.tblTaiKhoan.Update(user);
                            await _context.SaveChangesAsync();
                            // _httpContextAccessor.HttpContext.Session.SetString("anhDaiDien", Url.Content("~/img/anhdaidien/macdinh.jpg"));

                            // Trả về phản hồi thành công
                            return Json(new { success = true, message = "Xóa ảnh đại diện thành công!" });
                        }
                    }
                }
            }

            return Json(new { success = false, message = "Xóa ảnh đại diện thất bại!" });
        }

        // [HttpPost]
        // public async Task<IActionResult> Delete()
        // {
        //     var maTaiKhoan = HttpContext.Session.GetString("maTaiKhoan");
        //     if (!string.IsNullOrEmpty(maTaiKhoan))
        //     {
        //         int maTaiKhoanInt;
        //         if (int.TryParse(maTaiKhoan, out maTaiKhoanInt))
        //         {
        //             var user = _context.tblTaiKhoan.SingleOrDefault(u => u.maTaiKhoan == maTaiKhoanInt);
        //             if (user != null)
        //             {
        //                 // string uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/anhdaidien");
        //                 string oldfile = "wwwroot/img/anhdaidien" + user.anhDaiDien;
        //                 if (System.IO.File.Exists(oldfile))
        //                 {
        //                     System.IO.File.Delete(oldfile);
        //                     // Cập nhật thông tin tài khoản vào cơ sở dữ liệu
        //                     user.anhDaiDien = null;
        //                     _context.tblTaiKhoan.Update(user);
        //                     await _context.SaveChangesAsync();

        //                     // Trả về phản hồi thành công
        //                     return Json(new { success = true, message = "Xóa ảnh đại diện thành công!" });
        //                 }
        //             }
        //         }
        //     }
        //     // Trả về phản hồi lỗi (nếu không có tài khoản hoặc có lỗi xảy ra)
        //     return Json(new { success = false, message = "Có lỗi xảy ra khi xóa ảnh đại diện!" });
        // }
        // [HttpPost]
        // public async Task<IActionResult> Delete()
        // {
        //     var maTaiKhoan = HttpContext.Session.GetString("maTaiKhoan");
        //     if (!string.IsNullOrEmpty(maTaiKhoan))
        //     {
        //         int maTaiKhoanInt = int.Parse(maTaiKhoan);

        //         var user = _context.tblTaiKhoan.SingleOrDefault(u => u.maTaiKhoan == maTaiKhoanInt);
        //         string oldfile = "wwwroot/img/anhdaidien/" + user.anhDaiDien;
        //         if (System.IO.File.Exists(oldfile))
        //         {
        //             System.IO.File.Delete(oldfile);
        //             // Lưu thông tin taiKhoan vào cơ sở dữ liệu
        //             user.anhDaiDien = null;
        //             _context.tblTaiKhoan.Update(user);
        //             _context.SaveChanges();
        //         }

        //     }
        //     return Ok();
        // }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Error")]
        public IActionResult Error()
        {
            return View("Error!");
        }

    }
}