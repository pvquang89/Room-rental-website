using Microsoft.AspNetCore.Http;
using NHNT_G08.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NHNT_G08.Models
{
    public class Phong
    {
        [Key]
        public int maPhong { get; set; }
        public int maTaiKhoan { get; set; }
        [Display(Name = "Tên Phòng")]
        [Required(ErrorMessage = "Cần Nhập Tên Phòng")]
        public string tenPhong { get; set; }
        [Display(Name = "Địa Chỉ")]
        [Required(ErrorMessage = "Cần Nhập Địa Chỉ")]
        public string diaChi { get; set; }
        [Display(Name = "Giá Phòng")]
        [Required(ErrorMessage = "Cần Nhập Giá Phòng")]
        public int giaPhong { get; set; }
        [Display(Name = "Giá Điện")]
        [Required(ErrorMessage = "Cần Nhập Giá Điện")]
        public int giaDien { get; set; }
        [Display(Name = "Giá Nước")]
        [Required(ErrorMessage = "Cần Nhập Giá Nước")]
        public int giaNuoc { get; set; }
        
        [Display(Name = "Trạng Thái Phòng")]
        public string trangThaiPhong { get; set; }
        public string trangThaiBaiDang { get; set; }
        [Display(Name = "Số Điện Thoại")]
        [Phone(ErrorMessage = "Không Phải Số Điện Thoại")]
        public string soDienThoai { get; set; }
        [Display(Name = "Diện Tích")]
        [Required(ErrorMessage = "Cần Nhập Diện Tích Phòng")]
        public double dienTich { get; set; }
        //[Display(Name = "Dịch vụ_verify key")]
        //[Required(ErrorMessage = "Cần Nhập dịch vụ")]
        //public double dichVu { get; set; }


        [Display(Name = "Mô Tả Phòng_Verify key")]
        public string chiTietPhong { get; set; }
        [NotMapped]
        public List<string> tenAnh { get; set; }
        [NotMapped]
        public string tenNguoiDang { get; set; }
        [NotMapped]
        public float soSaoTrungBinh { get; set; }
        [NotMapped]
        public int soLuotDanhGia { get; set; }
        [NotMapped]
        [Display(Name = "Chọn Hình Ảnh Đăng Tải")]
        [Required(ErrorMessage = "Chọn ít nhất một hình ảnh")]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public List<IFormFile> files { get; set; }
    }
}
