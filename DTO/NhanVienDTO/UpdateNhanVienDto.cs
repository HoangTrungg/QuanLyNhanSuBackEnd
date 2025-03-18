using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DTO.NhanVienDTO
{
    public class UpdateNhanVienDto
    {
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayBatDau { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public int? PhongBanID { get; set; }
        public int? ChucVuID { get; set; }
        public string TrangThai { get; set; }
    }
}