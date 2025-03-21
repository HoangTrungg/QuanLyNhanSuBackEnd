using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DTO.PhieuLuongDto
{
    public class CreatePhieuLuongDto
    {
        public DateTime NgayNhan { get; set; }
        public decimal? TongTien { get; set; }
        public int ChucVuID { get; set; }
        public int? TinhTienLuongID { get; set; }
        public int NhanVienId { get; set; }
    }
}