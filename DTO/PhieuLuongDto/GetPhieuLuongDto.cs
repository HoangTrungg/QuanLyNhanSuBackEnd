using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.DTO.PhieuLuongDto
{
    public class GetPhieuLuongDto
    {
        public int Id { get; set; }
        public DateTime NgayNhan { get; set; }
        public decimal? TongTien { get; set; }
        public int ChucVuID { get; set; }
        public int? TinhTienLuongID { get; set; }
        public int NhanVienID { get; set; }
        public virtual ChucVu ChucVu { get; set; }
        public virtual TinhTienLuong TinhTienLuong { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}