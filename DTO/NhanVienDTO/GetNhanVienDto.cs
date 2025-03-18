using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.DTO.NhanVienDTO
{
    public class GetNhanVienDto
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayBatDau { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string UserID { get; set; }
        public int? PhongBanID { get; set; }
        public int? ChucVuID { get; set; }
        public string TrangThai { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("ChucVuID")]
        public virtual ChucVu ChucVu { get; set; }

        [ForeignKey("PhongBanID")]
        public virtual PhongBan PhongBan { get; set; }
        public virtual ICollection<HopDong> HopDongs { get; set; }
        public virtual ICollection<PhieuLuong> PhieuLuongs { get; set; }
    }
}