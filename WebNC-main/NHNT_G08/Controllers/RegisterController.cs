using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NHNT_G08.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace NHNT_G08.Controllers
{
    [Route("[controller]")]
    public class RegisterController : Controller
    {
        private readonly NHNTContext _context;
        public RegisterController(NHNTContext context)
        {

            _context = context;
        }


        [Route("Index")]
        public IActionResult Index()
        {
            return View("~/Views/Account/Register.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> Register(TaiKhoan model, IFormFile anhDaiDien)
        {

            var errorMessage = ValidateRegistration(model);
            if (errorMessage != null)
            {
                ViewBag.loi = errorMessage;
                return View("~/Views/Account/Register.cshtml", model);
            }

            // Thêm dữ liệu mới vào cơ sở dữ liệu
            
            model.maDmTaiKhoan = 2;
            model.soLanSai = 0;
            model.trangThai = "Hoạt Động";

            if (anhDaiDien != null && anhDaiDien.Length > 0)
            {
                // Lưu tệp tin vào thư mục trong dự án
                // string oldfile="wwwroot/img/anhdaidien" + model.anhDaiDien;
                // if(System.IO.File.Exists(oldfile)){
                //     System.IO.File.Delete(oldfile);
                // }
                string uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/anhdaidien");
                string uniqueFileName = model.tenDangNhap +".jpg";
                string filePath = Path.Combine(uploadsPath, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await anhDaiDien.CopyToAsync(fileStream);
                }
                // Lưu tên tệp tin vào đối tượng taiKhoan
                model.anhDaiDien = uniqueFileName;
            }
            // else{
            //     ViewBag.loi = "lỗi ảnh" + model.anhDaiDien;
            //     return View("~/Views/Account/Register.cshtml", model);
            // }
            /*if (anh != null && anh.Length > 0)
            {
                try
                {
                    // Mã để lưu ảnh vào thư mục
                    string uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/anhdaidien");
                    if (!Directory.Exists(uploadsPath))
                    {
                        Directory.CreateDirectory(uploadsPath);
                    }
                    model.anhDaiDien = model.tenDangNhap + ".jpg";
                    string filePath = Path.Combine(uploadsPath, model.anhDaiDien);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await anh.CopyToAsync(fileStream);
                    }
                    // Lưu tên tệp tin vào đối tượng taiKhoan
                }
                catch (Exception ex)
                {
                    ViewBag.loi = "lỗi ảnh" + model.anhDaiDien;
                    return View("~/Views/Account/Register.cshtml", model);
                }
                // string uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/anhdaidien");
                // string uniqueFileName = model.tenDangNhap + ".jpg";
                // string filePath = Path.Combine(uploadsPath, uniqueFileName);
                // using (var fileStream = new FileStream(filePath, FileMode.Create))
                // {
                //     await anhDaiDien.CopyToAsync(fileStream);
                // }
                // Lưu tên tệp tin vào đối tượng taiKhoan
                // model.anhDaiDien = uniqueFileName;
            }*/
            // else{
            //     ViewBag.loi = "lỗi ảnh" + model.anhDaiDien;
            //     return View("~/Views/Account/Register.cshtml", model);
            // }
            _context.tblTaiKhoan.Add(model);
            _context.SaveChanges();
            TempData["ThongBao"] = "Đăng Ký Thành Công";
            // Redirect đến trang đăng nhập hoặc trang chủ
            return RedirectToAction("Index", "Login", model);
            

        }
        private string ValidateRegistration(TaiKhoan model)
        {
            if (!ModelState.IsValid)
            {
                return "Vui lòng nhập đủ thông tin!";
            }
            if (!int.TryParse(model.soDienThoai, out _))
            {
                return "Số điện thoại không đúng định dạng!";
            }
            if (_context.tblTaiKhoan.Any(u => u.tenDangNhap == model.tenDangNhap))
            {
                return "Tài khoản đã tồn tại, vui lòng thay đổi Tên đăng nhập!";
            }
            return null;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Error")]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}